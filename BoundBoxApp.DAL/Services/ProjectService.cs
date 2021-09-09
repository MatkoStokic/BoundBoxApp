using BoundBoxApp.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoundBoxApp.DAL.Services
{
    public class ProjectService
    {
        private readonly ApplicationDbContext _context;
        private readonly ImageService _imageService;

        public ProjectService (
            ApplicationDbContext context,
            ImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        public async Task<List<Project>> GetProjectsByUserAsync(string userId)
        {
            List<Project> projects = await _context.Projects
                .Include(project => project.Owner)
                .Where(p => p.OwnerId == userId)
                .AsNoTracking()
                .ToListAsync();
           
            return projects;
        }

        public async Task<bool> InsertProjectAsync(Project entity)
        {
            await _context.Projects.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateProjectAsync(Project entity)
        {
            _context.Projects.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Project> GetProjectAsync(string Id)
        {
            Project project = await _context.Projects
                .Include(project => project.Owner)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id.Equals(Id));
            project.Images = _imageService.GetImagesByProjectAsync(project.Id);
            return project;
        }

        public async Task<bool> DeleteProjectAsync(Project entity)
        {
            _context.Projects.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Project> GetRandomForMarking(List<string> solved)
        {
            List<Image> images = await _context.Images
                .Where(i => !solved.Contains(i.Id))
                .AsNoTracking()
                .ToListAsync();

            List<Project> projects = new List<Project>();
            foreach (Image img in images)
            {
                Project project = await _context.Projects.AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id.Equals(img.ProjectId));

                if (project.IsForObjectDetection)
                {
                    projects.Add(new Project
                    {
                        Id = project.Id,
                        Categories = project.Categories,
                        OwnerId = project.OwnerId,
                        Title = project.Title,
                        IsForObjectDetection = project.IsForObjectDetection,
                        Images = new List<Image> { img }
                    });
                }
            }

            if (projects.Count == 0)
            {
                return null;
            }

            var random = new Random();
            int index = random.Next(projects.Count);
            return projects[index];
        }

        public async Task<Project> GetRandomForCategory(List<string> solved)
        {
            List<Image> images = await _context.Images
                .Where(i => !solved.Contains(i.Id)).AsNoTracking()
                .ToListAsync();

            List<Project> projects = new List<Project>();
            foreach (Image img in images)
            {
                Project project = await _context.Projects.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id.Equals(img.ProjectId));

                if (!project.IsForObjectDetection)
                {
                    project.Images = new List<Image> { img };
                    projects.Add(project);
                }
            }

            if (projects.Count == 0)
            {
                return null;
            }

            var random = new Random();
            int index = random.Next(projects.Count);
            return projects[index];
        }
    }
}
