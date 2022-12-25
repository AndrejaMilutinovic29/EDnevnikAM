using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EDnevnikAM
{
    public partial class Raspodela : Form
    {
        DataTable raspodela;
        int broj_sloga = 0;
        public Raspodela()
        {
            InitializeComponent();
        }

        private void Load_data()
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Raspodela",veza);
            raspodela = new DataTable();
            adapter.Fill(raspodela);
        }

        private void Raspodela_Load(object sender, EventArgs e)
        {
            Load_data();
            ComboFill();
        }

        private void ComboFill()
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter;
            DataTable dt_godina, dt_nastavnik, dt_predmet, dt_odeljenje;
            adapter = new SqlDataAdapter("SELECT * FROM Skolska_godina",veza);

            dt_godina = new DataTable();
            adapter.Fill(dt_godina);
            cmbGODINA.DataSource = dt_godina;
            cmbGODINA.ValueMember = "id";
            cmbGODINA.DisplayMember = "naziv";
            

            dt_nastavnik = new DataTable();
            adapter = new SqlDataAdapter("SELECT id, ime + prezime as naziv FROM Osoba WHERE uloga =2 ", veza);
            adapter.Fill(dt_nastavnik);
            cmbNASTAVNIK.DataSource = dt_nastavnik;
            cmbNASTAVNIK.ValueMember = "id";
            cmbNASTAVNIK.DisplayMember = "naziv";
            

            dt_predmet = new DataTable();
            adapter = new SqlDataAdapter("SELECT id,naziv FROM Predmet",veza);
            adapter.Fill(dt_predmet);
            cmbPREDMET.DataSource = dt_predmet;
            cmbPREDMET.ValueMember = "id";
            cmbPREDMET.DisplayMember = "naziv";


            dt_odeljenje = new DataTable();
            adapter = new SqlDataAdapter("SELECT id, STR(razred) + ' - ' + indeks as naziv FROM Odeljenje", veza);
            adapter.Fill(dt_odeljenje);
            cmbODELJENJE.DataSource = dt_odeljenje;
            cmbODELJENJE.ValueMember = "id";
            cmbODELJENJE.DisplayMember = "naziv";
          

            txtID.Text = raspodela.Rows[broj_sloga]["id"].ToString();

            if (raspodela.Rows.Count == 0)
            {
                cmbGODINA.SelectedValue = -1;
                cmbNASTAVNIK.SelectedValue = -1;
                cmbPREDMET.SelectedValue = -1;
                cmbODELJENJE.SelectedValue = -1;
            }
            else
            {
                cmbGODINA.SelectedValue = raspodela.Rows[broj_sloga]["godina_id"];
                cmbNASTAVNIK.SelectedValue = raspodela.Rows[broj_sloga]["nastavnik_id"];
                cmbPREDMET.SelectedValue = raspodela.Rows[broj_sloga]["predmet_id"];
                cmbODELJENJE.SelectedValue = raspodela.Rows[broj_sloga]["odeljenje_id"];
            }

            if (broj_sloga == raspodela.Rows.Count - 1)
            {
                btnSLEDECI.Enabled = false;
                btnPOSLEDNJI.Enabled = false;
            }
            else
            {
                btnSLEDECI.Enabled = true;
                btnPOSLEDNJI.Enabled = true;
            }

            if (broj_sloga == 0)
            {
                btnPRETHODNI.Enabled = false;
                btnPRVI.Enabled = false;
            }
            else
            {
                btnPRETHODNI.Enabled = true;
                btnPRVI.Enabled = true;
            }
        }

        private void btnPRVI_Click(object sender, EventArgs e)
        {
            broj_sloga = 0;
            ComboFill();
        }

        private void btnPRETHODNI_Click(object sender, EventArgs e)
        {
            broj_sloga--;
            ComboFill();
        }

        private void btnSLEDECI_Click(object sender, EventArgs e)
        {
            broj_sloga++;
            ComboFill();
        }

        private void btnPOSLEDNJI_Click(object sender, EventArgs e)
        {
            broj_sloga = raspodela.Rows.Count - 1;
            ComboFill();
        }

        private void btnIZBRISI_Click(object sender, EventArgs e)
        {
            string Naredba = "DELETE FROM raspodela WHERE id=" + txtID.Text;
            SqlConnection veza = Konekcija.Connect();
            SqlCommand Komanda = new SqlCommand(Naredba, veza);

            if (broj_sloga < 0) broj_sloga = 0;
            Boolean brisano = false;
            try
            {
                veza.Open();
                Komanda.ExecuteNonQuery();
                veza.Close();
                brisano = true;
            }
            catch (Exception GRESKA)
            {
                MessageBox.Show(GRESKA.Message);
            }

            if (brisano)
            {
                Load_data();
                if (broj_sloga > 0) broj_sloga--;
                ComboFill();
            }
        }

        private void btnDODAJ_Click(object sender, EventArgs e)
        {
            StringBuilder Naredba = new StringBuilder("INSERT INTO raspodela (godina_id, nastavnik_id, predmet_id, odeljenje_id) VALUES('");
            Naredba.Append(cmbGODINA.SelectedValue+ "', '");
            Naredba.Append(cmbNASTAVNIK.SelectedValue + "', '");
            Naredba.Append(cmbPREDMET.SelectedValue + "', '");
            Naredba.Append(cmbODELJENJE.SelectedValue + "')");
            SqlConnection veza = Konekcija.Connect();
            SqlCommand Komanda = new SqlCommand(Naredba.ToString(), veza);
            try
            {
                veza.Open();
                Komanda.ExecuteNonQuery();
                veza.Close();
            }
            catch (Exception GRESKA)
            {
                MessageBox.Show(GRESKA.Message);
            }
            Load_data();
            broj_sloga = raspodela.Rows.Count - 1;
            ComboFill();
        }

        private void btnIZMENI_Click(object sender, EventArgs e)
        {
            StringBuilder Naredba = new StringBuilder("UPDATE Raspodela SET ");
            Naredba.Append("godina_id = '" + cmbGODINA.SelectedValue + "', ");
            Naredba.Append("nastavnik_id = '" + cmbNASTAVNIK.SelectedValue + "', ");
            Naredba.Append("predmet_id = '" + cmbPREDMET.SelectedValue+ "', ");
            Naredba.Append("odeljenje_id = '" + cmbODELJENJE.SelectedValue + "' ");
            Naredba.Append("WHERE id = " + txtID.Text);
            SqlConnection veza = Konekcija.Connect();
            SqlCommand Komanda = new SqlCommand(Naredba.ToString(), veza);
            try
            {
                veza.Open();
                Komanda.ExecuteNonQuery();
                veza.Close();
            }
            catch (Exception GRESKA)
            {
                MessageBox.Show(GRESKA.Message);
            }
            Load_data();
            ComboFill();
        }
    }


}
