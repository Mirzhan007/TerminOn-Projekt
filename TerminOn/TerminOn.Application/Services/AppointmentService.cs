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

        public async Task<List<Appointment>> GetAppointmentsByDateAsync(DateOnly date)
        {
            return await _context.Appointments
                .Include(a => a.Patient)      
                .Include(a => a.Doctor)       
                .Include(a => a.Location)     
                .Include(a => a.CurrentState) 
                .Where(a => a.Date == date)
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
