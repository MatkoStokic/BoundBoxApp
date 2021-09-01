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

namespace BoundBoxApp.Pages.Bounds
{
    public class SolveModel : PageModel
    {
        [ViewData]
        public Model.Project Project { get; set; }
        public bool IsFetched { get; set; } = false;

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

            var id = Guid.NewGuid().ToString();

            if (type == "marking")
            {
                CreateForMarking(user.Id, id).Wait();
            }
            else if (type == "category")
            {
                CreateForCategory(user.Id, id).Wait();
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
        }

        public async Task CreateForMarking(string userId, string id)
        {
            List<Marker> markers = SaveMarker();
            Model.Bounds entity = new Model.Bounds()
            {
                Id = id,
                AnnotatorId = userId,
                ProjectId = Input.ProjectId,
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

        public async Task CreateForCategory(string userId, string id)
        {

        }


        private async Task<IdentityUser> GetUser()
        {
            string userName = HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }

        private List<Marker> SaveMarker()
        {
            foreach (Marker marker in AnnotationCanvas.markers) {
                marker.Id = Guid.NewGuid().ToString();
            }

            return AnnotationCanvas.markers;
        }
    }
}
