using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminOn.Application.Model
{
    public class ConfirmedAppointmentState : AppointmentState
    {

        #pragma warning disable CS8618
        protected ConfirmedAppointmentState() { }
        #pragma warning restore CS8618

        public ConfirmedAppointmentState(Doctor doctor, TimeSlot plannedSlot, string infotext, Appointment appointment, DateTime created) : base(appointment, created)
        {
            Doctor = doctor;
            PlannedSlot = plannedSlot;
            Infotext = infotext;
        }

        public Doctor Doctor { get; set; }

        public TimeSlot PlannedSlot { get; set; }

        public string Infotext { get; set; }

    }
}
