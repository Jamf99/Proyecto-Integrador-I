    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_Gmap.model
{
    [Serializable]
    public class Statistics
    {
        private List<Affected> affected;

        public Statistics()
        {
            affected = new List<Affected>();
        }

        public void addAffected(int year, Department department, string gender, string ocupation, string civilStatus)
        {
            this.affected.Add(new Affected(year, department, gender, ocupation, civilStatus));
        }

        public List<Affected> Affected { get => affected; set => affected = value; }

    }
}
