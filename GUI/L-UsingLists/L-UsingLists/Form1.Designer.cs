namespace L
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
            this.rezultatai = new System.Windows.Forms.RichTextBox();
            this.ivesti = new System.Windows.Forms.Button();
            this.spausdinti = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.rasti = new System.Windows.Forms.Button();
            this.baigti = new System.Windows.Forms.Button();
            this.pavardeVardas = new System.Windows.Forms.Label();
            this.SalisR = new System.Windows.Forms.TextBox();
            this.nominalasN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SalisN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maxnominalas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.svorisN = new System.Windows.Forms.TextBox();
            this.newM = new System.Windows.Forms.Button();
            this.rikiuoti = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rezultatai
            // 
            this.rezultatai.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.rezultatai.Location = new System.Drawing.Point(12, 12);
            this.rezultatai.Name = "rezultatai";
            this.rezultatai.Size = new System.Drawing.Size(407, 154);
            this.rezultatai.TabIndex = 0;
            this.rezultatai.Text = "";
            this.rezultatai.TextChanged += new System.EventHandler(this.rezultatai_TextChanged);
            // 
            // ivesti
            // 
            this.ivesti.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.ivesti.Location = new System.Drawing.Point(12, 172);
            this.ivesti.Name = "ivesti";
            this.ivesti.Size = new System.Drawing.Size(113, 34);
            this.ivesti.TabIndex = 1;
            this.ivesti.Text = "Įvesti";
            this.ivesti.UseVisualStyleBackColor = true;
            this.ivesti.Click += new System.EventHandler(this.ivesti_Click);
            // 
            // spausdinti
            // 
            this.spausdinti.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.spausdinti.Location = new System.Drawing.Point(146, 172);
            this.spausdinti.Name = "spausdinti";
            this.spausdinti.Size = new System.Drawing.Size(123, 34);
            this.spausdinti.TabIndex = 2;
            this.spausdinti.Text = "Spausdinti";
            this.spausdinti.UseVisualStyleBackColor = true;
            this.spausdinti.Click += new System.EventHandler(this.spausdinti_Click);
            // 
            // delete
            // 
            this.delete.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.delete.Location = new System.Drawing.Point(287, 212);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(132, 34);
            this.delete.TabIndex = 3;
            this.delete.Text = "Pašalinti";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.skaiciuoti_Click);
            // 
            // rasti
            // 
            this.rasti.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.rasti.Location = new System.Drawing.Point(287, 172);
            this.rasti.Name = "rasti";
            this.rasti.Size = new System.Drawing.Size(132, 34);
            this.rasti.TabIndex = 4;
            this.rasti.Text = "Rasti";
            this.rasti.UseVisualStyleBackColor = true;
            this.rasti.Click += new System.EventHandler(this.rasti_Click_1);
            // 
            // baigti
            // 
            this.baigti.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.baigti.Location = new System.Drawing.Point(306, 371);
            this.baigti.Name = "baigti";
            this.baigti.Size = new System.Drawing.Size(113, 34);
            this.baigti.TabIndex = 5;
            this.baigti.Text = "Baigti";
            this.baigti.UseVisualStyleBackColor = true;
            this.baigti.Click += new System.EventHandler(this.baigti_Click);
            // 
            // pavardeVardas
            // 
            this.pavardeVardas.AutoSize = true;
            this.pavardeVardas.Font = new System.Drawing.Font("Times New Roman", 10.75F, System.Drawing.FontStyle.Bold);
            this.pavardeVardas.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.pavardeVardas.Location = new System.Drawing.Point(9, 216);
            this.pavardeVardas.Name = "pavardeVardas";
            this.pavardeVardas.Size = new System.Drawing.Size(207, 17);
            this.pavardeVardas.TabIndex = 8;
            this.pavardeVardas.Text = "Šalies pavadinimo pirma raidė:";
            this.pavardeVardas.Click += new System.EventHandler(this.pavardeVardas_Click);
            // 
            // SalisR
            // 
            this.SalisR.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.SalisR.Location = new System.Drawing.Point(216, 214);
            this.SalisR.Name = "SalisR";
            this.SalisR.Size = new System.Drawing.Size(53, 26);
            this.SalisR.TabIndex = 9;
            this.SalisR.TextChanged += new System.EventHandler(this.SalisR_TextChanged);
            // 
            // nominalasN
            // 
            this.nominalasN.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.nominalasN.Location = new System.Drawing.Point(96, 349);
            this.nominalasN.Name = "nominalasN";
            this.nominalasN.Size = new System.Drawing.Size(86, 26);
            this.nominalasN.TabIndex = 10;
            this.nominalasN.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(9, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Naujos Monetos Įvestis";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SalisN
            // 
            this.SalisN.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.SalisN.Location = new System.Drawing.Point(58, 314);
            this.SalisN.Name = "SalisN";
            this.SalisN.Size = new System.Drawing.Size(124, 26);
            this.SalisN.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(9, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Max nominalas:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // maxnominalas
            // 
            this.maxnominalas.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.maxnominalas.Location = new System.Drawing.Point(127, 280);
            this.maxnominalas.Name = "maxnominalas";
            this.maxnominalas.Size = new System.Drawing.Size(38, 26);
            this.maxnominalas.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(9, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Šalis:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(12, 380);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Svoris:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(9, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Nominalas:";
            // 
            // svorisN
            // 
            this.svorisN.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.svorisN.Location = new System.Drawing.Point(72, 378);
            this.svorisN.Name = "svorisN";
            this.svorisN.Size = new System.Drawing.Size(49, 26);
            this.svorisN.TabIndex = 18;
            // 
            // newM
            // 
            this.newM.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.newM.Location = new System.Drawing.Point(188, 371);
            this.newM.Name = "newM";
            this.newM.Size = new System.Drawing.Size(113, 34);
            this.newM.TabIndex = 19;
            this.newM.Text = "Nauja Moneta";
            this.newM.UseVisualStyleBackColor = true;
            this.newM.Click += new System.EventHandler(this.newM_Click);
            // 
            // rikiuoti
            // 
            this.rikiuoti.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.rikiuoti.Location = new System.Drawing.Point(287, 252);
            this.rikiuoti.Name = "rikiuoti";
            this.rikiuoti.Size = new System.Drawing.Size(132, 34);
            this.rikiuoti.TabIndex = 20;
            this.rikiuoti.Text = "Rikiuoti";
            this.rikiuoti.UseVisualStyleBackColor = true;
            this.rikiuoti.Click += new System.EventHandler(this.rikiuoti_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 408);
            this.Controls.Add(this.rikiuoti);
            this.Controls.Add(this.newM);
            this.Controls.Add(this.svorisN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxnominalas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SalisN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nominalasN);
            this.Controls.Add(this.SalisR);
            this.Controls.Add(this.pavardeVardas);
            this.Controls.Add(this.baigti);
            this.Controls.Add(this.rasti);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.spausdinti);
            this.Controls.Add(this.ivesti);
            this.Controls.Add(this.rezultatai);
            this.Name = "Form1";
            this.Text = "Monetos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rezultatai;
        private System.Windows.Forms.Button ivesti;
        private System.Windows.Forms.Button spausdinti;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button rasti;
        private System.Windows.Forms.Button baigti;
        private System.Windows.Forms.Label pavardeVardas;
        private System.Windows.Forms.TextBox SalisR;
        private System.Windows.Forms.TextBox nominalasN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SalisN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox maxnominalas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox svorisN;
        private System.Windows.Forms.Button newM;
        private System.Windows.Forms.Button rikiuoti;
    }
}

