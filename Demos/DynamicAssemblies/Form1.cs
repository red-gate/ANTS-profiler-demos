using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.IO;

namespace DynamicAssemblies
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            int numberToCreate = 0;
            numberToCreate = (int)numericUpDown1.Value;

            for (int i = 1; i <= numberToCreate; i++)
            {
                makeSerializer();
            }

            int totalCreated = Convert.ToInt32(label3.Text);
            totalCreated += numberToCreate;
            label3.Text = totalCreated.ToString();
        }

        private void makeSerializer()
        {
            Type[] extraTypes = new Type[1];
            extraTypes[0] = typeof(PointlessType);

            XmlSerializer serializer = new XmlSerializer(typeof(SolarSystem), extraTypes);
            SolarSystem solarSystem;

            using (XmlReader reader = XmlReader.Create(Directory.GetCurrentDirectory() + "/App_Data/Planets.xml"))
            {
                solarSystem = (SolarSystem)serializer.Deserialize(reader);
            }
        }
    }

    public class PointlessType
    {
        public int pointless;
    }
}