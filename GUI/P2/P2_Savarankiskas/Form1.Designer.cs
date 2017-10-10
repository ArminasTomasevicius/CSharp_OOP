namespace P2_Savarankiskas
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.failas = new System.Windows.Forms.ToolStripMenuItem();
            this.ivesti = new System.Windows.Forms.ToolStripMenuItem();
            this.spausdinti = new System.Windows.Forms.ToolStripMenuItem();
            this.baigti = new System.Windows.Forms.ToolStripMenuItem();
            this.skaiciavimai = new System.Windows.Forms.ToolStripMenuItem();
            this.studentu_sk = new System.Windows.Forms.ToolStripMenuItem();
            this.studento_ivert = new System.Windows.Forms.ToolStripMenuItem();
            this.pagalba = new System.Windows.Forms.ToolStripMenuItem();
            this.uzduotis = new System.Windows.Forms.ToolStripMenuItem();
            this.nurodymai = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.vertinimai = new System.Windows.Forms.ComboBox();
            this.rezultatai = new System.Windows.Forms.Label();
            this.pavardeVrd = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failas,
            this.skaiciavimai,
            this.pagalba});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(472, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // failas
            // 
            this.failas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ivesti,
            this.spausdinti,
            this.baigti});
            this.failas.Name = "failas";
            this.failas.Size = new System.Drawing.Size(48, 20);
            this.failas.Text = "Failas";
            // 
            // ivesti
            // 
            this.ivesti.Name = "ivesti";
            this.ivesti.Size = new System.Drawing.Size(152, 22);
            this.ivesti.Text = "Įvestis";
            this.ivesti.Click += new System.EventHandler(this.ivesti_Click);
            // 
            // spausdinti
            // 
            this.spausdinti.Name = "spausdinti";
            this.spausdinti.Size = new System.Drawing.Size(152, 22);
            this.spausdinti.Text = "Spausdinti";
            this.spausdinti.Click += new System.EventHandler(this.spausdinti_Click);
            // 
            // baigti
            // 
            this.baigti.Name = "baigti";
            this.baigti.Size = new System.Drawing.Size(152, 22);
            this.baigti.Text = "Baigti";
            this.baigti.Click += new System.EventHandler(this.baigti_Click);
            // 
            // skaiciavimai
            // 
            this.skaiciavimai.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentu_sk,
            this.studento_ivert});
            this.skaiciavimai.Name = "skaiciavimai";
            this.skaiciavimai.Size = new System.Drawing.Size(84, 20);
            this.skaiciavimai.Text = "Skaičiavimai";
            // 
            // studentu_sk
            // 
            this.studentu_sk.Name = "studentu_sk";
            this.studentu_sk.Size = new System.Drawing.Size(181, 22);
            this.studentu_sk.Text = "Studentų skaičius";
            this.studentu_sk.Click += new System.EventHandler(this.studentu_sk_Click);
            // 
            // studento_ivert
            // 
            this.studento_ivert.Name = "studento_ivert";
            this.studento_ivert.Size = new System.Drawing.Size(181, 22);
            this.studento_ivert.Text = "Studento įvertinimai";
            this.studento_ivert.Click += new System.EventHandler(this.studento_ivert_Click);
            // 
            // pagalba
            // 
            this.pagalba.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uzduotis,
            this.nurodymai});
            this.pagalba.Name = "pagalba";
            this.pagalba.Size = new System.Drawing.Size(61, 20);
            this.pagalba.Text = "Pagalba";
            // 
            // uzduotis
            // 
            this.uzduotis.Name = "uzduotis";
            this.uzduotis.Size = new System.Drawing.Size(188, 22);
            this.uzduotis.Text = "Užduotis";
            this.uzduotis.Click += new System.EventHandler(this.uzduotis_Click);
            // 
            // nurodymai
            // 
            this.nurodymai.Name = "nurodymai";
            this.nurodymai.Size = new System.Drawing.Size(188, 22);
            this.nurodymai.Text = "Nurodymai vartotojui";
            this.nurodymai.Click += new System.EventHandler(this.nurodymai_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(288, 161);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "Čia bus parodyti programos pradiniai duomenys";
            // 
            // vertinimai
            // 
            this.vertinimai.FormattingEnabled = true;
            this.vertinimai.Location = new System.Drawing.Point(306, 27);
            this.vertinimai.Name = "vertinimai";
            this.vertinimai.Size = new System.Drawing.Size(121, 21);
            this.vertinimai.TabIndex = 2;
            // 
            // rezultatai
            // 
            this.rezultatai.AutoSize = true;
            this.rezultatai.Location = new System.Drawing.Point(303, 62);
            this.rezultatai.Name = "rezultatai";
            this.rezultatai.Size = new System.Drawing.Size(127, 13);
            this.rezultatai.TabIndex = 3;
            this.rezultatai.Text = "Čia bus parodyti rezultatai";
            // 
            // pavardeVrd
            // 
            this.pavardeVrd.Location = new System.Drawing.Point(12, 194);
            this.pavardeVrd.Name = "pavardeVrd";
            this.pavardeVrd.Size = new System.Drawing.Size(221, 23);
            this.pavardeVrd.TabIndex = 4;
            this.pavardeVrd.Text = "Čia užrašykite pavardę ir vardą";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 223);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(448, 162);
            this.dataGridView1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 410);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pavardeVrd);
            this.Controls.Add(this.rezultatai);
            this.Controls.Add(this.vertinimai);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failas;
        private System.Windows.Forms.ToolStripMenuItem ivesti;
        private System.Windows.Forms.ToolStripMenuItem spausdinti;
        private System.Windows.Forms.ToolStripMenuItem baigti;
        private System.Windows.Forms.ToolStripMenuItem skaiciavimai;
        private System.Windows.Forms.ToolStripMenuItem studentu_sk;
        private System.Windows.Forms.ToolStripMenuItem studento_ivert;
        private System.Windows.Forms.ToolStripMenuItem pagalba;
        private System.Windows.Forms.ToolStripMenuItem uzduotis;
        private System.Windows.Forms.ToolStripMenuItem nurodymai;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox vertinimai;
        private System.Windows.Forms.Label rezultatai;
        private System.Windows.Forms.RichTextBox pavardeVrd;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

