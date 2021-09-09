using BoundBoxApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoundBoxApp.DAL.Services
{
    public class AnnotationService
    {
        private readonly ApplicationDbContext _context;

        public AnnotationService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Annotation> GetPAnnotationsByUserAsync(string entityId)
        {
            var entities = _context.Annotations
                .Where(annotation => annotation.AnnotatorId == entityId)
                .Include(annotation => annotation.Markers)
                .Include(annotation => annotation.Annotator).AsNoTracking().ToList();
            entities.ForEach(e => e.Markers = 
                e.Markers.OrderBy(m => m.Order).ToList());
            return entities;
        }

        public List<Annotation> GetAnnotationsByImageAsync(string imageId)
        {
            var entities = _context.Annotations
                .Where(annotations => annotations.ImageId == imageId)
                .Include(annotations => annotations.Markers)
                .Include(annotations => annotations.Annotator).AsNoTracking().ToList();
            entities.ForEach(e => e.Markers =
                e.Markers.OrderBy(m => m.Order).ToList());
            return entities;
        }

        public async Task<bool> InsertAnnotationAsync(Annotation entity)
        {
            await _context.Annotations.AddAsync(entity);

            if (entity.Markers != null)
            {
                List<Marker> markers = entity.Markers.ToList();
                markers.ForEach(m => m.AnnotationsId = entity.Id);
                await _context.Markers.AddRangeAsync(markers);
            }
            
            await _context.SaveChangesAsync();
            return true;
        }

        public Annotation GetAnnotationtAsync(string Id)
        {
            var entity = _context.Annotations
               .Include(annotation => annotation.Markers)
               .Include(annotation => annotation.Annotator).AsNoTracking().FirstOrDefault(c => c.Id.Equals(Id));
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

            foreach (Marker marker in entity.Markers)
            {
                _context.Markers.Remove(marker);
            }
            _context.Annotations.Remove(entity);

            await _context.SaveChangesAsync();
            return true;
        }

        public bool IsSolved(string userId, string imageId)
        {
            var bounds = _context.Annotations
                .Where(bounds => bounds.AnnotatorId == userId 
                    && bounds.ImageId == imageId)
                .AsNoTracking()
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
                .AsNoTracking()
                .ToList()
                .ForEach(bounds => solved.Add(bounds.ImageId));
            return solved;
        }
    }
}
