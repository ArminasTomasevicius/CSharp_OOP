using System;
using System.Collections;
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

// 3 failai, zr foto
namespace L
{
    public partial class Form1 : Form
    {

        const string CFd = "..\\..\\input1.txt";
        const string CFf = "..\\..\\input2.txt";
        const string CFg = "..\\..\\input3.txt";
        const string CFr = "..\\..\\Rezultatai.txt";

        private List<Moneta> Monetos1;
        private List<Moneta> Monetos2;
        private List<Moneta> Monetos3;
        private List<Moneta> Papildomas;
        private string pav1;
        private string pav2;
        private string pav3;


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
            SkaitytiMonetKont(CFd, out Monetos1, out pav1);
            SpausdintiMonetKont(CFr, Monetos1, pav1);
            SkaitytiMonetKont(CFf, out Monetos2, out pav2);
            SpausdintiMonetKont(CFr, Monetos2, pav2);
            SkaitytiMonetKont(CFg, out Papildomas, out pav3);
            SpausdintiMonetKont(CFr, Papildomas, pav3);
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
            SpausdintiMonetKont(CFr, Monetos3, "Pasalinus");
        }

        private void Pasalinti(List<Moneta> Kolekcija)
        {
            char[] raide = SalisR.Text.ToCharArray();
            for (int i = 0; i < Kolekcija.Count; i++)
            {
                if (raide[0] == Kolekcija[i].Salis[0])
                {
                    Kolekcija.Remove(Kolekcija[i]);
                    i--;
                }
            }
        }

        static int RastiSum(List<Moneta> Kolekcija)
        {
            int sum = 0;
            for (int i = 0; i < Kolekcija.Count - 1; i++)
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
                if (Kolekcija[i].Svoris > sunkiausia) {
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

        static void SkaitytiMonetKont(string fv, out List<Moneta> MonetosKont1, out string pav1)
        {
            using (StreamReader srautas = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string eilute;
                MonetosKont1 = new List<Moneta>();
                pav1 = srautas.ReadLine();
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
            }
        }

        static void SpausdintiMonetKont(string fv, List<Moneta> MonetosKont, string antraste)
        {
            const string virsus = "---------------------------------------------\r\n" + " Pagaminimo Šalis     Nominalas     Svoris \r\n" + "---------------------------------------------";
            using (var fr = File.AppendText(fv))
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
            List<Moneta> Kolekcija3 = new List<Moneta>();
            for (int i = 0; i < Kolekcija1.Count; i++)
            {
                if (Kolekcija1[i].Nominalas == 1)
                {
                    Kolekcija3.Add(Kolekcija1[i]);
                }
            }

            for (int i = 0; i < Kolekcija2.Count; i++)
            {
                if (Kolekcija2[i].Nominalas == 1)
                {
                    Kolekcija3.Add(Kolekcija2[i]);
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

        private List<Moneta> Surikiuoti(List<Moneta> Kolekcija)
        {

           Kolekcija.Sort((x, y) => y.Svoris.CompareTo(x.Svoris));
            return Kolekcija;
        }

        private void rikiuoti_Click_1(object sender, EventArgs e)
        {
            SpausdintiMonetKont(CFr, Surikiuoti(Monetos3), "Surikiuotos Monetos");
            rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
        }

        private void SalisR_TextChanged(object sender, EventArgs e)
        {

        }

        private void newM_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < Papildomas.Count; i++)
            {
                if (Int32.Parse(maxnominalas.Text) >= Papildomas[i].Nominalas)
                {

                    Moneta moneta = new Moneta(Papildomas[i].Salis, Papildomas[i].Nominalas, Papildomas[i].Svoris);
                    Iterpti(Monetos3, moneta);
                }
            }
            SpausdintiMonetKont(CFr, Monetos3, "Papildytas konteineris");
        }

        private void Iterpti(List<Moneta> Kolekcija, Moneta moneta)
        {
            bool iterpe = false;
            if (Kolekcija.Count == 0)
            {
                iterpe = true;
                Kolekcija.Add(moneta);
            }
            for (int i = 0; i < Kolekcija.Count; i++)
            {
                if (moneta.Svoris >= Kolekcija[i].Svoris && iterpe == false)
                {
                    iterpe = true;
                    Kolekcija.Insert(i, moneta);
                    break;
                }
              
            }

            for (int i = 0; i < Kolekcija.Count; i++)
            {
                if (moneta.Svoris <= Kolekcija[i].Svoris && iterpe == false)
                {
                    iterpe = true;
                    Kolekcija.Add(moneta);
                    break;
                }
            }
        }

        private void Apkeisti(Moneta Kolekcija, Moneta Kolekcija1)
        {

        }

        private void rasti_Click_1(object sender, EventArgs e)
        {
            rezultatai.Text = pav1 + " bendra monetų vertė:" + RastiSum(Monetos1).ToString() + "\n" + "Sunkiausia moneta:";
            RastiSunkiausia(Monetos1);


            rezultatai.Text = rezultatai.Text + "\n" + pav2 + " bendra monetų vertė:" + RastiSum(Monetos2).ToString() + "\n" + "Sunkiausia moneta:";
            RastiSunkiausia(Monetos2);
        }
    }
}
