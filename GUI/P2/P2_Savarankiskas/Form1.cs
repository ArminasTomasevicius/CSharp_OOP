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

namespace P2_Savarankiskas
{
    public partial class Form1 : Form
    {
        const string CFd = "..\\..\\Studentai.txt"; // duomenų failo vardas
        const string CFn = "..\\..\\Nurodymai.txt"; // nurodymu failo vardas
        const string CFvs = "..\\..\\VertinimoSistema.txt";

        private List<Studentas> StudentuTestas; // studentų objektų masyvas
        private List<Pazymys> Pazymiai;

        public Form1()
        {
            InitializeComponent();


            spausdinti.Enabled = false;
            studentu_sk.Enabled = false;
            studento_ivert.Enabled = false;

           /* StudentuTestas = SkaitytiStudList(CFd);
            SpausdintiStudList(CFr,
            StudentuTestas, "Studentų sąrašas (testo rezultatai)");
            Pazymiai = SkaitytiVertinimoSistemaList(CFvs);
            */// PASTABA: Vertinimo sistema bus vėliau parodyta GVS !!!
            //--------------------------------------------------
        }

        //------------------------------------------------------
        /// <summary>
        /// Skaito duomenis iš failo į dinaminį masyvą.
        /// </summary>
        /// <param name="fv"> duomenų failo vardas </param>
        /// <returns> grąžina dinaminio masyvo nuorodą </returns>
        static List<Studentas> SkaitytiStudList(string fv)
        {
            List<Studentas> StudTestas = new List<Studentas>(); // studentų objektų masyvas
            using (StreamReader srautas = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string eilute; // visa duomenų failo eilutė
                while ((eilute = srautas.ReadLine()) != null)

                {
                    string[] eilDalis = eilute.Split(';');
                    string pavVrd = eilDalis[0];
                    int pazym = int.Parse(eilDalis[1]);
                    Studentas studentas = new Studentas(pavVrd, pazym);
                    StudTestas.Add(studentas);
                }
            }
            return StudTestas;
        }

        static void SpausdintiStudList(string fv, List<Studentas> StudTestas, string antraste)
        {
            const string virsus =
            "-----------------------------------\r\n"
            + " Nr. Pavardė ir vardas Pažymys \r\n"
            + "-----------------------------------";
            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append),
            Encoding.GetEncoding(1257)))
            {
                fr.WriteLine("\n " + antraste);
                fr.WriteLine(virsus);
                for (int i = 0; i < StudTestas.Count; i++)
                {
                    Studentas stud = StudTestas[i];
                    fr.WriteLine("{0, 3} {1}", i + 1, stud);
                }
                fr.WriteLine("-----------------------------------\n");
            }
        }

        static List<Pazymys> SkaitytiVertinimoSistemaList(string fv)
        {
            List<Pazymys> VertSistema = new List<Pazymys>(); // pažymių objektų masyvas
            using (StreamReader srautas = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string eilute; // visa duomenų failo eilutė
                while ((eilute = srautas.ReadLine()) != null)

                {
                    string[] eilDalis = eilute.Split(';');
                    int pazym = int.Parse(eilDalis[0]);
                    string pazReiksme = eilDalis[1];
                    Pazymys pazymys = new Pazymys(pazym, pazReiksme);
                    VertSistema.Add(pazymys);
                }
            }
            return VertSistema;
        }

        static int Kiekis(List<Studentas> StudTestas, int pazymys)
        {
            int kiek = 0;
            for (int i = 0; i < StudTestas.Count; i++)
            {
                Studentas stud = StudTestas[i];
                if (stud.Pazym == pazymys)
                    kiek++;
            }
            return kiek;
        }

        static int StudentoIndeksas(List<Studentas> StudTestas, string pavVrd)
        {
            for (int i = 0; i < StudTestas.Count; i++)
            {
                if (StudTestas[i].PavVrd == pavVrd)
                    return i;
            }
            return -1;
        }

        private void ivesti_Click(object sender, EventArgs e)
        {
            Pazymiai = SkaitytiVertinimoSistemaList(CFvs);
            // Komponento vertinimai užpildymas pažymiais
            foreach (Pazymys paz in Pazymiai)
                vertinimai.Items.Add(paz.ToString());
            vertinimai.SelectedIndex = 0; // parenkama 1-oji reikšmė
                                          // OpenFileDialog komponento savybių nustatymas
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // jeigu pasirinktas failas
            {
                string fv = openFileDialog1.FileName;
                richTextBox1.LoadFile(fv, RichTextBoxStreamType.PlainText);
                StudentuTestas = SkaitytiStudList(fv);
                // Meniu punktų nustatymai
                ivesti.Enabled = false;
                spausdinti.Enabled = true;
                studentu_sk.Enabled = true;
                studento_ivert.Enabled = true;
            }
        }

        private void spausdinti_Click(object sender, EventArgs e)
        {
            // SaveFileDialog komponento savybių nustatymas
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Pasirinkite rezultatų failą";
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK) // jeigu pasirinktas failas
            {
                string fv = saveFileDialog1.FileName;
                // Jeigu reikia rezultatų failas išvalomas
                if (File.Exists(fv))
                    File.Delete(fv);
                SpausdintiStudList(fv, StudentuTestas,
                "Studentų sąrašas (testo rezultatai)");
                //----------------------------------------------------
                // Komponento dataGridView1 užpildymas duomenimis
                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "Nr.";
                dataGridView1.Columns[0].Width = 40;
                dataGridView1.Columns[1].Name = "Pavardė ir vardas";
                dataGridView1.Columns[1].Width = 280;
                dataGridView1.Columns[2].Name = "Pažymys";
                dataGridView1.Columns[2].Width = 80;
                for (int i = 0; i < StudentuTestas.Count; i++)
                {
                    Studentas studentas = StudentuTestas[i];
                    dataGridView1.Rows.Add(i + 1, studentas.PavVrd, studentas.Pazym);
                }
                //----------------------------------------------------
            }
        }

        private void baigti_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void studentu_sk_Click(object sender, EventArgs e)
        {
            string ivertis = vertinimai.SelectedItem.ToString().TrimStart();
            string[] eilDalis = ivertis.Split(' ');
            int pazymys = Int32.Parse(eilDalis[0]);
            int kiekis = Kiekis(StudentuTestas, pazymys);
            if (kiekis > 0)
                rezultatai.Text = "Studentų skaičius: " + kiekis.ToString();
            else
                rezultatai.Text = "Tokių studentų nėra.";
        }

        private void studento_ivert_Click(object sender, EventArgs e)
        {
            string pavVrd = pavardeVrd.Text;
            int index = StudentoIndeksas(StudentuTestas, pavVrd);
            if (index > -1)
            {
                Studentas stud = StudentuTestas[index];
                int pazymys = stud.Pazym;
                pavardeVrd.Text = pavardeVrd.Text + " -> pažymys: " + pazymys.ToString();
            }
            else
                pavardeVrd.Text = pavardeVrd.Text + " -> tokio studento (-ės) nėra.";
        }

        private void uzduotis_Click(object sender, EventArgs e)
        {
            double m_vid = 0;
            double v_vid = 0;

            Lyties_vid(StudentuTestas, out m_vid, out v_vid);

            if (m_vid != 0 && v_vid != 0)
            {
                MessageBox.Show("Vidutinis vyru pazymys: " + v_vid.ToString() + "\n" + "Vidutinis moteru pazymys: " + m_vid.ToString());

            }
            else if (m_vid == 0)
            {
                MessageBox.Show("Vidutinis vyru pazymys: " + v_vid.ToString() + "\n" + "Merginų nėra");
            }
            else if (v_vid == 0)
            {
                MessageBox.Show("Vaikinų nėra " + "\n" + "Vidutinis moteru pazymys: " + m_vid.ToString());
            }
            else
            {
                MessageBox.Show("Vaikinų nėra " + "\n" + "Merginų nėra ");
            }
        }

        private void nurodymai_Click(object sender, EventArgs e)
        {
            richTextBox1.LoadFile(CFn, RichTextBoxStreamType.PlainText);
        }

        static void Lyties_vid(List<Studentas> studentai, out double m_vid, out double v_vid)
        {
            int m = 0;
            double m_sum = 0;

            int v = 0;
            double v_sum = 0;

                for (int i = 0; i < studentai.Count; i++)
                {
                    Studentas stud = studentai[i];
                int len = stud.PavVrd.Length;
                string test = stud.PavVrd[len - 2].ToString() + stud.PavVrd[len -1];
                if (test == "as" || test == "us")
                {
                    v++;
                    v_sum += stud.Pazym;
                }
                else
                {
                    m++;
                    m_sum += stud.Pazym;
                }
            }

            v_vid = v_sum / v;
            m_vid = m_sum / m;

            if (v == 0) { v_vid = 0; }
            if (m == 0) { m_vid = 0; }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
