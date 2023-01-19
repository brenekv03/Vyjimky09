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

namespace Vyjimky09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("Cisla.dat", FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(10);
            bw.Write(5);
            bw.Write(5);
            bw.Write(1);
            bw.Write(2);
            bw.Write(3);
            bw.Write(4);
            bw.Close();
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                int n = int.Parse(textBox1.Text);
                int sc = 0;
                int pc = 0;
                try
                {
                    using (FileStream fs = new FileStream("Cisla.dat", FileMode.Open, FileAccess.Read))
                    {
                        BinaryReader br = new BinaryReader(fs);
                        {
                            try
                            {
                                for (int i = 0; i < n; i++)
                                {
                                    checked(int cislo = br.ReadInt32());
                                    listBox1.Items.Add(cislo);
                                    sc += cislo;
                                    pc++;
                                }
                            }
                            catch
                            {
                            }
                        }
                        fs.Close();
                    }
                    MessageBox.Show("Aritmetický průměr je : "+(double)sc / pc + " Počet: " + pc + " Součet: " + sc);
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Nenalezený soubor");
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Špatně zadaná čísla");
            }
        }
    }
}
