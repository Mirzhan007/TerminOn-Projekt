using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminOn.Application.Model
{
    public class InsuranceNumber
    {
        
        public InsuranceNumber(string value)
        {
            if(string.IsNullOrEmpty(value) || value.Length != 10)
            {
                throw new AppointmentException("Ungültige Versicherungsnummer!");
            }

            Value = value;
        }

        public string Value { get; }
    }
}
