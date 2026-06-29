using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminOn.Application.Model
{
    public abstract class AppointmentState
    {
        #pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Fügen Sie ggf. den „erforderlichen“ Modifizierer hinzu, oder deklarieren Sie den Modifizierer als NULL-Werte zulassend.
        protected AppointmentState() { }
        #pragma warning restore CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Fügen Sie ggf. den „erforderlichen“ Modifizierer hinzu, oder deklarieren Sie den Modifizierer als NULL-Werte zulassend.


        public AppointmentState(Appointment appointment, DateTime created)
        {
            Appointment = appointment;
            Created = created;
        }

        public int Id { get; private set; }


        public Appointment Appointment { get; set; }

        public DateTime Created { get; set; }

        public string Type { get; set; } = null!;

    }
}
