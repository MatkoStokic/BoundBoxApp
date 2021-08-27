using BoundBoxApp.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoundBoxApp.DAL.Services
{
    public class ProjectService
    {
        private readonly ApplicationDbContext _context;

        public ProjectService (
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetProjectsByUserAsync(string userId)
        {
            List<Project> projects = await _context.Projects.ToListAsync();
            return projects.FindAll(p => p.OwnerId == userId);
        }

        public async Task<bool> InsertProjectAsync(Project entity)
        {
            await _context.Projects.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Project> GetProjectAsync(int Id)
        {
            return await _context.Projects.FirstOrDefaultAsync(c => c.Id.Equals(Id));
        }

        public async Task<bool> UpdateProjectAsync(Project entity)
        {
            _context.Projects.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(Project entity)
        {
            _context.Projects.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
