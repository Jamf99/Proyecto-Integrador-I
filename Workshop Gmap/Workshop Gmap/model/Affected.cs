using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_Gmap.model
{
    [Serializable]
    public class Affected
    {
        private Department department;

        private int year;
        private String gender;
        private String ocupation;
        private String civilStatus;

        public Affected(int year, Department department, string gender, string ocupation, string civilStatus)
        {
            this.year = year;
            this.department = department;
            this.gender = gender;
            this.ocupation = ocupation;
            this.civilStatus = civilStatus;
        }

        public int Year { get => year; set => year = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Ocupation { get => ocupation; set => ocupation = value; }
        public string CivilStatus { get => civilStatus; set => civilStatus = value; }
        public Department Department { get => department; set => department = value; }
    }
}
