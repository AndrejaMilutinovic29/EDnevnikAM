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
    public partial class Ocena : Form
    {
        SqlConnection veza = Konekcija.Connect();
        DataTable dt_ocena;
        public Ocena()
        {
            InitializeComponent();
        }

        private void Ocena_Load(object sender, EventArgs e)
        {
            cmbGODINAPopulate();
            cmbPREDMET.Enabled = false;
            cmbOCENA.Items.Add(1);
            cmbOCENA.Items.Add(2);
            cmbOCENA.Items.Add(3);
            cmbOCENA.Items.Add(4);
            cmbOCENA.Items.Add(5);
            cmbODELJENJE.Enabled = false;
            cmbUCENIK.Enabled = false;
            cmbOCENA.Enabled = false;
            cmbPROFESORPopulate();
        }

        private void cmbGODINAPopulate()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM skolska_godina", veza);
            DataTable dt_godina = new DataTable();
            adapter.Fill(dt_godina);
            cmbGODINA.DataSource = dt_godina;
            cmbGODINA.ValueMember = "id";
            cmbGODINA.DisplayMember = "naziv";
            cmbGODINA.SelectedValue = 2;
        }

        private void cmbPROFESORPopulate()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT osoba.id AS id, ime + ' ' + prezime AS naziv from osoba join raspodela on osoba.id = nastavnik_id WHERE godina_id = " + cmbGODINA.SelectedValue.ToString(), veza);
            DataTable dt_profesor = new DataTable();
            adapter.Fill(dt_profesor);
            cmbPROFESOR.DataSource = dt_profesor;
            cmbPROFESOR.ValueMember = "id";
            cmbPROFESOR.DisplayMember = "naziv";
            cmbPROFESOR.SelectedValue = -1;
        }

        private void cmbPREDMETPopulate()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT predmet.id as id, naziv from predmet JOIN raspodela on predmet.id = predmet_id where godina_id = " + cmbGODINA.SelectedValue.ToString() + "and nastavnik_id = " + cmbPROFESOR.SelectedValue.ToString(), veza);
            DataTable dt_predmet = new DataTable();
            adapter.Fill(dt_predmet);
            cmbPREDMET.DataSource = dt_predmet;
            cmbPREDMET.ValueMember = "id";
            cmbPREDMET.DisplayMember = "naziv";
            cmbPREDMET.SelectedValue = -1;
        }
        private void cmbODELJENJEPopulate()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT odeljenje.id AS id, str(razred) + '-' + indeks as naziv FROM odeljenje JOIN raspodela on odeljenje.id = odeljenje_id WHERE raspodela.godina_id = " + cmbGODINA.SelectedValue.ToString() + "and nastavnik_id = " + cmbPROFESOR.SelectedValue.ToString() + "and predmet_id = " + cmbPREDMET.SelectedValue.ToString(), veza);
            DataTable dt_odeljenje = new DataTable();
            adapter.Fill(dt_odeljenje);
            cmbODELJENJE.DataSource = dt_odeljenje;
            cmbODELJENJE.ValueMember = "id";
            cmbODELJENJE.DisplayMember = "naziv";
            cmbODELJENJE.SelectedValue = -1;
        }

        private void cmbUCENIKPopulate()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT osoba.id AS id, ime + ' ' + prezime AS naziv FROM osoba JOIN upisnica ON osoba.id = osoba_id WHERE upisnica.odeljenje_id = " + cmbODELJENJE.SelectedValue.ToString(), veza);
            DataTable dt_ucenik = new DataTable();
            adapter.Fill(dt_ucenik);
            cmbUCENIK.DataSource = dt_ucenik;
            cmbUCENIK.ValueMember = "id";
            cmbUCENIK.DisplayMember = "naziv";
            cmbUCENIK.SelectedValue = -1;
        }

        public void GridPopulate()
        {
           SqlDataAdapter adapter = new SqlDataAdapter("SELECT ocena.id AS id, ime + ' ' + prezime AS naziv, ocena, ucenik_id, datum FROM osoba JOIN ocena ON osoba.id = ucenik_id JOIN raspodela ON raspodela_id = raspodela.id WHERE raspodela_id = (SELECT id FROM raspodela WHERE godina_id = " + cmbGODINA.SelectedValue.ToString() + "and nastavnik_id = " + cmbPROFESOR.SelectedValue.ToString() + " and predmet_id = " + cmbPREDMET.SelectedValue.ToString() + " and odeljenje_id = " + cmbODELJENJE.SelectedValue.ToString() + ")", veza);
            dt_ocena = new DataTable();
            adapter.Fill(dt_ocena);
            dgOCENA.DataSource = dt_ocena;
            dgOCENA.AllowUserToAddRows = false;
            dgOCENA.Columns["ucenik_id"].Visible = false;
        }
        private void cmbGODINA_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbGODINA.IsHandleCreated && cmbGODINA.Focused)
            {
                cmbPROFESORPopulate();
            }
        }

        private void cmbPROFESOR_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPROFESOR.IsHandleCreated && cmbPROFESOR.Focused)
            {
                cmbPREDMETPopulate();
                cmbPREDMET.Enabled = true;

                cmbODELJENJE.SelectedIndex = -1;
                cmbODELJENJE.Enabled = false;

                cmbUCENIK.SelectedIndex = -1;
                cmbUCENIK.Enabled = false;

                cmbOCENA.SelectedIndex = -1;
                cmbOCENA.Enabled = false;

                dt_ocena = new DataTable();
                dgOCENA.DataSource = dt_ocena;
            }
        }



        private void cmbPREDMET_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPREDMET.IsHandleCreated && cmbPREDMET.Focused)
            {
                cmbODELJENJEPopulate();
                cmbODELJENJE.Enabled = true;

                cmbUCENIK.SelectedIndex = -1;
                cmbUCENIK.Enabled = false;

                cmbOCENA.SelectedIndex = -1;
                cmbOCENA.Enabled = false;

                dt_ocena = new DataTable();
                dgOCENA.DataSource = dt_ocena;
            }
        }

        private void cmbODELJENJE_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbODELJENJE.IsHandleCreated && cmbODELJENJE.Focused)
            {
                cmbUCENIKPopulate();
                cmbUCENIK.Enabled = true;
                GridPopulate();
                UcenikOcenaIDSet(0);
                cmbOCENA.Enabled = true;

            }
        }

        private void dgOCENA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                UcenikOcenaIDSet(e.RowIndex);
            }
        }

        public void UcenikOcenaIDSet(int broj_sloga)
        {
            cmbUCENIK.SelectedValue = dt_ocena.Rows[broj_sloga]["ucenik_id"];
            cmbOCENA.SelectedItem = dt_ocena.Rows[broj_sloga]["ocena"];
            txtID.Text = dt_ocena.Rows[broj_sloga]["id"].ToString();
        }

        private void btnINSERT_Click(object sender, EventArgs e)
        {
            SqlCommand naredba = new SqlCommand("SELECT ID FROM raspodela WHERE godina_id = " + cmbGODINA.SelectedValue.ToString()+ " and nastavnik_id = " + cmbPROFESOR.SelectedValue.ToString() + "and predmet_id = " + cmbPREDMET.SelectedValue.ToString()+ " and odeljenje_id = " + cmbODELJENJE.SelectedValue.ToString(), veza);
            int id_raspodela = 0;
            try
            {
                veza.Open();
                id_raspodela = (int)naredba.ExecuteScalar();
                veza.Close();
            }
            catch (Exception Greska)
            {
                MessageBox.Show(Greska.Message);
            }

            if (id_raspodela > 0)
            {
                DateTime datum = Datum.Value;
                SqlCommand naredba1 = new SqlCommand("INSERT INTO ocena (datum, raspodela_id, ucenik_id, ocena) values( '"+ datum.ToString("yyyy-MM-dd") + "', '"+ id_raspodela.ToString() + "', '"+ cmbUCENIK.SelectedValue.ToString() + "', '" + cmbOCENA.SelectedItem.ToString() + "')", veza);
                try
                {
                    veza.Open();
                    naredba1.ExecuteNonQuery();
                    veza.Close();
                }
                catch (Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
            }

            GridPopulate();

        }

        private void btnUPDATE_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtID.Text) > 0)
            {
                DateTime datum = Datum.Value;
                SqlCommand naredba = new SqlCommand("UPDATE ocena SET  ucenik_id = '" + cmbUCENIK.SelectedValue.ToString() + "', ocena = '" + cmbOCENA.SelectedItem.ToString() + "', datum = '" + datum.ToString("yyyy-MM-dd") + "' WHERE id = " + txtID.Text, veza);
                try
                {
                    veza.Open();
                    naredba.ExecuteNonQuery();
                    veza.Close();
                }
                catch (Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
            }
            GridPopulate();
        }

        private void btnDELETE_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtID.Text) > 0)
            {
                SqlCommand komanda = new SqlCommand("DELETE FROM ocena WHERE id = " + txtID.Text, veza);
                try
                {
                    veza.Open();
                    komanda.ExecuteNonQuery();
                    veza.Close();
                    GridPopulate();
                    UcenikOcenaIDSet(0);
                }
                catch (Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
            }
        }
    }
  }


  




  



