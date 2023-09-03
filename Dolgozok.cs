using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Configuration;

namespace iktato
{
    public partial class Dolgozok : Form
    {
        private int dolgozo_id;
        readonly string connStr = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;

        public Dolgozok(int dolgozo_id)
        {
            InitializeComponent();
            this.dolgozo_id = dolgozo_id;
        }

        private void Dolgozok_Load(object sender, EventArgs e)
        {
            if (dolgozo_id != 0)
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();

                    string sqlDolgozoAdatai = "select * from dolgozok where id = '" + this.dolgozo_id + "' ";
                    MySqlCommand cmd = new MySqlCommand(sqlDolgozoAdatai, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        vezeteknevTextBox.Text = rdr[1].ToString();
                        keresztnevTextBox.Text = rdr[2].ToString();
                        munkakorTextBox.Text = rdr[3].ToString();                        
                        telefonTextBox.Text = rdr[4].ToString();
                        emailTextBox.Text = rdr[5].ToString();
                    }
                    rdr.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a dolgozó adatainak betöltésekor.\n" + ex.ToString());
                }
            }
        }

        private void mentesButton_Click(object sender, EventArgs e)
        {
            try
            {
                string vezeteknev = vezeteknevTextBox.Text;
                string keresztnev = keresztnevTextBox.Text;
                string munkakor = munkakorTextBox.Text;                
                string telefon = telefonTextBox.Text;
                string email = emailTextBox.Text;

                Dolgozo dolgozo = new Dolgozo(vezeteknev, keresztnev, munkakor, telefon, email);

                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sqlDolgozo = "";

                if (this.dolgozo_id == 0)
                {
                    sqlDolgozo = "insert into dolgozok (vezeteknev, keresztnev, munkakor, telefon, email) values ('" + dolgozo.getVezeteknev() + "', '" + dolgozo.getKeresztnev() + "', '" + dolgozo.getMunkakor() + "', '" + dolgozo.getTelefon() + "', '" + dolgozo.getEmail() + "')";
                }
                else
                {
                    sqlDolgozo = "update dolgozok set vezeteknev = '" + dolgozo.getVezeteknev() + "', keresztnev = '" + dolgozo.getKeresztnev() + "', munkakor = '" + dolgozo.getMunkakor() + "',  telefon = '" + dolgozo.getTelefon() + "', email = '" + dolgozo.getEmail() + "' where id = '" + this.dolgozo_id + "'";
                }

                MySqlCommand cmd = new MySqlCommand(sqlDolgozo, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                kiurit();
                if (this.dolgozo_id == 0)
                {
                    MessageBox.Show("Sikeres felvitel!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sikeres módosítás!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibásan töltötte ki az adatokat, kérem ellenőrizze!\n" + ex.Message);
            }
        }

        private void kiurit()
        {
            vezeteknevTextBox.Text = "";;
            keresztnevTextBox.Text = "";
            munkakorTextBox.Text = "";
            telefonTextBox.Text = "";
            emailTextBox.Text = "";
        }
    }
}
