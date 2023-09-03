using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace iktato
{
    public partial class Partnerek : Form
    {
        private int partner_id;
        readonly string connStr = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;

        public Partnerek(int partner_id)
        {
            InitializeComponent();
            this.partner_id = partner_id;
        }

        private void Partnerek_Load(object sender, EventArgs e)
        {
            if (partner_id != 0)
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();

                    string sqlPartnerAdatai = "select * from partnerek where id = '" + this.partner_id + "' ";
                    MySqlCommand cmd = new MySqlCommand(sqlPartnerAdatai, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        nevTextBox.Text = rdr[1].ToString();
                        iranyitoszamTextBox.Text = rdr[2].ToString();
                        varosTextBox.Text = rdr[3].ToString();
                        kozteruletTextBox.Text = rdr[4].ToString();
                        kozteruletJellegeTextBox.Text = rdr[5].ToString();
                        hazszamTextBox.Text = rdr[6].ToString();
                        epEmAjtoTextBox.Text = rdr[7].ToString();
                        telefonTextBox.Text = rdr[8].ToString();
                        emailTextBox.Text = rdr[9].ToString();
                    }
                    rdr.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a partner adatainak betöltésekor.\n" + ex.ToString());
                }
            }
        }

        private void mentesButton_Click(object sender, EventArgs e)
        {            
            try
            {
                string nev = nevTextBox.Text;
                int iranyitoszam = Convert.ToInt32(iranyitoszamTextBox.Text);
                string varos = varosTextBox.Text;               
                string kozterulet = kozteruletTextBox.Text;               
                string kozterulet_jellege = kozteruletJellegeTextBox.Text;               
                string hazszam = hazszamTextBox.Text;               
                string epulet_emelet_ajto = epEmAjtoTextBox.Text;               
                string telefon = telefonTextBox.Text;               
                string email = emailTextBox.Text;               

                Partner partner = new Partner(nev, iranyitoszam, varos, kozterulet, kozterulet_jellege, hazszam, epulet_emelet_ajto, telefon, email);

                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sqlPartner = "";

                if (this.partner_id == 0)
                {
                    sqlPartner = "insert into partnerek (nev, iranyitoszam, varos, kozterulet, kozterulet_jellege, hazszam, epulet_emelet_ajto, telefon, email) values ('" + partner.getNev() + "', '" + partner.getIranyitoszam() + "', '" + partner.getVaros() + "', '" + partner.getKozterulet() + "', '" + partner.getKozterulet_jellege() + "', '" + partner.getHazszam() + "', '" + partner.getEpulet_emelet_ajto() + "', '" + partner.getTelefon() + "', '" + partner.getEmail() + "')";
                }
                else
                {
                    sqlPartner = "update partnerek set nev = '" + partner.getNev() + "', iranyitoszam = '" + partner.getIranyitoszam() + "', varos = '" + partner.getVaros() + "', kozterulet = '" + partner.getKozterulet() + "', kozterulet_jellege = '" + partner.getKozterulet_jellege() + "', hazszam = '" + partner.getHazszam() + "', epulet_emelet_ajto = '" + partner.getEpulet_emelet_ajto() + "', telefon = '" + partner.getTelefon() + "', email = '" + partner.getEmail() + "' where id = '" + this.partner_id + "'";
                }
                
                MySqlCommand cmd = new MySqlCommand(sqlPartner, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                kiurit();
                if (this.partner_id == 0)
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
            nevTextBox.Text = "";
            iranyitoszamTextBox.Text = "";
            varosTextBox.Text = "";
            kozteruletTextBox.Text = "";
            kozteruletJellegeTextBox.Text = "";
            hazszamTextBox.Text = "";
            epEmAjtoTextBox.Text = "";
            telefonTextBox.Text = "";
            emailTextBox.Text = "";
        }
    }
}
