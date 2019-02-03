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
                item.SubItems.Add(affected.Department.Name);
                item.SubItems.Add(affected.Gender);
                item.SubItems.Add(affected.Ocupation);
                item.SubItems.Add(affected.CivilStatus);
            }
        }

        public void markMap()
        {
            //int[] positions = new int[7];
            //foreach (Affected af in model.Affected)
            //{
            //    if (af.Department.Name.Equals("Caldas"))
            //    {
            //        positions[0]++;
            //    }
            //    else if (af.Department.Name.Equals("Valle del Cauca"))
            //    {
            //        positions[1]++;
            //    }
            //    else if (af.Department.Name.Equals("Quindío"))
            //    {
            //        positions[2]++;
            //    }
            //    else if (af.Department.Name.Equals("Risaralda"))
            //    {
            //        positions[3]++;
            //    }
            //    else if (af.Department.Name.Equals("Bogotá D.C"))
            //    {
            //        positions[4]++;
            //    }
            //    else if (af.Department.Name.Equals("Cundinamarca"))
            //    {
            //        positions[5]++;
            //    }
            //    else if (af.Department.Name.Equals("Antioquia"))
            //    {
            //        positions[6]++;
            //    }
            //    else if (af.Department.Name.Equals("Tolima"))
            //    {
            //        positions[7]++;
            //    }

            //}

            //PointLatLng[] pt = new PointLatLng[7];

            //GMapOverlay markersOverlay = new GMapOverlay("markers");
            //GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(4.598077, -74.0761028),
            //GMarkerGoogleType.blue_small);
            //markersOverlay.Markers.Add(marker);
            //map.Overlays.Add(markersOverlay);
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
