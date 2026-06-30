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
    public class DoctorService
    {
        private readonly AppointmentContext _context;

        public DoctorService(AppointmentContext context)
        {
            _context = context;
        }

        //stellt eine Liste von Ärzten da
        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        //Fügt einen neuen Arzt hinzu
        public async Task AddDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        //Ändert die Daten des Arztes
        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }


        //Löscht einen Arzt von der Datenbank
        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
