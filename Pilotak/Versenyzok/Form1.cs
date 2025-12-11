using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Versenyzok
{
    public partial class Form1 : Form
    {
        static List<Driver> drivers = new List<Driver>();
        public Form1()
        {
            InitializeComponent();
            #region Beolvasás
            StreamReader sr = null;
            try
            {
                sr = new StreamReader("pilotak.csv");
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string[] sor = sr.ReadLine().Split(';');
                    Driver driver1 = new Driver(sor);
                    drivers.Add(driver1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void Feladat3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += $"3. feladat: {drivers.Count}";
        }

        private void Feladat4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += $"\n4. feladat: {drivers.Last().Name}";
        }

        private void Feladat5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "\n5. feladat:";
            foreach (var item in drivers)
            {
                if (item.Birth < DateTime.Parse("1901.01.01"))
                {
                    richTextBox1.Text += $"\n\t{item.Name} ({item.Birth.ToShortDateString()})";
                }
            }
        }

        private void Feladat6_Click(object sender, EventArgs e)
        {
            Driver driver = drivers[0];
            foreach (var item in drivers)
            {
                if (item.Number < driver.Number && item.Number != null)
                {
                    driver = item;
                }
            }

            richTextBox1.Text += $"\n6. feladat: {driver.Origin}";
        }

        private void Feladat7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "\n7. feladat: ";
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            foreach (var item in drivers)
            {
                if (item.Number != null)
                {
                    if (numbers.ContainsKey(item.Number.Value))
                    {
                        numbers[item.Number.Value]++;
                    }
                    else
                    {
                        numbers.Add(item.Number.Value, 1);
                    }
                }
            }

            foreach (var item in numbers)
            {
                if (item.Value > 1)
                {
                    richTextBox1.Text += item.Key+",  ";
                }
            }
        }
    }
    class Driver
    {
        #region Mezők
        private string name;
        private DateTime birth;
        private string origin;
        private int? number;
        #endregion

        public string Name { get { return name; } set { name = value; } }
        public DateTime Birth { get => birth; set { birth = value; } }
        public string Origin { get => origin;  set { origin = value; } }
        public int? Number { get => number; set { number = value; } }

        public Driver(string[] data)
        {
             this.Name = data[0];
             this.Birth = DateTime.Parse(data[1]);
             this.Origin = data[2];
             if (data[3] != "")
             { 
                this.Number = int.Parse(data[3]);
             }
            else this.Number = null;
        }
    }
}
