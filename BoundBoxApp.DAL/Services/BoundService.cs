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

        public List<Annotation> GetPBoundsByUserAsync(string entityId)
        {
            var entities = _context.Annotations
                .Where(bounds => bounds.AnnotatorId == entityId)
                .Include(bounds => bounds.Markers)
                .Include(bounds => bounds.Annotator).ToList();
            entities.ForEach(e => e.Markers = 
                e.Markers.OrderBy(m => m.Order).ToList());
            return entities;
        }

        public List<Annotation> GetBoundsByProjectAsync(string projectId)
        {
            var entities = _context.Annotations
                .Where(bounds => bounds.ProjectId == projectId)
                .Include(bounds => bounds.Markers)
                .Include(bounds => bounds.Annotator).ToList();
            entities.ForEach(e => e.Markers =
                e.Markers.OrderBy(m => m.Order).ToList());
            return entities;
        }

        public async Task<bool> InsertBoundsAsync(Annotation entity)
        {
            await _context.Annotations.AddAsync(entity);

            if (entity.Markers != null)
            {
                List<Marker> markers = entity.Markers.ToList();
                markers.ForEach(m => m.BoundsId = entity.Id);
                await _context.Markers.AddRangeAsync(markers);
            }
            
            await _context.SaveChangesAsync();
            return true;
        }

        public Annotation GetBoundstAsync(string Id)
        {
            var entity = _context.Annotations
               .Include(bounds => bounds.Markers)
               .Include(bounds => bounds.Annotator).FirstOrDefault(c => c.Id.Equals(Id));
            entity.Markers = entity.Markers.OrderBy(m => m.Order).ToList();
            return entity;
        }

        public async Task<bool> UpdateBoundsAsync(Annotation entity)
        {
            _context.Annotations.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBoundsAsync(Annotation entity)
        {
            _context.Annotations.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool IsSolved(string userId, string projectId)
        {
            var bounds = _context.Annotations
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
            _context.Annotations
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
