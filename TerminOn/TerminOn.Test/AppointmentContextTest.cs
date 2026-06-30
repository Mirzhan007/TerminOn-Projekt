using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminOn.Application.Infrastructur;
using TerminOn.Application.Model;

namespace TerminOn.Test
{
    public class AppointmentContextTest
    {

        private AppointmentContext GetDatabase()
        {
            var connection = new SqliteConnection("Datasource=:memory:");
            connection.Open();

            var opt = new DbContextOptionsBuilder()
                .UseSqlite(connection)
                .Options;


            var db = new AppointmentContext(opt);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            return db;
        }


        [Fact]
        public void CreateDatabaseSuccessTest()
        {
            // Prüft, ob EF Core das Schema fehlerfrei und ohne Absturz generieren kann
            using var db = GetDatabase();
            Assert.True(db.Database.CanConnect());
        }


        [Fact]
        public void AddPatientTest()
        {
            using var db = GetDatabase();

            // Erstellt einen Testpatienten mit einem gültigen Rich Type (10 Stellen)
            var patient = new Patient("Max", "Mustermann", new InsuranceNumber("1234567890"), null);
            db.Patients.Add(patient);
            db.SaveChanges();

            db.ChangeTracker.Clear();

            var patientFromDb = db.Patients.First();
            Assert.True(patientFromDb.Id != 0);
            Assert.Equal("1234567890", patientFromDb.InsuranceNumber.Value);
        }

        [Fact]
        public void InsuranceNummerNotValidTest()
        {
            // Prüft, ob dein Rich Type sofort die geplante Exception wirft, wenn die Nummer zu kurz ist
            Assert.Throws<AppointmentException>(() => new InsuranceNumber("123"));
        }

        [Fact]
        public void PatientCanOnlyHaveOneAppointmentPerDayTest()
        {
            using var db = GetDatabase();

            var patient = new Patient("Max", "Mustermann", new InsuranceNumber("1234567890"), null);
            db.Patients.Add(patient);
            db.SaveChanges();


            var apptype1 = new AppointmentType("Röntgen am Bein", "Blau");
            var apptype2 = new AppointmentType("Operation am Arm", "Rot");

            var location1 = new Location("Röntgenraum", "201F");
            var location2 = new Location("OP-Raum", "305A");

            var resource1 = new Resource("Röntgen", location1);
            var resource2 = new Resource("Operation", location2);

            // Erster Termin am 07.01.2026
            var app1 = new Appointment(new DateOnly(2026, 1, 7), DateTime.Now, patient, apptype1, resource1);
            db.Appointments.Add(app1);
            db.SaveChanges();

            // Zweiter Termin am SELBEN Tag für denselben Patienten -> Muss krachen!
            var app2 = new Appointment(new DateOnly(2026, 1, 7), DateTime.Now, patient, apptype2, resource2);
            db.Appointments.Add(app2);

            // EF Core muss hier eine DbUpdateException werfen, weil der Unique-Index verletzt wird
            Assert.Throws<DbUpdateException>(() => db.SaveChanges());
        }

    }
}
