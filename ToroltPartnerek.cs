using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace iktato
{
    public partial class ToroltPartnerek : Form
    {
        readonly string connStr = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;
        int kivalsztottPartnerId;

        public ToroltPartnerek()
        {
            InitializeComponent();
        }

        private void ToroltPartnerek_Load(object sender, EventArgs e)
        {
            toroltPartnerekDataGridViewFeltoltese();
        }

        private void toroltPartnerekDataGridViewFeltoltese()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();

                MySqlDataAdapter mDA = new MySqlDataAdapter();
                string sqlToroltPartner = "select id as 'ID', nev as 'Név', iranyitoszam as 'Irányítószám', varos as 'Város', kozterulet as 'Közterület', kozterulet_jellege as 'Közterület jellege', hazszam as 'Házszám', epulet_emelet_ajto as 'Épület, emelet, ajtó', telefon as 'Telefon', email as 'Email', torolt as 'Törölt' from partnerek where torolt = 1";
                mDA.SelectCommand = new MySqlCommand(sqlToroltPartner, conn);

                DataTable table = new DataTable();
                mDA.Fill(table);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;

                toroltPartnerekDataGridView.DataSource = bSource;
                if (toroltPartnerekDataGridView.Rows.Count >= 1)
                {
                    kivalsztottPartnerId = Convert.ToInt32(toroltPartnerekDataGridView.Rows[0].Cells["ID"].FormattedValue.ToString());
                }
                else
                {
                    TorlesVisszavonasButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a törölt parnerek datagridview feltöltésekor.\n" + ex.Message);
            }
        }

        private void toroltPartnerekDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    kivalsztottPartnerId = Convert.ToInt32(toroltPartnerekDataGridView.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a dolgozó kiválasztásakor.\n" + ex.Message);
                }
            }
        }

        private void TorlesVisszavonasButton_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sqlPartnerTorlesVisszavonasa = "update partnerek set torolt = 0 where id = '" + kivalsztottPartnerId + "'";
                MySqlCommand cmd = new MySqlCommand(sqlPartnerTorlesVisszavonasa, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                toroltPartnerekDataGridViewFeltoltese();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kérem válassza ki azt a partnert, akinek törölését vissza szeretné vonni!\n" + ex.Message);
            }
        }
    }
}
