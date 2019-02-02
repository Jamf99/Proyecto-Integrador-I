using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Workshop_Gmap.model;

namespace Workshop_Gmap
{
    public partial class Principal : Form
    {

        private Statistics model;

        public Principal()
        {
            InitializeComponent();
            model = new Statistics();
            readDataBase();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            map.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            map.SetPositionByKeywords("Bogotá, Colombia");
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        public void readDataBase()
        {

            try { 
                string[] lines = File.ReadAllLines("..\\..\\data.csv");
                MessageBox.Show(lines.Length+"");
                int count = 0;
                foreach(var line in lines)
                {
                    if (count != 0)
                    {
                        var values = line.Split(',');
                        int year = Int32.Parse(values[10]);
                        string gender = values[14];
                        string ocupation = values[22];
                        string civilStatus = values[16];
                        string department = "";
                        int state = Int32.Parse(values[0]);
                        if (state == 17)
                        {
                            department = "Caldas";
                        }
                        else if (state == 76)
                        {
                            department = "Valle del Cauca";
                        }
                        else if (state == 63)
                        {
                            department = "Quindío";
                        }
                        else if (state == 66)
                        {
                            department = "Risaralda";
                        }
                        else if (state == 11)
                        {
                            department = "Bogotá";
                        }
                        else if (state == 25)
                        {
                            department = "Cundinamarca";
                        }
                        else if (state == 5)
                        {
                            department = "Antioquia";
                        }
                        else if (state == 73)
                        {
                            department = "Tolima";
                        }
                        model.addAffected(year, department, gender, ocupation, civilStatus);
                    }
                    count++;
                } 
                
            }
            
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }
        }

        private void showStatistics_Click(object sender, EventArgs e)
        {
            MessageBox.Show(model.Affected.Count+"");
        }
    }
}
