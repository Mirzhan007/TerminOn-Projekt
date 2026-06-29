using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminOn.Application.Model
{
    public class Patient
    {

#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Fügen Sie ggf. den „erforderlichen“ Modifizierer hinzu, oder deklarieren Sie den Modifizierer als NULL-Werte zulassend.
        public Patient() { }
#pragma warning restore CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Fügen Sie ggf. den „erforderlichen“ Modifizierer hinzu, oder deklarieren Sie den Modifizierer als NULL-Werte zulassend.



        public Patient(string firstname, string lastname, Insurancenumber insurancenumber, PhoneNumber? mobile)
        {

            Firstname = firstname;
            Lastname = lastname;
            Insurancenumber = insurancenumber;
            Mobile = mobile;
        }



        public int Id { get; private set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Insurancenumber Insurancenumber { get; set; }
        public PhoneNumber? Mobile {  get; set; }

    }
}
