using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L
{
    public partial class Form1 : Form
    {

        const string CFd = "..\\..\\input.txt";
        const string CFr = "..\\..\\Rezultatai.txt";

        Monetos Kolekcija1;
        Monetos Kolekcija2;
        Monetos Kolekcija3;
  

        public Form1()
        {
            InitializeComponent();

            spausdinti.Enabled = false;
            delete.Enabled = false;
            rasti.Enabled = false;

            if (File.Exists(CFr))
                File.Delete(CFr);

        }

        private void pavardeVardas_Click(object sender, EventArgs e)
        {

        }

        private void ivesti_Click(object sender, EventArgs e)
        {
            rezultatai.LoadFile(CFd, RichTextBoxStreamType.PlainText);
            SkaitytiMonetKont(CFd, out Kolekcija1, out Kolekcija2);
            Kolekcija3 = SudarytiNaujaKonteineri(Kolekcija1, Kolekcija2);

            ivesti.Enabled = true;
            spausdinti.Enabled = true;
            delete.Enabled = true;
            rasti.Enabled = true;
        }

        private void spausdinti_Click(object sender, EventArgs e)
        {
            SpausdintiMonetKont(CFr, Kolekcija3, "Monetų kolekcijos sąrašas ");
            rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
        }

        private void skaiciuoti_Click(object sender, EventArgs e)
        {
            Kolekcija3 = pasalinti(Kolekcija3);
        }

        private Monetos pasalinti(Monetos Kolekcija)
        {
            Monetos naujaKolekcija = new Monetos();
            char[] raide = SalisR.Text.ToCharArray();
            for (int i = 0; i < Kolekcija.Kiek; i++)
            {
                if (raide[0] != Kolekcija.ImtiMoneta(i).Salis[0])
                {
                    naujaKolekcija.DetiMoneta(Kolekcija.ImtiMoneta(i));
                }
                else
                {
                    continue;
                }
            }
            return naujaKolekcija;
        }

        private void rasti_Click(object sender, EventArgs e)
        {
            rezultatai.Text = Kolekcija1.Pav.ToString() + " bendra monetų vertė:" + RastiSum(Kolekcija1).ToString() + "\n" + "Sunkiausia moneta:";
            RastiSunkiausia(Kolekcija1);

            rezultatai.Text = rezultatai.Text + "\n" + Kolekcija2.Pav.ToString() + " bendra monetų vertė:" + RastiSum(Kolekcija2).ToString() + "\n" + "Sunkiausia moneta:";
            RastiSunkiausia(Kolekcija2);
        }

        static int RastiSum(Monetos Kolekcija)
        {
            int sum = 0;
            for (int i = 0; i < Kolekcija.Kiek; i++)
            { 
                sum += Kolekcija.ImtiMoneta(i).Nominalas;
            }
            return sum;
        }

        private void RastiSunkiausia(Monetos Kolekcija)
        {
            int sunkiausia = 0;
            for (int i = 0; i < Kolekcija.Kiek; i++)
            {
                if (Kolekcija.ImtiMoneta(i).Svoris > sunkiausia)
                {
                    sunkiausia = Kolekcija.ImtiMoneta(i).Svoris;
                }
            }
            for (int i = 0; i < Kolekcija.Kiek; i++)
            {
                if (Kolekcija.ImtiMoneta(i).Svoris == sunkiausia)
                    rezultatai.Text = rezultatai.Text + sunkiausia;
            }
        }

        private void baigti_Click(object sender, EventArgs e)
        {
            Close();
        }

        static void SkaitytiMonetKont(string fv, out Monetos MonetosKont1, out Monetos MonetosKont2)
        {
            using (StreamReader srautas = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                MonetosKont1 = new Monetos();
                MonetosKont2 = new Monetos();
                string eilute;

                string pav = srautas.ReadLine();
                MonetosKont1.Pav = pav;
                int km = Int32.Parse(srautas.ReadLine());
                for (int i = 0; i < km; i++)
                {
                    eilute = srautas.ReadLine();
                    string[] eilDalis = eilute.Split(' ');
                    string salis = eilDalis[0];
                    int nominalas = Int32.Parse(eilDalis[1]);
                    int svoris = Int32.Parse(eilDalis[2]);

                    Moneta moneta = new Moneta(salis, nominalas, svoris);
                    MonetosKont1.DetiMoneta(moneta);
                }

                srautas.ReadLine();
                pav = srautas.ReadLine();
                MonetosKont2.Pav = pav;
                km = Int32.Parse(srautas.ReadLine());
                for (int i = 0; i < km; i++)
                {
                    eilute = srautas.ReadLine();
                    string[] eilDalis = eilute.Split(' ');
                    string salis = eilDalis[0];
                    int nominalas = Int32.Parse(eilDalis[1]);
                    int svoris = Int32.Parse(eilDalis[2]);

                    Moneta moneta = new Moneta(salis, nominalas, svoris);
                    MonetosKont2.DetiMoneta(moneta);
           
                }
            }
        }

        static void SpausdintiMonetKont(string fv, Monetos MonetosKont, string antraste)
        {
            File.Delete(CFr);
            const string virsus = "---------------------------------------------\r\n" + " Pagaminimo Šalis     Nominalas     Svoris \r\n" + "---------------------------------------------";
            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append), Encoding.GetEncoding(1257)))
            {
                fr.WriteLine("\n " + antraste);
                fr.WriteLine(virsus);
                for (int i = 0; i < MonetosKont.Kiek; i++)
                {
                    Moneta moneta = MonetosKont.ImtiMoneta(i);
                    fr.WriteLine("{0, 3} {1}", i + 1, moneta);
                }
                fr.WriteLine("---------------------------------------------\n");
            }
        }

        static int Kiekis(Monetos MonetosKont, int nominalas)
        {
            int kiek = 0;
            for (int i = 0; i < MonetosKont.Kiek; i++)
            {
                Moneta moneta = MonetosKont.ImtiMoneta(i);
                if (moneta.Nominalas == nominalas)
                    kiek++;
            }
            return kiek;
        }

        static int MonetosIndeksas(Monetos Kolekcija)
        {
            int svoris = 0;
            int suma = 0;
            for (int i = 0; i < Kolekcija.Kiek; i++)
            {
                Moneta moneta = Kolekcija.ImtiMoneta(i);
                if (moneta.Svoris > svoris)
                {
                    svoris = moneta.Svoris;
                }
                suma += moneta.Svoris;
            }
            return -1;
        }

        private void vertinimai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rezultatai_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private Monetos SudarytiNaujaKonteineri(Monetos Kolekcija1, Monetos Kolekcija2)
        {
            Monetos Kolekcija3 = new Monetos();
            for (int i = 0; i < Kolekcija1.Kiek; i++)
            {
                if (Kolekcija1.ImtiMoneta(i).Nominalas == 1)
                {
                    Kolekcija3.DetiMoneta(Kolekcija1.ImtiMoneta(i));
                }
            }

            for (int i = 0; i < Kolekcija2.Kiek; i++)
            {
                if (Kolekcija2.ImtiMoneta(i).Nominalas == 1)
                {
                    Kolekcija3.DetiMoneta(Kolekcija2.ImtiMoneta(i));
                }
            }

            return Kolekcija3;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private Monetos surikiuoti(Monetos Kolekcija)
        {

            Moneta temp;
            for (int i = 0; i < Kolekcija.Kiek; i++)
            {
                for (int n = i; n < Kolekcija.Kiek; n++)
                {
                    if (Kolekcija.ImtiMoneta(n).Svoris > Kolekcija.ImtiMoneta(i).Svoris)
                    {
                        temp = Kolekcija.ImtiMoneta(n);
                        Kolekcija.DetiTiksliai(Kolekcija.ImtiMoneta(i), n);
                        Kolekcija.DetiTiksliai(temp, i);
                        i--;
                        break;
                    }
                }
            }
            return Kolekcija;
        }

        private void rikiuoti_Click_1(object sender, EventArgs e)
        {
            SpausdintiMonetKont(CFr, surikiuoti(Kolekcija3), "Surikiuotos Monetos");
            rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
        }

        private void SalisR_TextChanged(object sender, EventArgs e)
        {

        }

        private void newM_Click(object sender, EventArgs e)
        {
            int max = Int32.Parse(maxnominalas.Text);

            if (Int32.Parse(maxnominalas.Text) >= Int32.Parse(nominalasN.Text)) {
                Moneta moneta = new Moneta(SalisN.Text, Int32.Parse(nominalasN.Text), Int32.Parse(svorisN.Text));
                Kolekcija3.DetiMoneta(moneta);
            }
        }
    }
}
