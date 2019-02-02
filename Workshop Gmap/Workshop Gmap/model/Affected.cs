using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_Gmap.model
{
    public class Affected
    {
        public const String MALE = "Male";
        public const String FEMALE = "Female";

        private int year;
        private String state;
        private String gender;
        private String ocupation;
        private String civilStatus;

        public Affected(int year, string state, string gender, string ocupation, string civilStatus)
        {
            this.year = year;
            this.state = state;
            this.gender = gender;
            this.ocupation = ocupation;
            this.civilStatus = civilStatus;
        }

        public int Year { get => year; set => year = value; }
        public string State { get => state; set => state = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Ocupation { get => ocupation; set => ocupation = value; }
        public string CivilStatus { get => civilStatus; set => civilStatus = value; }

    }
}
