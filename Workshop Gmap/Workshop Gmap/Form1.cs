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

        //private string direction = Environment.CurrentDirectory + @"..\\..\\saved.cfg";

        private Statistics model;

        public Principal()
        {
            InitializeComponent();
            model = new Statistics();
            //readDataBase();
            //saveData();
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
                        Department department = null;
                        int state = Int32.Parse(values[0]);
                        if (state == 17)
                        {
                            department = new Department("Caldas", 5.3302514, -75.2873471);
                        }
                        else if (state == 76)
                        {
                            department = new Department("Valle del Cauca", 4.06397, -76.12338);
                        }
                        else if (state == 63)
                        {
                            department = new Department("Quindío", 4.3435926, -75.7232898);
                        }
                        else if (state == 66)
                        {
                            department = new Department("Risaralda", 5.2102948, -75.9842236);
                        }
                        else if (state == 11)
                        {
                            department = new Department("Bogotá D.C", 4.5980772, -74.0761028);
                        }
                        else if (state == 25)
                        {
                            department = new Department("Cundinamarca", 5.0000086, -74.1666756);
                        }
                        else if (state == 5)
                        {
                            department = new Department("Antioquia", 7.0000085, -75.5000086);
                        }
                        else if (state == 73)
                        {
                            department = new Department("Tolima", 3.7500086, -75.2500086);
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
            FileStream file = File.OpenWrite("..\\..\\ejemplo.txt");
            bf.Serialize(file, model);
            file.Close();
        }

        public void read()
        {
            if (!File.Exists("..\\..\\ejemplo.txt"))
            {
                return;
            }
            else
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open("..\\..\\ejemplo.txt", FileMode.Open);
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
                item.SubItems.Add(affected.Department.Name);
                item.SubItems.Add(affected.Gender);
                item.SubItems.Add(affected.Ocupation);
                item.SubItems.Add(affected.CivilStatus);
            }
        }

        public void markMap()
        {
            PointLatLng point1 = new PointLatLng(5.3302514, -75.2873471);
            GMapMarker mark1 = new GMarkerGoogle(point1, GMarkerGoogleType.red_dot);
            GMapOverlay marker1 = new GMapOverlay("marker");
            marker1.Markers.Add(mark1);
            map.Overlays.Add(marker1);

            PointLatLng point2 = new PointLatLng(4.06397, -76.12338);
            GMapMarker mark2 = new GMarkerGoogle(point2, GMarkerGoogleType.orange_small);
            GMapOverlay marker2 = new GMapOverlay("marker");
            marker2.Markers.Add(mark2);
            map.Overlays.Add(marker2);

            PointLatLng point3 = new PointLatLng(4.3435926, -75.7232898);
            GMapMarker mark3 = new GMarkerGoogle(point3, GMarkerGoogleType.blue_small);
            GMapOverlay marker3 = new GMapOverlay("marker");
            marker3.Markers.Add(mark3);
            map.Overlays.Add(marker3);

            PointLatLng point4 = new PointLatLng(5.2102948, -75.9842236);
            GMapMarker mark4 = new GMarkerGoogle(point4, GMarkerGoogleType.yellow_small);
            GMapOverlay marker4 = new GMapOverlay("marker");
            marker4.Markers.Add(mark4);
            map.Overlays.Add(marker4);

            PointLatLng point5 = new PointLatLng(4.5980772, -74.0761028);
            GMapMarker mark5 = new GMarkerGoogle(point5, GMarkerGoogleType.purple_small);
            GMapOverlay marker5 = new GMapOverlay("marker");
            marker5.Markers.Add(mark5);
            map.Overlays.Add(marker5);

            PointLatLng point6 = new PointLatLng(5.0000086, -74.1666756);
            GMapMarker mark6 = new GMarkerGoogle(point6, GMarkerGoogleType.green_small);
            GMapOverlay marker6 = new GMapOverlay("marker");
            marker6.Markers.Add(mark6);
            map.Overlays.Add(marker6);

            PointLatLng point7 = new PointLatLng(7.0000085, -75.5000086);
            GMapMarker mark7 = new GMarkerGoogle(point7, GMarkerGoogleType.gray_small);
            GMapOverlay marker7 = new GMapOverlay("marker");
            marker7.Markers.Add(mark7);
            map.Overlays.Add(marker7);

            PointLatLng point8 = new PointLatLng(3.7500086, -75.2500086);
            GMapMarker mark8 = new GMarkerGoogle(point8, GMarkerGoogleType.white_small);
            GMapOverlay marker8 = new GMapOverlay("marker");
            marker8.Markers.Add(mark8);
            map.Overlays.Add(marker8);
        }

        public void showStatistics_Click(object sender, EventArgs e)
        {
            Stats stats = new Stats();
            stats.ShowDialog();
        }

        private void recomendations_Click(object sender, EventArgs e)
        {
            Recomendations r = new Recomendations();
            r.ShowDialog();
        }
    }
}
