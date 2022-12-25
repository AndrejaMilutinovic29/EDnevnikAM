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
    public partial class Osoba : Form
    {
        int broj_sloga = 0;
        DataTable tabela;
        public Osoba()
        {
            InitializeComponent();
        }
        private void Load_Data()
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Osoba", veza);
            tabela = new DataTable();
            adapter.Fill(tabela);
        }

        private void Txt_Load()
        {
            if (tabela.Rows.Count == 0)
            {
                txtID.Text = "";
                txtIME.Text = "";
                txtPREZIME.Text = "";
                txtADRESA.Text = "";
                txtJMBG.Text = "";
                txtEMAIL.Text = "";
                txtPASSWORD.Text = "";
                txtULOGA.Text = "";
                btnIZBRISI.Enabled = false;
            }
            else
            {
                txtID.Text = tabela.Rows[broj_sloga]["id"].ToString();
                txtIME.Text = tabela.Rows[broj_sloga]["ime"].ToString();
                txtPREZIME.Text = tabela.Rows[broj_sloga]["prezime"].ToString();
                txtADRESA.Text = tabela.Rows[broj_sloga]["adresa"].ToString();
                txtJMBG.Text = tabela.Rows[broj_sloga]["jmbg"].ToString();
                txtEMAIL.Text = tabela.Rows[broj_sloga]["email"].ToString();
                txtPASSWORD.Text = tabela.Rows[broj_sloga]["pass"].ToString();
                txtULOGA.Text = tabela.Rows[broj_sloga]["uloga"].ToString();
                btnIZBRISI.Enabled = true;
            }

            if (broj_sloga == tabela.Rows.Count - 1)
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
        private void Osoba_Load(object sender, EventArgs e)
        {
            Load_Data();
            Txt_Load();
        }

        private void btnPRVI_Click(object sender, EventArgs e)
        {
            broj_sloga = 0;
            Txt_Load();
        }

        private void btnPRETHODNI_Click(object sender, EventArgs e)
        {
            broj_sloga--;
            Txt_Load();
        }

        private void btnSLEDECI_Click(object sender, EventArgs e)
        {
            broj_sloga++;
            Txt_Load();
        }

        private void btnPOSLEDNJI_Click(object sender, EventArgs e)
        {
            broj_sloga = tabela.Rows.Count - 1;
            Txt_Load();
        }

        private void btnDODAJ_Click(object sender, EventArgs e)
        {
            StringBuilder Naredba = new StringBuilder("INSERT INTO osoba (ime, prezime, adresa, jmbg, email, pass, uloga)VALUES('");
            Naredba.Append(txtIME.Text + "', '");
            Naredba.Append(txtPREZIME.Text + "', '");
            Naredba.Append(txtADRESA.Text + "', '");
            Naredba.Append(txtJMBG.Text + "', '");
            Naredba.Append(txtEMAIL.Text + "', '");
            Naredba.Append(txtPASSWORD.Text + "', '");
            Naredba.Append(txtULOGA.Text + "')");
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
            Load_Data();
            broj_sloga = tabela.Rows.Count - 1;
            Txt_Load();

        }

        private void btnIZMENI_Click(object sender, EventArgs e)
        {
            StringBuilder Naredba = new StringBuilder("UPDATE Osoba SET ");
            Naredba.Append("ime = '" + txtIME.Text + "', ");
            Naredba.Append("prezime = '" + txtPREZIME.Text + "', ");
            Naredba.Append("adresa = '" + txtADRESA.Text + "', ");
            Naredba.Append("jmbg = '" + txtJMBG.Text + "', ");
            Naredba.Append("email = '" + txtEMAIL.Text + "', ");
            Naredba.Append("pass = '" + txtPASSWORD.Text + "', ");
            Naredba.Append("uloga = '" + txtULOGA.Text + "' ");
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
            Load_Data();
            Txt_Load();
        }

        private void btnIZBRISI_Click(object sender, EventArgs e)
        {
            string Naredba = "DELETE FROM osoba WHERE id=" + txtID.Text;
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
                Load_Data();
                if (broj_sloga > 0) broj_sloga--;
                Txt_Load();
            }
        }
    }
}
