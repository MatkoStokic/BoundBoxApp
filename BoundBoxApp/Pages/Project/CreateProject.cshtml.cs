using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BoundBoxApp.DAL.Services;
using BoundBoxApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BoundBoxApp.Pages.Project
{
    [Authorize(Roles = "Admin, ContentOwner")]
    public class CreateProjectModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<CreateProjectModel> _logger;
        private readonly ProjectService _projectService;
        private readonly ImageService _imageService;

        public CreateProjectModel(
            IWebHostEnvironment environment,
            UserManager<IdentityUser> userManager,
            ILogger<CreateProjectModel> logger,
            ProjectService projectService,
            ImageService imageService)
        {
            _environment = environment;
            _userManager = userManager;
            _logger = logger;
            _projectService = projectService;
            _imageService = imageService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "Title")]
            public string Title { get; set; }

            [Required]
            [Display(Name = "Categories", Prompt = "cat1, cat2, cat3, etc.")]
            public string Categories { get; set; }

            public bool IsForObjectDetection { get; set; }

            [Required]
            [DataType(DataType.Upload)]
            [Display(Name = "Images")]
            public List<IFormFile> Images { get; set; }
        }

        public IActionResult OnPost()
        {
            string returnUrl = Url.Content("~/project");

            var user = GetUser().Result;
            if (user == null)
            {
                return LocalRedirect(returnUrl);
            }

            string projectId = Guid.NewGuid().ToString();

            SaveEntity(projectId, user.Id).Wait();
            var saved = SaveFiles(projectId).Result;

            return LocalRedirect(returnUrl);
        }

        private async Task<IdentityUser> GetUser()
        {
            string userName = HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }

        private async Task<bool> SaveFiles(string projectId)
        {
            foreach (IFormFile image in Input.Images) {
                var contentType = image.ContentType.Split("/");
                if (contentType[0] != "image")
                {
                    return false;
                }
                string id = Guid.NewGuid().ToString();
                string fileName = id + "." + contentType[1];
                var file = Path.Combine(_environment.ContentRootPath, "wwwroot/upload", fileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                Image entity = new Image
                {
                    Id = id,
                    Src = "/upload/" + fileName,
                    ProjectId = projectId
                };

                _imageService.InsertImageAsync(entity).Wait();
            }
            
            return true;
        }

        private async Task SaveEntity(string id, string userId)
        {
            Model.Project entity = new Model.Project()
            {
                Id = id,
                Title = Input.Title,
                Categories = Input.Categories,
                IsForObjectDetection = Input.IsForObjectDetection,
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
