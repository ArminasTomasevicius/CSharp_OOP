using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PirmojiProgramaSuGVS
{
    public partial class Form1 : Form
    {
        int ilgis, plotis, plotas;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ilgis = Convert.ToInt32(textBox1.Text);
            plotis = Convert.ToInt32(textBox2.Text);
            button2.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "Stačiakampio plotas: " + Convert.ToString(Plotas(ilgis, plotis));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        static int Plotas(int ilg, int plot)
        {
           return ilg * plot;
        }
    }
}
