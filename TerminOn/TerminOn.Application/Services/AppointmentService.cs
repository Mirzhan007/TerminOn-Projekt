using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminOn.Application.Infrastructur;
using TerminOn.Application.Model;

namespace TerminOn.Application.Services
{
    public class AppointmentService
    {
        private readonly AppointmentContext _context;

        public AppointmentService(AppointmentContext context)
        {
            _context = context;
        }

        // Holt Termine für einen Tag inkl. Patient, Resource (Raum) und Status
        public async Task<List<Appointment>> GetAppointmentsByDateAsync(DateOnly date)
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Resource)     
                .Include(a => a.CurrentState)  
                .Include(a => a.AppointmentType) 
                .Where(a => a.Date == date)
                .ToListAsync();
        }

        // Holt Termine für einen Zeitraum (Woche/Monat)
        public async Task<List<Appointment>> GetAppointmentsByRangeAsync(DateOnly start, DateOnly end)
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Resource)
                .Include(a => a.CurrentState)
                .Include(a => a.AppointmentType) 
                .Where(a => a.Date >= start && a.Date <= end)
                .ToListAsync();
        }

        // CREATE: Einen neuen Termin buchen
        public async Task AddAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        // UPDATE: Falls ein Termin verschoben oder abgesagt wird
        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }


    }
}
