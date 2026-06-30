using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminOn.Application.Model
{
    public class CancelledAppointmentState : AppointmentState
    {

        protected CancelledAppointmentState() { }

        public CancelledAppointmentState(Appointment appointment, DateTime created, string? reason) : base(appointment, created)
        {
            Reason = reason;
        }

        public string? Reason { get; set; }
    }
}
