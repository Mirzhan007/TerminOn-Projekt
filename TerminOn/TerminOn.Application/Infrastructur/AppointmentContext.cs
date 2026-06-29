using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TerminOn.Application.Model;

namespace TerminOn.Application.Infrastructur;

public class AppointmentContext : DbContext
{
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<AppointmentState> AppointmentStates => Set<AppointmentState>();
    public DbSet<CancelledAppointmentState> CancelledAppointmentStates => Set<CancelledAppointmentState>();
    public DbSet<ConfirmedAppointmentState> ConfirmedAppointmentStates => Set<ConfirmedAppointmentState>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Doctor> Doctors => Set<Doctor>();

    public DbSet<Location> Locations => Set<Location>(); 
    public DbSet<Resource> Resources => Set<Resource>(); 

    public AppointmentContext(DbContextOptions opt) : base(opt)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>().ToTable("Appointment");
        modelBuilder.Entity<AppointmentState>().ToTable("AppointmentState");
        modelBuilder.Entity<Patient>().ToTable("Patient");
        modelBuilder.Entity<Doctor>().ToTable("Doctor");
        modelBuilder.Entity<Location>().ToTable("Location");
        modelBuilder.Entity<Resource>().ToTable("Resource");

     
        modelBuilder.Entity<AppointmentState>().HasDiscriminator(a => a.Type)
            .HasValue<ConfirmedAppointmentState>("Confirmed")
            .HasValue<CancelledAppointmentState>("Cancelled");

        modelBuilder.Entity<ConfirmedAppointmentState>().OwnsOne(c => c.PlannedSlot);

        modelBuilder.Entity<Patient>().Property(p => p.InsuranceNumber)
            .HasConversion(
                objVal => objVal.Value,
                dbVal => new InsuranceNumber(dbVal));

        modelBuilder.Entity<Patient>().Property(p => p.Mobile)
            .HasConversion(
                objVal => objVal == null ? null : objVal.Value,
                dbVal => dbVal == null ? null : new PhoneNumber(dbVal));

        modelBuilder.Entity<Doctor>().HasIndex(d => d.Email).IsUnique();

        modelBuilder.Entity<Appointment>().HasIndex("Date", "PatientId").IsUnique();
    }
}