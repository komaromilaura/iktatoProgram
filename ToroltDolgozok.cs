using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace iktato
{
    public partial class ToroltDolgozok : Form
    {
        readonly string connStr = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;
        int kivalsztottDolgozoId;

        public ToroltDolgozok()
        {
            InitializeComponent();
        }

        private void ToroltDolgozok_Load(object sender, EventArgs e)
        {
            toroltDolgozokDataGridViewFeltoltese();            
        }

        private void toroltDolgozokDataGridViewFeltoltese()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();

                MySqlDataAdapter mDA = new MySqlDataAdapter();
                string sqlToroltDolgozo = "select id as 'ID', vezeteknev as 'Vezetéknév', keresztnev as 'Keresztnév', munkakor as 'Munkakör', telefon as 'Telefon', email as 'Email', torolt as 'Törölt' from dolgozok where torolt = 1";
                mDA.SelectCommand = new MySqlCommand(sqlToroltDolgozo, conn);

                DataTable table = new DataTable();
                mDA.Fill(table);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;

                toroltDolgozokDataGridView.DataSource = bSource;
                if (toroltDolgozokDataGridView.Rows.Count >= 1)
                {
                    kivalsztottDolgozoId = Convert.ToInt32(toroltDolgozokDataGridView.Rows[0].Cells["ID"].FormattedValue.ToString());
                }
                else
                {
                    dolgozoTorlesVisszavonasaButton.Enabled = false;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a törölt dolgozók datagridview feltöltésekor.\n" + ex.Message);
            }
        }

        private void toroltDolgozokDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    kivalsztottDolgozoId = Convert.ToInt32(toroltDolgozokDataGridView.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a dolgozó kiválasztásakor.\n" + ex.Message);
                }
            }
        }

        private void dolgozoTorlesVisszavonasaButton_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sqlDolgozoTorlesVisszavonasa = "update dolgozok set torolt = 0 where id = '" + kivalsztottDolgozoId + "'";
                MySqlCommand cmd = new MySqlCommand(sqlDolgozoTorlesVisszavonasa, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                toroltDolgozokDataGridViewFeltoltese();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kérem válassza ki azt a dolgozót, akinek törölését vissza szeretné vonni!\n" + ex.Message);
            }
        }
    }
}
