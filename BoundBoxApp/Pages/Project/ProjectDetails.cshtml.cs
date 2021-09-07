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

namespace BoundBoxApp
{
    [Authorize(Roles = "Admin, ContentOwner")]
    public class ProjectDetailsModel : PageModel
    {
        private readonly ProjectService _projectService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ProjectDetailsModel> _logger;

        [BindProperty]
        public InputModel Input { get; set; }
        public Model.Project Project { get; set; }

        public ProjectDetailsModel(
            ProjectService projectService,
            UserManager<IdentityUser> userManager,
            IWebHostEnvironment environment,
            ILogger<ProjectDetailsModel> logger
            )
        {
            _projectService = projectService;
            _userManager = userManager;
            _environment = environment;
            _logger = logger;
        }

        public class InputModel
        {
            [Required]
            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "Title")]
            public string Title { get; set; }

            [Display(Name = "Categories")]
            public string Categories { get; set; }

            public bool IsForObjectDetection { get; set; }

            [DataType(DataType.Upload)]
            [Display(Name = "Image")]
            public IFormFile Image { get; set; }
        }

        public void OnGet(string projectId) 
        {
            Project = _projectService.GetProjectAsync(projectId).Result;
            if (Project == null)
            {
                return;
            }

            Input = new InputModel
            {
                Title = Project.Title,
                Categories = Project.Categories,
                IsForObjectDetection = Project.IsForObjectDetection
            };
        }

        public IActionResult OnPost(string projectId)
        {
            string returnUrl = "~/project";
            IdentityUser user = GetUser().Result;
            Project = _projectService.GetProjectAsync(projectId).Result;

            if (Project == null || user.Id != Project.Owner.Id )
            {
                return LocalRedirect(returnUrl);
            }

            Project.Title = Input.Title;
            Project.Categories = Input.Categories;
            Project.IsForObjectDetection = Input.IsForObjectDetection;

            if (Input.Image != null)
            {
                string src = SaveFile(Guid.NewGuid().ToString()).Result;
                // DeleteFile(Project.Src);
                // Project.Src = "/upload/" + src;
            }

            UpdateEntity(Project).Wait();
            return LocalRedirect(returnUrl);
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
            var file = Path.Combine(_environment.ContentRootPath, "wwwroot/upload", fileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Input.Image.CopyToAsync(fileStream);
            }
            return fileName;
        }

        private void DeleteFile(string src)
        {
            var file = Path.Combine(_environment.ContentRootPath, "wwwroot" + src);
            System.IO.File.Delete(file);
        }

        private async Task UpdateEntity(Model.Project project)
        {
            var saved = await _projectService.UpdateProjectAsync(project);
            if (saved)
            {
                _logger.LogInformation("Updated project {0}", project);
            }
            else
            {
                _logger.LogInformation("Faild to update project {0}", project);
            }
        }
    }
}