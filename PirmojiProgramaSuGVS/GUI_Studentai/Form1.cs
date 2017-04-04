using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Studentai
{
    public partial class Form1 : Form
    {

        const string CFd = "..\\..\\Studentai.txt";
        const string CFr = "..\\..\\Rezultatai.txt";

        Studentai TestasMas;
        Pazymys[] Pazymiai = new Pazymys[10]
        {
            new Pazymys(10, "Puikiai"),
            new Pazymys(9, "Labai gerai"),
            new Pazymys(8, "Gerai"),
            new Pazymys(7, "Vidutiniškai"),
            new Pazymys(6, "Patenkinamai"),
            new Pazymys(5, "Silpnai"),
            new Pazymys(4, "Nepatenkinamai"),
            new Pazymys(3, "Nepatenkinamai"),
            new Pazymys(2, "Nepatenkinamai"),
            new Pazymys(1, "Nepatenkinamai"),
        };

        public Form1()
        {
            InitializeComponent();

            spausdinti.Enabled = false;
            skaiciuoti.Enabled = false;
            rasti.Enabled = false;
        }

        private void pavardeVardas_Click(object sender, EventArgs e)
        {

        }

        private void ivesti_Click(object sender, EventArgs e)
        {

        }

        private void spausdinti_Click(object sender, EventArgs e)
        {

        }

        private void skaiciuoti_Click(object sender, EventArgs e)
        {

        }

        private void rasti_Click(object sender, EventArgs e)
        {

        }

        private void baigti_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
