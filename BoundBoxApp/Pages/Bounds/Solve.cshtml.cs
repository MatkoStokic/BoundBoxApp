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
        public bool IsFetched { get; set; } = false;
        [ViewData]
        public List<string> Categories { get; set; }

        private readonly BoundService _boundService;
        private readonly ProjectService _projectService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<SolveModel> _logger;

        public SolveModel (
            BoundService boundService,
            ProjectService projectService,
            UserManager<IdentityUser> userManager,
            ILogger<SolveModel> logger)
        {
            _boundService = boundService;
            _projectService = projectService;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string ProjectId { get; set; }
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
                || _boundService.IsSolved(user.Id, Input.ProjectId))
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

            var solved = _boundService.GetSolved(user.Id);
            var projects = _projectService.GetRandomForMarking(solved).Result;
            if (projects.Count == 0)
            {
                return;
            }
            Project = _boundService.GetRandomProject(projects);
            Categories = Project.Categories.Split(", ").ToList();

        }

        public void FetchForCategory()
        {
            var user = GetUser().Result;
            var solved = _boundService.GetSolved(user.Id);
            var projects = _projectService.GetRandomForCategory(solved).Result;
            if (projects.Count == 0)
            {
                return;
            }

            Project = _boundService.GetRandomProject(projects);
            Categories = Project.Categories.Split(", ").ToList();

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
                    ProjectId = Input.ProjectId,
                    Category = key,
                    IsObjectDetection = true,
                    Markers = markers
                };

                var saved = await _boundService.InsertBoundsAsync(entity);
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
                ProjectId = Input.ProjectId,
                Category = Input.Category,
                IsObjectDetection = false
            };

            var saved = await _boundService.InsertBoundsAsync(entity);
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
