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
    public class ProjectEditModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public Model.Project Project { get; set; }


        private readonly ProjectService _projectService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ProjectDetailsModel> _logger;
        private readonly ImageService _imageService;

        public ProjectEditModel(
            ProjectService projectService,
            UserManager<IdentityUser> userManager,
            IWebHostEnvironment environment,
            ILogger<ProjectDetailsModel> logger,
            ImageService imageService)
        {
            _projectService = projectService;
            _userManager = userManager;
            _environment = environment;
            _logger = logger;
            _imageService = imageService;
        }

        public class InputModel
        {
            [Required]
            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "Title")]
            public string Title { get; set; }

            [Display(Name = "Categories", Prompt = "cat1, cat2, cat3, etc.")]
            public string Categories { get; set; }

            public bool IsForObjectDetection { get; set; }

            [DataType(DataType.Upload)]
            [Display(Name = "Add images")]
            public List<IFormFile >Images { get; set; }
        }

        public void OnGet(string projectId)
        {
            Project  = _projectService.GetProjectAsync(projectId).Result;
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

            if (Project == null || user.Id != Project.Owner.Id)
            {
                return LocalRedirect(returnUrl);
            }

            if (Input.Images != null)
            {
                SaveFiles(Project.Id).Wait();
            }

            var forDel = ImageEdit.ForDelete;
            if (forDel != null && forDel.Count > 0)
            {
                DeleteFiles(forDel);
            }

            if (!CheckChanges())
            {
                return LocalRedirect(returnUrl); 
            }


            UpdateEntity(new Model.Project()
            {
                Id = Project.Id,
                Title = Project.Title,
                Categories = Project.Categories,
                IsForObjectDetection = Project.IsForObjectDetection,
                OwnerId = Project.OwnerId
            }).Wait();
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
            foreach (IFormFile image in Input.Images)
            {
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

        private void DeleteFiles(List<Image> forDelete)
        {
            foreach (Image image in forDelete)
            {
                var file = Path.Combine(_environment.ContentRootPath, "wwwroot" + image.Src);
                System.IO.File.Delete(file);

                _imageService.DeleteImageAsync(image).Wait();
            }

        }

        private bool CheckChanges()
        {
            bool changed = false;
            if (Project.Title != Input.Title)
            {
                Project.Title = Input.Title;
                changed = true;
            }
            if (Project.Categories != Input.Categories)
            {
                Project.Categories = Input.Categories;
                changed = true;
            }
            if (Project.IsForObjectDetection != Input.IsForObjectDetection)
            {
                Project.IsForObjectDetection = Input.IsForObjectDetection;
                changed = true;
            }

            return changed;
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
