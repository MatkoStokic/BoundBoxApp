using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoundBoxApp.DAL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BoundBoxApp.Pages.Project
{
    [Authorize(Roles = "Admin, ContentOwner")]
    public class ProjectModel : PageModel
    {
        [ViewData]
        public List<Model.Project> Projects { get; set; } = new List<Model.Project>();

        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<ProjectModel> _logger;
        private readonly ProjectService _projectService;

        public ProjectModel(
            UserManager<IdentityUser> userManager,
            ILogger<ProjectModel> logger,
            ProjectService projectService)
        {
            _userManager = userManager;
            _logger = logger;
            _projectService = projectService;
        }

        public void OnGet()
        {
            var user = GetUser().Result;
            Projects = _projectService.GetProjectsByUserAsync(user.Id).Result;
        }

        private async Task<IdentityUser> GetUser()
        {
            string userName = HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }

    }
}
