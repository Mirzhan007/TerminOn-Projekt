using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminOn.Application.Model
{
    public record TimeSlot
    {
        public TimeSlot(TimeOnly start, TimeOnly end)
        {
            Start = start;
            End = end;
        }
        public TimeOnly Start {  get; set; }
        public TimeOnly End { get; set; }

    }
}
