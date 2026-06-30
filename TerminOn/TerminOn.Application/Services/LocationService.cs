using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminOn.Application.Infrastructur;
using TerminOn.Application.Model;

namespace TerminOn.Application.Services
{
    public class LocationService
    {
        private readonly AppointmentContext _context;

        public LocationService(AppointmentContext context)
        {
            _context = context;
        }

        // Holt alle Räume/Ordinationen für das Kalender-Grid
        public async Task<List<Location>> GetAllLocationsAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        // Fügt einen neuen Raum hinzu
        public async Task AddLocationAsync(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
        }
        //Ändert den Raum
        public async Task UpdateLocationAsync(Location location)
        {
            _context.Locations.Update(location);
            await _context.SaveChangesAsync();
        }

        //Löscht den Raum
        public async Task DeleteLocationAsync(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
            }
        }

    }
}
