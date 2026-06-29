using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminOn.Application.Model
{
    public record Location
    {
        public Location(int pLZ, string city, string address)
        {
            PLZ = pLZ;
            City = city;
            Address = address;
        }

        public int PLZ { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
