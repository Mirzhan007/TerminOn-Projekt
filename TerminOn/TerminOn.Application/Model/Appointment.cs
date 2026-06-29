using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminOn.Application.Model
{
    public class Appointment
    {
        #pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Fügen Sie ggf. den „erforderlichen“ Modifizierer hinzu, oder deklarieren Sie den Modifizierer als NULL-Werte zulassend.
        protected Appointment() { }
        #pragma warning restore CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Fügen Sie ggf. den „erforderlichen“ Modifizierer hinzu, oder deklarieren Sie den Modifizierer als NULL-Werte zulassend.

        public Appointment(DateOnly date, DateTime created, Patient patient, AppointmentType appointmentType, Resource resource)
        {
            Date = date;
            Created = created;
            Patient = patient;
            AppointmentType = appointmentType;
            Resource = resource;
        }

        public int Id { get; private set; }

        public DateOnly Date { get; set; }
        public DateTime Created { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        public AppointmentType AppointmentType { get; set; }

        public Resource Resource { get; set; }

        public AppointmentState? CurrentState { get; set; }

   


    }
}
