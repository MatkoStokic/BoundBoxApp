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
        private readonly BoundService _boundService;

        public ProjectService (
            ApplicationDbContext context,
            BoundService boundService)
        {
            _context = context;
            _boundService = boundService;
        }

        public async Task<List<Project>> GetProjectsByUserAsync(string userId)
        {
            List<Project> projects = await _context.Projects
                .Include(project => project.Owner)
                .Where(p => p.OwnerId == userId)
                .ToListAsync();
            foreach (Project project in projects)
            {
                project.Bounds = await _boundService.GetBoundsByProjectAsync(project.Id);
            }
            return projects;
        }

        public async Task<bool> InsertProjectAsync(Project entity)
        {
            await _context.Projects.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Project> GetProjectAsync(string Id)
        {
            Project project = await _context.Projects
                .Include(project => project.Owner)
                .FirstOrDefaultAsync(c => c.Id.Equals(Id));
            project.Bounds = await _boundService.GetBoundsByProjectAsync(project.Id);
            return project;
        }

        public async Task<bool> UpdateProjectAsync(Project entity)
        {
            _context.Projects.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProjectAsync(Project entity)
        {
            _context.Projects.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Project>> GetRandomForMarking(List<string> solved)
        {
            List<Project> projects = await _context.Projects
                .Include(project => project.Owner)
                .Where(p => !solved.Contains(p.Id) && p.IsForAnnotating)
                .ToListAsync();
            foreach (Project project in projects)
            {
                project.Bounds = await _boundService.GetBoundsByProjectAsync(project.Id);
            }
            return projects;
        }

        public async Task<List<Project>> GetRandomForCategory(List<string> solved)
        {
            List<Project> projects = await _context.Projects
                .Include(project => project.Owner)
                .Where(p => !solved.Contains(p.Id) && !p.IsForAnnotating)
                .ToListAsync();
            foreach (Project project in projects)
            {
                project.Bounds = await _boundService.GetBoundsByProjectAsync(project.Id);
            }
            return projects;
        }
    }
}
