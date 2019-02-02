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

namespace Workshop_Gmap
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            readDataBase();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            map.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            map.SetPositionByKeywords("Bogotá, Colombia");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        public void readDataBase()
        {
 
            try
            {
                StreamReader sr = new StreamReader("data/dataBase.csv");
                String line = "";
                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    String[] dates = line.Split(new Char[] { ';' });
                    MessageBox.Show(dates[10]);
                    MessageBox.Show("hola");
                    MessageBox.Show(dates[0]);
                    MessageBox.Show(dates[14]);
                    MessageBox.Show(dates[22]);
                    MessageBox.Show(dates[16]);
                }
                sr.Close();
                Thread.Sleep(4000);
            }
            
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
