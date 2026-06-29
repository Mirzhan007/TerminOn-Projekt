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
            db.SaveChanges(); // Schreibt in die In-Memory DB (Value Converter wird aktiv)

            db.ChangeTracker.Clear(); // Cache leeren, um direkt frisch aus der DB zu lesen

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

    }
}
