using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_Gmap.model
{
    [Serializable]
    public class Department
    {
        private string name;
        private double latitude;
        private double longitude;

        public Department(string name, double latitude, double longitude)
        {
            this.name = name;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public string Name { get => name; set => name = value; }
        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
    }
}
