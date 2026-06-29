using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminOn.Application.Model
{
    public record PhoneNumber
    {
        public string Value { get;}

        public PhoneNumber(string value)
        {
            Value = value;
        }
    }
}
