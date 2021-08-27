using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BoundBoxApp.DAL.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BoundBoxApp.Pages.Project
{
    public class CreateProjectModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<CreateProjectModel> _logger;
        private readonly ProjectService _projectService;

        public CreateProjectModel(
            IWebHostEnvironment environment,
            UserManager<IdentityUser> userManager,
            ILogger<CreateProjectModel> logger,
            ProjectService projectService)
        {
            _environment = environment;
            _userManager = userManager;
            _logger = logger;
            _projectService = projectService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "Title")]
            public string Title { get; set; }

            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "Category")]
            public string Category { get; set; }

            [Display(Name = "Is for Annotation")]
            public bool IsForAnnotation { get; set; }

            [Required]
            [DataType(DataType.Upload)]
            [Display(Name = "Image")]
            public IFormFile Image { get; set; }
        }

        public async Task OnPostAsync()
        {
            var user = await GetUser();
            if (user == null)
            {
                return;
            }

            var id = Guid.NewGuid().ToString();
            var file = await SaveFile(id);
            if (file == null)
            {
                return;
            }

            SaveEntity(id, file, user.Id);
        }

        private async Task<IdentityUser> GetUser()
        {
            string userName = HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }

        private async Task<string> SaveFile(string guid)
        {
            var contentType = Input.Image.ContentType.Split("/");
            if (contentType[0] != "image")
            {
                return null;
            }
            string fileName = guid + "." + contentType[1];
            var file = Path.Combine(_environment.ContentRootPath, "Uploads", fileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Input.Image.CopyToAsync(fileStream);
            }
            return file;
        }

        private async void SaveEntity(string id, string src, string userId)
        {
            BoundBoxApp.Model.Project entity = new BoundBoxApp.Model.Project()
            {
                Id = id,
                Title = Input.Title,
                Category = Input.Category,
                IsForAnnotating = Input.IsForAnnotation,
                Src = src,
                OwnerId = userId
            };

            var saved = await _projectService.InsertProjectAsync(entity);
            if (saved)
            {
                _logger.LogInformation("Created new project {0}", entity);
            }
            else
            {
                _logger.LogInformation("Faild to create project {0}", entity);
            }
        }
    }
}
