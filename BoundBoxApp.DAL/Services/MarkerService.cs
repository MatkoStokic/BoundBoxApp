﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BoundBoxApp.Model;

namespace BoundBoxApp.DAL.Services
{
    class MarkerService
    {
        private readonly ApplicationDbContext _context;

        public MarkerService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertMarkerAsync(Marker entity)
        {
            await _context.Markers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
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