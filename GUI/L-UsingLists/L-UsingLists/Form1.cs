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

        private List<Moneta> Monetos1;
        private List<Moneta> Monetos2;
        private List<Moneta> Monetos3;

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
            SkaitytiMonetKont(CFd, out List<Moneta> Monetos1, out List<Moneta> Monetos2);
            Monetos3 = SudarytiNaujaKonteineri(Monetos1, Monetos2);

            ivesti.Enabled = true;
            spausdinti.Enabled = true;
            delete.Enabled = true;
            rasti.Enabled = true;
        }

        private void spausdinti_Click(object sender, EventArgs e)
        {
            SpausdintiMonetKont(CFr, Monetos3, "Monetų kolekcijos sąrašas ");
            rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
        }

        private void skaiciuoti_Click(object sender, EventArgs e)
        {
            Pasalinti(Monetos3);
        }

        private void Pasalinti(List<Moneta> Kolekcija)
        {
            char[] raide = SalisR.Text.ToCharArray();
            for (int i = 0; i < Kolekcija.Count; i++)
            {
                if (raide[0] == Kolekcija[i].Salis[0])
                {

                    for (int j = i; j < Kolekcija.Count - 1; j++)
                    {
                        //Kolekcija.Swap();
                        Kolekcija.Apkeisti(Kolekcija.ImtiMoneta(j), Kolekcija.ImtiMoneta(j + 1));
                    }
                    i--;
                    Kolekcija. = Kolekcija.Kiek - 1;
                }
            }
        }

        private void Rasti_Click(object sender, EventArgs e)
        {
            rezultatai.Text = Monetos1.Pav.ToString() + " bendra monetų vertė:" + RastiSum(Monetos1).ToString() + "\n" + "Sunkiausia moneta:";
            RastiSunkiausia(Monetos1);

            rezultatai.Text = rezultatai.Text + "\n" + Monetos2.Pav.ToString() + " bendra monetų vertė:" + RastiSum(Monetos2).ToString() + "\n" + "Sunkiausia moneta:";
            RastiSunkiausia(Monetos2);
        }

        static int RastiSum(List<Moneta> Kolekcija)
        {
            int sum = 0;
            for (int i = 0; i < Kolekcija.Count; i++)
            {
                sum += Kolekcija[i].Nominalas;
            }
            return sum;
        }

        private void RastiSunkiausia(List<Moneta> Kolekcija)
        {
            int sunkiausia = 0;
            for (int i = 0; i < Kolekcija.Count; i++)
            {
                if (Kolekcija[i].Svoris > sunkiausia)
                {
                    sunkiausia = Kolekcija[i].Svoris;
                }
            }
            for (int i = 0; i < Kolekcija.Count; i++)
            {
                if (Kolekcija[i].Svoris == sunkiausia)
                    rezultatai.Text = rezultatai.Text + "\n" + Kolekcija[i].Salis + " | " + Kolekcija[i].Nominalas + " | " + Kolekcija[i].Svoris;
            }
        }

        private void baigti_Click(object sender, EventArgs e)
        {
            Close();
        }

        static void SkaitytiMonetKont(string fv, out List<Moneta> MonetosKont1, out List<Moneta> MonetosKont2)
        {
            using (StreamReader srautas = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
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
                    MonetosKont1.Add(moneta);
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
                    MonetosKont2.Add(moneta);

                }
            }
        }

        static void SpausdintiMonetKont(string fv, List<Moneta> MonetosKont, string antraste)
        {
            File.Delete(CFr);
            const string virsus = "---------------------------------------------\r\n" + " Pagaminimo Šalis     Nominalas     Svoris \r\n" + "---------------------------------------------";
            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append), Encoding.GetEncoding(1257)))
            {
                fr.WriteLine("\n " + antraste);
                fr.WriteLine(virsus);
                if (MonetosKont.Count == 0)
                {
                    fr.WriteLine("Monetų nėra");
                }
                else
                {
                    for (int i = 0; i < MonetosKont.Count; i++)
                    {
                        Moneta moneta = MonetosKont[i];
                        fr.WriteLine("{0, 3} {1}", i + 1, moneta);
                    }
                    fr.WriteLine("---------------------------------------------\n");
                }
            }
        }

        static int Kiekis(List<Moneta> MonetosKont, int nominalas)
        {
            int kiek = 0;
            for (int i = 0; i < MonetosKont.Count; i++)
            {
                Moneta moneta = MonetosKont[i];
                if (moneta.Nominalas == nominalas)
                    kiek++;
            }
            return kiek;
        }

        static int MonetosIndeksas(List<Moneta> Kolekcija)
        {
            int svoris = 0;
            int suma = 0;
            for (int i = 0; i < Kolekcija.Count; i++)
            {
                Moneta moneta = Kolekcija[i];
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

        private List<Moneta> SudarytiNaujaKonteineri(List<Moneta> Kolekcija1, List<Moneta> Kolekcija2)
        {
            Kolekcija3 = new List;
            for (int i = 0; i < Kolekcija1.Count; i++)
            {
                if (Kolekcija1[i].Nominalas == 1)
                {
                    Kolekcija3.DetiMoneta(Kolekcija1[i]);
                }
            }

            for (int i = 0; i < Kolekcija2.Count; i++)
            {
                if (Kolekcija2[i].Nominalas == 1)
                {
                    Kolekcija3.DetiMoneta(Kolekcija2[i]);
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

        private List<Moneta> surikiuoti(List<Moneta> Kolekcija)
        {

            Moneta temp;
            for (int i = 0; i < Kolekcija.Count; i++)
            {
                for (int n = i; n < Kolekcija.Count; n++)
                {
                    if (Kolekcija[i].Svoris > Kolekcija[i].Svoris)
                    {
                        temp = Kolekcija[i];
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
            SpausdintiMonetKont(CFr, surikiuoti(Monetos3), "Surikiuotos Monetos");
            rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
        }

        private void SalisR_TextChanged(object sender, EventArgs e)
        {

        }

        private void newM_Click(object sender, EventArgs e)
        {
            int max = Int32.Parse(maxnominalas.Text);

            if (Int32.Parse(maxnominalas.Text) >= Int32.Parse(nominalasN.Text))
            {
                Moneta moneta = new Moneta(SalisN.Text, Int32.Parse(nominalasN.Text), Int32.Parse(svorisN.Text));
                Iterpti(Monetos3, moneta);
            }
        }

        private void Iterpti(List<Moneta> Kolekcija, Moneta moneta)
        {
            bool iterpe = false;
            for (int i = 0; i < Kolekcija.Count - 1; i++)
            {
                if (moneta.Svoris >= Kolekcija.ImtiMoneta(i).Svoris && iterpe == false)
                {
                    Kolekcija.Kiek = Kolekcija.Kiek + 1;
                    for (int j = Kolekcija.Kiek - 1; j > i; j--)
                    {
                        Kolekcija.Apkeisti(j, j - 1);
                    }
                    iterpe = true;
                    Kolekcija.DetiTiksliai(moneta, i);
                }
                else if (moneta.Svoris <= Kolekcija.ImtiMoneta(Kolekcija.Kiek - 1).Svoris && iterpe == false)
                {
                    Kolekcija.Kiek = Kolekcija.Kiek + 1;
                    Kolekcija.DetiTiksliai(moneta, Kolekcija.Kiek - 1);
                    break;
                }
            }
        }
    }
}
