using BoundBoxApp.DAL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoundBoxApp
{
    [Authorize(Roles = "Admin, ContentOwner")]
    public class ProjectDetailsModel : PageModel
    {
        private readonly ProjectService _projectService;

        public Model.Project Project { get; set; }

        public ProjectDetailsModel(
            ProjectService projectService)
        {
            _projectService = projectService;
        }

        public void OnGet(string projectId) 
        {
            Project = _projectService.GetProjectAsync(projectId).Result;
            if (Project == null)
            {
                return;
            }
        }
    }
}