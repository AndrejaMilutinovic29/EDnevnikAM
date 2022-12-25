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
    public partial class Sifarnik : Form
    {
        DataTable tabela;
        SqlDataAdapter Adapter;
        string imeTABELE;
        public Sifarnik(string tabela)
        {
            imeTABELE = tabela;
            InitializeComponent();
        }

        private void Sifarnik_Load(object sender, EventArgs e)
        {
            Adapter = new SqlDataAdapter("SELECT * FROM " + imeTABELE, Konekcija.Connect());
            tabela = new DataTable();
            Adapter.Fill(tabela);
            dgTABELA.DataSource = tabela;
            dgTABELA.Columns["id"].ReadOnly = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataTable promena = tabela.GetChanges();
            Adapter.UpdateCommand = new SqlCommandBuilder(Adapter).GetUpdateCommand();
            if (promena != null)
            {
                Adapter.Update(promena);
                this.Close();
            }
        }
    }
}
