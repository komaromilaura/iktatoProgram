using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace iktato
{
    public partial class Belepes : Form
    {
        readonly string connStr = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;

        public Belepes()
        {
            InitializeComponent();
        }

        private void megseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void belepButton_Click(object sender, EventArgs e)
        {
            string felhasznalo = felhasznalonevTextBox.Text;
            string titkosJelszo = Titkositas.Encrypt(jelszoTextBox.Text, true);
           
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sql = "select * from felhasznalok where felhasznalonev = '" + felhasznalo + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (!rdr.HasRows)
                {
                    hibaLabel.Text = "Hibás felhasználónév és/vagy jelszó!";
                }

                while (rdr.Read())
                {
                    if (rdr[1].ToString() == titkosJelszo && Convert.ToBoolean(rdr[7]) == true)
                    {
                        var kezdokepernyo = new KezdoKepernyo(felhasznalo);
                        kezdokepernyo.Closed += (s, args) => this.Close();
                        kezdokepernyo.Show();
                        this.Hide();                        
                    }
                    else
                    {
                        hibaLabel.Text = "Hibás felhasználónév és/vagy jelszó!";
                    }
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az adatbázis kapcsolatban.\n" + ex.Message);
            }
        }

        private void felhasznalonevTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            hibaTorles();
        }

        private void hibaTorles()
        {
            hibaLabel.Text = "";
        }

        private void jelszoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            hibaTorles();
        }

        private void jelszoTextBox_Enter(object sender, EventArgs e)
        {
            jelszoTextBox.UseSystemPasswordChar = true;
        }
    }
}
