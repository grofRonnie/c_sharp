using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace EU_Mihalics_Miron
{
    public partial class Form1 : Form
    {
        #region class
        internal class EU
        {
            public string Name;
            public DateTime Join;

            public EU(string name, string join)
            {
                Name = name;
                Join = Convert.ToDateTime(join);
            }
        }
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        static List<EU> orszagok = new List<EU>();

        static void Beolvas()
        {

            StreamReader sr = new StreamReader("Eucsatlakozas.txt");

            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                EU ujorszag = new EU(sor[0], sor[1]);
                orszagok.Add(ujorszag);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Beolvas();
            foreach (var i in orszagok)
            {
                richTextBox1.Text += $" Az ország: {i.Name} csatlakozása: {i.Join.ToShortDateString()}\n"; 
            }
        }

        //3. Feladat
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = $"Tagállamok száma: {orszagok.Count} db";
        }
        
        //4. Feladat
        private void button3_Click(object sender, EventArgs e)
        {
            int darab = 0;
            foreach (var i in orszagok)
            {
                if (i.Join.Year == 2007)
                {
                    darab++;
                }
            }
            label2.Text = $"2007-ben {darab} ország csatlakozott.";
        }

        //5. Feladat
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var i in orszagok)
            {
                if (i.Name == "Magyarország")
                {
                    label3.Text = $"Magyarország csatlakozásának dátuma: {i.Join.ToShortDateString()}";
                }
            }
        }

        //6. Feladat
        private void button5_Click(object sender, EventArgs e)
        {
            foreach (var i in orszagok)
            {
                if (i.Join.Month == 5)
                {
                    label4.Text = "Volt májusban csatlakozás";
                }
                else
                {
                    label4.Text = "Nem volt májusban csatlakozás";
                }
            }
        }

        //7. Feladat
        private void button6_Click(object sender, EventArgs e)
        {
            DateTime legkesobbi = DateTime.Parse("1900.01.01");
            foreach (var i in orszagok)
            {
                if (i.Join > legkesobbi)
                {
                    legkesobbi = i.Join;
                }
            }
            label5.Text = $"Legutoljára csatlakozott ország: {legkesobbi.ToShortDateString().ToString()}";
        }

        //8. Feladat
        private void button7_Click(object sender, EventArgs e)
        {
            var stat = orszagok.GroupBy(c => c.Join.Year).OrderBy(d => d.Key);

            foreach (var i in stat)
            {
                label6.Text += $"{i.Key} - {i.Count()} ország\n";
            }
        }
    }
}
