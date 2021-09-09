using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoundBoxApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BoundBoxApp.DAL.Services
{
    public class ImageService
    {
        private readonly ApplicationDbContext _context;
        private readonly AnnotationService _annotationService;

        public ImageService(
            ApplicationDbContext context,
            AnnotationService annotationService)
        {
            _context = context;
            _annotationService = annotationService;
        }

        public async Task<bool> InsertImageAsync(Image entity)
        {
            await _context.Images.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteImageAsync(Image entity)
        {
            foreach (Annotation annotation in entity.Annotations)
            {
                _annotationService.DeleteBoundsAsync(annotation).Wait();
            }
            _context.Images.Remove(entity);

            await _context.SaveChangesAsync();
            return true;
        }

        public List<Image> GetImagesByProjectAsync(string projectId)
        {
            var entities = _context.Images
                .Where(image => image.ProjectId == projectId).AsNoTracking()
                .ToList();

            foreach (Image entity in entities) {
                entity.Annotations = _annotationService.GetAnnotationsByImageAsync(entity.Id);
            }

            return entities;
        }

    }
}
