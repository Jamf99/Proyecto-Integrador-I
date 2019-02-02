using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Workshop_Gmap.model;

namespace Workshop_Gmap
{
    public partial class Principal : Form
    {

        private string direction = Environment.CurrentDirectory + @"..\\..\\saved.cfg";

        private Statistics model;

        public Principal()
        {
            InitializeComponent();
            model = new Statistics();
            // readDataBase();
            // saveData();
            read();
            refreshToListView();
            markMap();
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

        public void saveData()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(direction);
            bf.Serialize(file, model);
            file.Close();
        }

        public void read()
        {
            if (!File.Exists(direction))
            {
                return;
            }
            else
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(direction, FileMode.Open);
                Statistics nModel = (Statistics)bf.Deserialize(file);
                file.Close();
                model = nModel;
            }
        }

        public void refreshToListView()
        {
            AffectedListView.Items.Clear();
            foreach (Affected affected in model.Affected)
            {
                ListViewItem item = new ListViewItem();
                item = AffectedListView.Items.Add(affected.Year + "");
                item.SubItems.Add(affected.State);
                item.SubItems.Add(affected.Gender);
                item.SubItems.Add(affected.Ocupation);
                item.SubItems.Add(affected.CivilStatus);
            }
        }

        public void markMap()
        {
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(4.598077, -74.0761028),
            GMarkerGoogleType.blue_small);
            markersOverlay.Markers.Add(marker);
            map.Overlays.Add(markersOverlay);
        }

        public void showStatistics_Click(object sender, EventArgs e)
        {
            
        }


    }
}
