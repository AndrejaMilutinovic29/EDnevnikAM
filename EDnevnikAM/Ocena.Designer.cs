
namespace EDnevnikAM
{
    partial class Ocena
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
            this.cmbGODINA = new System.Windows.Forms.ComboBox();
            this.cmbPROFESOR = new System.Windows.Forms.ComboBox();
            this.cmbPREDMET = new System.Windows.Forms.ComboBox();
            this.cmbODELJENJE = new System.Windows.Forms.ComboBox();
            this.cmbUCENIK = new System.Windows.Forms.ComboBox();
            this.cmbOCENA = new System.Windows.Forms.ComboBox();
            this.Datum = new System.Windows.Forms.DateTimePicker();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnINSERT = new System.Windows.Forms.Button();
            this.btnUPDATE = new System.Windows.Forms.Button();
            this.btnDELETE = new System.Windows.Forms.Button();
            this.dgOCENA = new System.Windows.Forms.DataGridView();
            this.lblGODINA = new System.Windows.Forms.Label();
            this.lblPROFESOR = new System.Windows.Forms.Label();
            this.lblPREDMET = new System.Windows.Forms.Label();
            this.lblODELJENJE = new System.Windows.Forms.Label();
            this.lblUCENIK = new System.Windows.Forms.Label();
            this.lblOCENA = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblDATUM = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgOCENA)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbGODINA
            // 
            this.cmbGODINA.FormattingEnabled = true;
            this.cmbGODINA.Location = new System.Drawing.Point(25, 25);
            this.cmbGODINA.Name = "cmbGODINA";
            this.cmbGODINA.Size = new System.Drawing.Size(121, 21);
            this.cmbGODINA.TabIndex = 0;
            this.cmbGODINA.SelectedValueChanged += new System.EventHandler(this.cmbGODINA_SelectedValueChanged);
            // 
            // cmbPROFESOR
            // 
            this.cmbPROFESOR.FormattingEnabled = true;
            this.cmbPROFESOR.Location = new System.Drawing.Point(166, 25);
            this.cmbPROFESOR.Name = "cmbPROFESOR";
            this.cmbPROFESOR.Size = new System.Drawing.Size(121, 21);
            this.cmbPROFESOR.TabIndex = 1;
            this.cmbPROFESOR.SelectedValueChanged += new System.EventHandler(this.cmbPROFESOR_SelectedValueChanged);
            // 
            // cmbPREDMET
            // 
            this.cmbPREDMET.FormattingEnabled = true;
            this.cmbPREDMET.Location = new System.Drawing.Point(304, 25);
            this.cmbPREDMET.Name = "cmbPREDMET";
            this.cmbPREDMET.Size = new System.Drawing.Size(121, 21);
            this.cmbPREDMET.TabIndex = 2;
            this.cmbPREDMET.SelectedValueChanged += new System.EventHandler(this.cmbPREDMET_SelectedValueChanged);
            // 
            // cmbODELJENJE
            // 
            this.cmbODELJENJE.FormattingEnabled = true;
            this.cmbODELJENJE.Location = new System.Drawing.Point(447, 25);
            this.cmbODELJENJE.Name = "cmbODELJENJE";
            this.cmbODELJENJE.Size = new System.Drawing.Size(121, 21);
            this.cmbODELJENJE.TabIndex = 3;
            this.cmbODELJENJE.SelectedValueChanged += new System.EventHandler(this.cmbODELJENJE_SelectedValueChanged);
            // 
            // cmbUCENIK
            // 
            this.cmbUCENIK.FormattingEnabled = true;
            this.cmbUCENIK.Location = new System.Drawing.Point(25, 75);
            this.cmbUCENIK.Name = "cmbUCENIK";
            this.cmbUCENIK.Size = new System.Drawing.Size(121, 21);
            this.cmbUCENIK.TabIndex = 4;
            // 
            // cmbOCENA
            // 
            this.cmbOCENA.FormattingEnabled = true;
            this.cmbOCENA.Location = new System.Drawing.Point(166, 75);
            this.cmbOCENA.Name = "cmbOCENA";
            this.cmbOCENA.Size = new System.Drawing.Size(121, 21);
            this.cmbOCENA.TabIndex = 5;
            // 
            // Datum
            // 
            this.Datum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Datum.Location = new System.Drawing.Point(447, 76);
            this.Datum.Name = "Datum";
            this.Datum.Size = new System.Drawing.Size(121, 20);
            this.Datum.TabIndex = 6;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(304, 76);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(118, 20);
            this.txtID.TabIndex = 7;
            // 
            // btnINSERT
            // 
            this.btnINSERT.Location = new System.Drawing.Point(595, 23);
            this.btnINSERT.Name = "btnINSERT";
            this.btnINSERT.Size = new System.Drawing.Size(75, 23);
            this.btnINSERT.TabIndex = 8;
            this.btnINSERT.Text = "Dodaj";
            this.btnINSERT.UseVisualStyleBackColor = true;
            this.btnINSERT.Click += new System.EventHandler(this.btnINSERT_Click);
            // 
            // btnUPDATE
            // 
            this.btnUPDATE.Location = new System.Drawing.Point(595, 49);
            this.btnUPDATE.Name = "btnUPDATE";
            this.btnUPDATE.Size = new System.Drawing.Size(75, 23);
            this.btnUPDATE.TabIndex = 9;
            this.btnUPDATE.Text = "Izmeni";
            this.btnUPDATE.UseVisualStyleBackColor = true;
            this.btnUPDATE.Click += new System.EventHandler(this.btnUPDATE_Click);
            // 
            // btnDELETE
            // 
            this.btnDELETE.Location = new System.Drawing.Point(595, 73);
            this.btnDELETE.Name = "btnDELETE";
            this.btnDELETE.Size = new System.Drawing.Size(75, 23);
            this.btnDELETE.TabIndex = 10;
            this.btnDELETE.Text = "Izbrisi";
            this.btnDELETE.UseVisualStyleBackColor = true;
            this.btnDELETE.Click += new System.EventHandler(this.btnDELETE_Click);
            // 
            // dgOCENA
            // 
            this.dgOCENA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOCENA.Location = new System.Drawing.Point(25, 150);
            this.dgOCENA.Name = "dgOCENA";
            this.dgOCENA.Size = new System.Drawing.Size(593, 193);
            this.dgOCENA.TabIndex = 11;
            this.dgOCENA.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOCENA_CellClick);
            // 
            // lblGODINA
            // 
            this.lblGODINA.AutoSize = true;
            this.lblGODINA.Location = new System.Drawing.Point(22, 9);
            this.lblGODINA.Name = "lblGODINA";
            this.lblGODINA.Size = new System.Drawing.Size(44, 13);
            this.lblGODINA.TabIndex = 12;
            this.lblGODINA.Text = "Godina:";
            // 
            // lblPROFESOR
            // 
            this.lblPROFESOR.AutoSize = true;
            this.lblPROFESOR.Location = new System.Drawing.Point(163, 9);
            this.lblPROFESOR.Name = "lblPROFESOR";
            this.lblPROFESOR.Size = new System.Drawing.Size(49, 13);
            this.lblPROFESOR.TabIndex = 13;
            this.lblPROFESOR.Text = "Profesor:";
            // 
            // lblPREDMET
            // 
            this.lblPREDMET.AutoSize = true;
            this.lblPREDMET.Location = new System.Drawing.Point(301, 9);
            this.lblPREDMET.Name = "lblPREDMET";
            this.lblPREDMET.Size = new System.Drawing.Size(49, 13);
            this.lblPREDMET.TabIndex = 14;
            this.lblPREDMET.Text = "Predmet:";
            // 
            // lblODELJENJE
            // 
            this.lblODELJENJE.AutoSize = true;
            this.lblODELJENJE.Location = new System.Drawing.Point(444, 9);
            this.lblODELJENJE.Name = "lblODELJENJE";
            this.lblODELJENJE.Size = new System.Drawing.Size(54, 13);
            this.lblODELJENJE.TabIndex = 15;
            this.lblODELJENJE.Text = "Odeljenje:";
            // 
            // lblUCENIK
            // 
            this.lblUCENIK.AutoSize = true;
            this.lblUCENIK.Location = new System.Drawing.Point(22, 59);
            this.lblUCENIK.Name = "lblUCENIK";
            this.lblUCENIK.Size = new System.Drawing.Size(44, 13);
            this.lblUCENIK.TabIndex = 16;
            this.lblUCENIK.Text = "Ucenik:";
            // 
            // lblOCENA
            // 
            this.lblOCENA.AutoSize = true;
            this.lblOCENA.Location = new System.Drawing.Point(163, 59);
            this.lblOCENA.Name = "lblOCENA";
            this.lblOCENA.Size = new System.Drawing.Size(42, 13);
            this.lblOCENA.TabIndex = 17;
            this.lblOCENA.Text = "Ocena:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(301, 61);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 18;
            this.lblID.Text = "ID:";
            // 
            // lblDATUM
            // 
            this.lblDATUM.AutoSize = true;
            this.lblDATUM.Location = new System.Drawing.Point(444, 59);
            this.lblDATUM.Name = "lblDATUM";
            this.lblDATUM.Size = new System.Drawing.Size(41, 13);
            this.lblDATUM.TabIndex = 19;
            this.lblDATUM.Text = "Datum:";
            // 
            // Ocena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDATUM);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblOCENA);
            this.Controls.Add(this.lblUCENIK);
            this.Controls.Add(this.lblODELJENJE);
            this.Controls.Add(this.lblPREDMET);
            this.Controls.Add(this.lblPROFESOR);
            this.Controls.Add(this.lblGODINA);
            this.Controls.Add(this.dgOCENA);
            this.Controls.Add(this.btnDELETE);
            this.Controls.Add(this.btnUPDATE);
            this.Controls.Add(this.btnINSERT);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.Datum);
            this.Controls.Add(this.cmbOCENA);
            this.Controls.Add(this.cmbUCENIK);
            this.Controls.Add(this.cmbODELJENJE);
            this.Controls.Add(this.cmbPREDMET);
            this.Controls.Add(this.cmbPROFESOR);
            this.Controls.Add(this.cmbGODINA);
            this.Name = "Ocena";
            this.Text = "Ocena";
            this.Load += new System.EventHandler(this.Ocena_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgOCENA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbGODINA;
        private System.Windows.Forms.ComboBox cmbPROFESOR;
        private System.Windows.Forms.ComboBox cmbPREDMET;
        private System.Windows.Forms.ComboBox cmbODELJENJE;
        private System.Windows.Forms.ComboBox cmbUCENIK;
        private System.Windows.Forms.ComboBox cmbOCENA;
        private System.Windows.Forms.DateTimePicker Datum;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnINSERT;
        private System.Windows.Forms.Button btnUPDATE;
        private System.Windows.Forms.Button btnDELETE;
        private System.Windows.Forms.DataGridView dgOCENA;
        private System.Windows.Forms.Label lblGODINA;
        private System.Windows.Forms.Label lblPROFESOR;
        private System.Windows.Forms.Label lblPREDMET;
        private System.Windows.Forms.Label lblODELJENJE;
        private System.Windows.Forms.Label lblUCENIK;
        private System.Windows.Forms.Label lblOCENA;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblDATUM;
    }
}