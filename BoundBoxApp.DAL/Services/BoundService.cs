using BoundBoxApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoundBoxApp.DAL.Services
{
    public class BoundService
    {
        private readonly ApplicationDbContext _context;

        public BoundService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Bounds>> GetPBoundsByUserAsync(string entityId)
        {
            return await _context.Bounds
                .Where(bounds => bounds.AnnotatorId == entityId)
                .Include(bounds => bounds.Markers)
                .Include(bounds => bounds.Annotator).ToListAsync();
        }

        public async Task<List<Bounds>> GetBoundsByProjectAsync(string projectId)
        {
            return await _context.Bounds
                .Where(bounds => bounds.ProjectId == projectId)
                .Include(bounds => bounds.Markers)
                .Include(bounds => bounds.Annotator).ToListAsync();
        }

        public async Task<bool> InsertBoundsAsync(Bounds entity)
        {
            await _context.Bounds.AddAsync(entity);
            List<Marker> markers = entity.Markers.ToList();
            markers.ForEach(m => m.BoundsId = entity.Id);
            await _context.Markers.AddRangeAsync(markers);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Bounds> GetBoundstAsync(string Id)
        {
            return await _context.Bounds
                .Include(bounds => bounds.Markers)
                .Include(bounds => bounds.Annotator)
                .FirstOrDefaultAsync(c => c.Id.Equals(Id));
        }

        public async Task<bool> UpdateBoundsAsync(Bounds entity)
        {
            _context.Bounds.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBoundsAsync(Bounds entity)
        {
            _context.Bounds.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool IsSolved(string userId, string projectId)
        {
            var bounds = _context.Bounds
                .Where(bounds => bounds.AnnotatorId == userId 
                    && bounds.ProjectId == projectId)
                .FirstOrDefault();

            if (bounds != null)
            {
                return true;
            }

            return false;
        }

        public List<string> GetSolved(string userId)
        {
            List<string> solved = new List<string>();
            _context.Bounds
                .Where(bounds => bounds.AnnotatorId == userId)
                .ToList()
                .ForEach(bounds => solved.Add(bounds.ProjectId));
            return solved;
        }

        public Project GetRandomProject(List<Project> projects)
        {
            var random = new Random();
            int index = random.Next(projects.Count);
            return projects[index];
        }
    }
}
