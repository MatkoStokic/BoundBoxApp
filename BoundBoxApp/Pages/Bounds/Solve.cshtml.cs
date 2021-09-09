using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BoundBoxApp.DAL.Services;
using Microsoft.AspNetCore.Identity;
using BoundBoxApp.Model;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace BoundBoxApp.Pages.Bounds
{
    [Authorize(Roles ="Admin, Annotator")]
    public class SolveModel : PageModel
    {
        [ViewData]
        public Model.Project Project { get; set; }
        [ViewData]
        public Image Image { get; set; }
        public bool IsFetched { get; set; } = false;
        [ViewData]
        public List<string> Categories { get; set; }

        private readonly AnnotationService _annotationService;
        private readonly ProjectService _projectService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<SolveModel> _logger;

        public SolveModel (
            AnnotationService annotationService,
            ProjectService projectService,
            UserManager<IdentityUser> userManager,
            ILogger<SolveModel> logger)
        {
            _annotationService = annotationService;
            _projectService = projectService;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string ImageId { get; set; }

            public string Category { get; set; }
        }

        public void OnGet(string type)
        {
            IsFetched = true;
            if (type == "marking")
            {
                FetchForMarking();
            }
            else if (type == "category")
            {
                FetchForCategory();
            }
            else
            {
                IsFetched = false;
            }

        }

        public IActionResult OnPost (string type)
        {
            string returnUrl = Url.Content("~/solve");

            var user = GetUser().Result;
            if (user == null
                || _annotationService.IsSolved(user.Id, Input.ImageId))
            {
                return LocalRedirect(returnUrl);
            }

            if (type == "marking")
            {
                CreateForMarking(user.Id).Wait();
            }
            else if (type == "category")
            {
                CreateForCategory(user.Id).Wait();
            }

            return LocalRedirect(returnUrl);
        }

        public void FetchForMarking()
        {
            IdentityUser user = GetUser().Result;
            if (user == null)
            {
                return;
            }

            var solved = _annotationService.GetSolved(user.Id);
            Project = _projectService.GetRandomForMarking(solved).Result;

            if (Project == null)
            {
                return;
            }

            Categories = Project.Categories.Split(", ").ToList();

            var random = new Random();
            int index = random.Next(Project.Images.Count);
            Image = Project.Images.ToList()[index];

        }

        public void FetchForCategory()
        {
            var user = GetUser().Result;
            var solved = _annotationService.GetSolved(user.Id);
            Project = _projectService.GetRandomForCategory(solved).Result;

            if (Project == null)
            {
                return;
            }

            Categories = Project.Categories.Split(", ").ToList();

            var random = new Random();
            int index = random.Next(Project.Images.Count);
            Image = Project.Images.ToList()[index];
        }

        public async Task CreateForMarking(string userId)
        {
            Dictionary<string, List<Marker>> annotations = AnnotationCanvas.annotations;
            foreach (string key in annotations.Keys)
            {
                List<Marker> markers = SaveMarker(annotations[key]);
                Model.Annotation entity = new Model.Annotation()
                {
                    Id = Guid.NewGuid().ToString(),
                    AnnotatorId = userId,
                    ImageId = Input.ImageId,
                    Category = key,
                    IsObjectDetection = true,
                    Markers = markers
                };

                var saved = await _annotationService.InsertAnnotationAsync(entity);
                if (saved)
                {
                    _logger.LogInformation("Created new bounds {0}", entity);
                }
                else
                {
                    _logger.LogInformation("Faild to create bounds {0}", entity);
                }
            }
            
        }

        public async Task CreateForCategory(string userId)
        {
            Model.Annotation entity = new Model.Annotation()
            {
                Id = Guid.NewGuid().ToString(),
                AnnotatorId = userId,
                ImageId = Input.ImageId,
                Category = Input.Category,
                IsObjectDetection = false
            };

            var saved = await _annotationService.InsertAnnotationAsync(entity);
            if (saved)
            {
                _logger.LogInformation("Created new bounds {0}", entity);
            }
            else
            {
                _logger.LogInformation("Faild to create bounds {0}", entity);
            }
        }


        private async Task<IdentityUser> GetUser()
        {
            string userName = HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }

        private List<Marker> SaveMarker(List<Marker> markers)
        {        
            for ( int i = 0; i < markers.Count; i++)
            {
                markers[i].Id = Guid.NewGuid().ToString();
                markers[i].Order = i;
            }
            

            return markers;
        }
    }
}
