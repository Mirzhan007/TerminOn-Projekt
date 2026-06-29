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

        public CancelledAppointmentState(Appointment appointment, DateTime created) : base(appointment, created)
        {
        }
    }
}
