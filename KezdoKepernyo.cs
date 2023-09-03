using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace iktato
{
    public partial class KezdoKepernyo : Form
    {
        readonly string connStr = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;

        private string belepettFelhasznalo;
        private string kivalsztottFelhasznalo;
        private int eredetiFoszam;
        private int eredetiAlszam;
        private int eredetiEvszam;

        public KezdoKepernyo(string felhasznalo)
        {
            this.belepettFelhasznalo = felhasznalo;
            InitializeComponent();
        }

        private void KezdoKepernyo_Load(object sender, EventArgs e)
        {
            comboBoxokFeltoltese();
            iktatasokDataGridViewFeltoltese();
            felhasznaloiAdatokBetoltese();
            felhasznalokDataGridViewFeltoltese();
            adminFeluletElrejtese();
        }

        private void adminFeluletElrejtese()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sqlAdmin = "select admin from felhasznalok where felhasznalonev = '" + belepettFelhasznalo + "'";
                MySqlCommand cmd = new MySqlCommand(sqlAdmin, conn);
                bool admin = (bool)cmd.ExecuteScalar();

                if (!admin)
                {
                    tabControl1.TabPages.Remove(adminTabPage);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a felhasználó admin jogosultságának lekérdezésekor.\n" + ex.Message);
            }      
        }

        private void comboBoxokFeltoltese()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                partnerComboBox.Items.Clear();
                partnerComboBox2.Items.Clear();
                conn.Open();
                string sqlPartner = "select * from partnerek where torolt = 0";
                MySqlCommand cmd = new MySqlCommand(sqlPartner, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string sor = rdr[0].ToString() + ". " + rdr[1].ToString() + " " + rdr[2].ToString() + " " + rdr[3].ToString() + ", " + rdr[4].ToString() + " " + rdr[5].ToString() + " " + rdr[6].ToString() + " " + rdr[7].ToString() + " " + rdr[8].ToString() + " " + rdr[9].ToString();
                    partnerComboBox.Items.Add(sor);
                }
                rdr.Close();
                conn.Close();

                conn.Open();
                string sqlPartner2 = "select * from partnerek";
                cmd = new MySqlCommand(sqlPartner2, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string sor = rdr[0].ToString() + ". " + rdr[1].ToString() + " " + rdr[2].ToString() + " " + rdr[3].ToString() + ", " + rdr[4].ToString() + " " + rdr[5].ToString() + " " + rdr[6].ToString() + " " + rdr[7].ToString() + " " + rdr[8].ToString() + " " + rdr[9].ToString();
                    partnerComboBox2.Items.Add(sor);
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az adatbázis kapcsolatban (partnerek tábla).\n" + ex.Message);
            }

            try
            {
                dolgozoComboBox.Items.Clear();
                dolgozoComboBox2.Items.Clear();
                conn.Open();
                string sqlDolgozo = "select * from dolgozok where torolt = 0";
                MySqlCommand cmd = new MySqlCommand(sqlDolgozo, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string sor = rdr[0].ToString() + ". " + rdr[1].ToString() + " " + rdr[2].ToString() + " " + rdr[3].ToString() + " " + rdr[4].ToString() + " " + rdr[5].ToString();
                    dolgozoComboBox.Items.Add(sor);
                }
                rdr.Close();
                conn.Close();

                conn.Open();
                string sqlDolgozo2 = "select * from dolgozok";
                cmd = new MySqlCommand(sqlDolgozo2, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string sor = rdr[0].ToString() + ". " + rdr[1].ToString() + " " + rdr[2].ToString() + " " + rdr[3].ToString() + " " + rdr[4].ToString() + " " + rdr[5].ToString();
                    dolgozoComboBox.Items.Add(sor);
                    dolgozoComboBox2.Items.Add(sor);
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az adatbázis kapcsolatban (dolgozok tábla).\n" + ex.Message);
            }

            try
            {
                iranyComboBox.Items.Clear();
                iranyComboBox2.Items.Clear();
                conn.Open();
                string sqlIrany = "select * from iranyok";
                MySqlCommand cmd = new MySqlCommand(sqlIrany, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string sor = rdr[0].ToString() + ". " + rdr[1].ToString();
                    iranyComboBox.Items.Add(sor);
                    iranyComboBox2.Items.Add(sor);
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az adatbázis kapcsolatban (iranyok tábla).\n" + ex.Message);
            }

            try
            {
                eloiratComboBox.Items.Clear();
                eloiratComboBox2.Items.Clear();
                conn.Open();
                string sqlEloirat = "select iktatasok.foszam, iktatasok.alszam, iktatasok.evszam, partnerek.nev, iktatasok.megnevezes from iktatasok, partnerek where iktatasok.partner_id = partnerek.id and iktatasok.torolt = 0";
                MySqlCommand cmd = new MySqlCommand(sqlEloirat, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string sor = rdr[0].ToString() + "-" + rdr[1].ToString() + "/" + rdr[2].ToString() + " " + rdr[3].ToString() + " " + rdr[4].ToString();
                    eloiratComboBox.Items.Add(sor);
                    eloiratComboBox2.Items.Add(sor);
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az adatbázis kapcsolatban (iktatasok tábla).\n" + ex.Message);
            }

            try
            {
                foszamComboBox.Items.Clear();
                foszamComboBox2.Items.Clear();
                conn.Open();
                int most = DateTime.Now.Year;
                string sqlFoszam = "select iktatasok.foszam, iktatasok.alszam, iktatasok.evszam, partnerek.nev, iktatasok.megnevezes from iktatasok, partnerek where iktatasok.partner_id = partnerek.id and iktatasok.evszam = '" + most + "' and iktatasok.torolt = 0";
                MySqlCommand cmd = new MySqlCommand(sqlFoszam, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string sor = rdr[0].ToString() + "-" + rdr[1].ToString() + "/" + rdr[2].ToString() + " " + rdr[3].ToString() + " " + rdr[4].ToString();
                    foszamComboBox.Items.Add(sor);
                }
                rdr.Close();
                conn.Close();

                foszamComboBox.Items.Clear();
                foszamComboBox2.Items.Clear();
                conn.Open();
                string sqlFoszam2 = "select iktatasok.foszam, iktatasok.alszam, iktatasok.evszam, partnerek.nev, iktatasok.megnevezes from iktatasok, partnerek where iktatasok.partner_id = partnerek.id and iktatasok.evszam = '" + most + "'";
                cmd = new MySqlCommand(sqlFoszam2, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string sor = rdr[0].ToString() + "-" + rdr[1].ToString() + "/" + rdr[2].ToString() + " " + rdr[3].ToString() + " " + rdr[4].ToString();
                    foszamComboBox2.Items.Add(sor);
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az adatbázis kapcsolatban (iktatasok tábla).\n" + ex.Message);
            }

        }

        private void iktatasButton_Click(object sender, EventArgs e)
        {
            try
            {
                int foszam = 0;
                object foszamMezo = foszamComboBox.SelectedItem;
                if (foszamMezo != null)
                {
                    foszam = Convert.ToInt32(foszamMezo.ToString().Split('-')[0]);
                }
                int partner_id = Convert.ToInt32(partnerComboBox.SelectedItem.ToString().Split('.')[0]);
                int irany_id = Convert.ToInt32(iranyComboBox.SelectedItem.ToString().Split('.')[0]);
                DateTime datum = datumDateTimePicker.Value;
                string megnevezes = megnevezesTextBox.Text;
                DateTime hatarido = hataridoDateTimePicker.Value;
                int elvegzo_dolgozo_id = Convert.ToInt32(dolgozoComboBox.SelectedItem.ToString().Split('.')[0]); ;
                string eloirat = "";
                object eloiratMezo = eloiratComboBox.SelectedItem;
                if (eloiratMezo != null)
                {
                    eloirat = eloiratMezo.ToString().Split(' ')[0];
                }

                Iktatas ikt = new Iktatas(foszam, partner_id, irany_id, datum, megnevezes, hatarido, elvegzo_dolgozo_id, eloirat);

                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();

                string sqlIktatas = "insert into iktatasok (foszam, alszam, evszam, partner_id, irany_id, datum, megnevezes, hatarido, elvegzo_dolgozo_id, eloirat, torolt) values ('" + ikt.getFoszam() + "', '" + ikt.getAlszam() + "', '" + ikt.getEvszam() + "', '" + ikt.getPartner_id() + "', '" + ikt.getIrany_id() + "', '" + ikt.getDatum().ToString("yyyy-MM-dd") + "', '" + ikt.getMegnevezes() + "', '" + ikt.getHatarido().ToString("yyyy-MM-dd") + "', '" + ikt.getElvegzo_dolgozo_id() + "', '" + ikt.getEloirat() + "', 0)";
                MySqlCommand cmd = new MySqlCommand(sqlIktatas, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                kiurit();
                iktatasokDataGridViewFeltoltese();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibásan töltötte ki az adatokat, kérem ellenőrizze!\n" + ex.Message);
            }
        }

        private void kiurit()
        {
            partnerComboBox.Text = "";
            partnerComboBox2.Text = "";
            partnerComboBox2.Enabled = false;
            iranyComboBox.Text = "";
            iranyComboBox2.Text = "";
            iranyComboBox2.Enabled = false;
            datumDateTimePicker.Value = DateTime.Now;
            datumDateTimePicker2.Value = DateTime.Now;
            datumDateTimePicker2.Enabled = false;
            megnevezesTextBox.Text = "";
            megnevezesTextBox2.Text = "";
            megnevezesTextBox2.Enabled = false;
            hataridoDateTimePicker.Value = DateTime.Now;
            hataridoDateTimePicker2.Value = DateTime.Now;
            hataridoDateTimePicker2.Enabled = false;
            dolgozoComboBox.Text = "";
            dolgozoComboBox2.Text = "";
            dolgozoComboBox2.Enabled = false;
            eloiratComboBox.Text = "";
            eloiratComboBox2.Text = "";
            eloiratComboBox2.Enabled = false;
            foszamComboBox.Text = "";
            foszamComboBox2.Text = "";
            foszamComboBox2.Enabled = false;
            modositasButton.Enabled = false;
            torlesButton.Enabled = false;
            eredetiFoszam = 0;
            eredetiAlszam = 0;
            eredetiEvszam = 0;
        }

        private void ujPartnerButton_Click(object sender, EventArgs e)
        {
            var partnerek = new Partnerek(0);
            partnerek.Closed += (s, args) => this.Show();
            partnerek.Closed += (s, args) => comboBoxokFeltoltese();
            partnerek.Closed += (s, args) => kiurit();
            partnerek.Closed += (s, args) => iktatasokDataGridViewFeltoltese();
            partnerek.Show();
            this.Hide();
        }

        private void partnerModositasaButton_Click(object sender, EventArgs e)
        {
            try
            {
                int partner_id = Convert.ToInt32(partnerComboBox.SelectedItem.ToString().Split('.')[0]);
                var partnerek = new Partnerek(partner_id);
                partnerek.Closed += (s, args) => this.Show();
                partnerek.Closed += (s, args) => comboBoxokFeltoltese();
                partnerek.Closed += (s, args) => kiurit();
                partnerek.Closed += (s, args) => iktatasokDataGridViewFeltoltese();
                partnerek.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kérem válassza ki a módosítandó partnert!\n" + ex.Message);
            }
        }

        private void partnerTorleseButton_Click(object sender, EventArgs e)
        {
            try
            {
                int partner_id = Convert.ToInt32(partnerComboBox.SelectedItem.ToString().Split('.')[0]);
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sqlPartnerTorles = "update partnerek set torolt = 1 where id = '" + partner_id + "'";
                MySqlCommand cmd = new MySqlCommand(sqlPartnerTorles, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                comboBoxokFeltoltese();
                kiurit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kérem válassza ki azt a partnert, akit törölni szeretne!\n" + ex.Message);
            }
        }

        private void toroltPartnerekButton_Click(object sender, EventArgs e)
        {
            try
            {                
                var toroltPartnerek = new ToroltPartnerek();
                toroltPartnerek.Closed += (s, args) => this.Show();
                toroltPartnerek.Closed += (s, args) => comboBoxokFeltoltese();
                toroltPartnerek.Closed += (s, args) => kiurit();
                toroltPartnerek.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a törölt partnerek combobox megnyitásakor!\n" + ex.Message);
            }
        }

        private void ujDolgozoButton_Click(object sender, EventArgs e)
        {
            var dolgozok = new Dolgozok(0);
            dolgozok.Closed += (s, args) => this.Show();
            dolgozok.Closed += (s, args) => comboBoxokFeltoltese();
            dolgozok.Closed += (s, args) => kiurit();
            dolgozok.Closed += (s, args) => iktatasokDataGridViewFeltoltese();
            dolgozok.Show();
            this.Hide();
        }

        private void dolgozoModositasaButton_Click(object sender, EventArgs e)
        {
            try
            {
                int dolgozo_id = Convert.ToInt32(dolgozoComboBox.SelectedItem.ToString().Split('.')[0]);
                var dolgozok = new Dolgozok(dolgozo_id);
                dolgozok.Closed += (s, args) => this.Show();
                dolgozok.Closed += (s, args) => comboBoxokFeltoltese();
                dolgozok.Closed += (s, args) => kiurit();
                dolgozok.Closed += (s, args) => iktatasokDataGridViewFeltoltese();
                dolgozok.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kérem válassza ki a módosítandó dolgzót!\n" + ex.Message);
            }
        }

        private void dolgozoTorleseButton_Click(object sender, EventArgs e)
        {
            try
            {
                int dolgozo_id = Convert.ToInt32(dolgozoComboBox.SelectedItem.ToString().Split('.')[0]);
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sqlDolgozoTorles = "update dolgozok set torolt = 1 where id = '" + dolgozo_id + "'";
                MySqlCommand cmd = new MySqlCommand(sqlDolgozoTorles, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                comboBoxokFeltoltese();
                kiurit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kérem válassza ki azt a dolgozót, akit törölni szeretne!\n" + ex.Message);
            }
        }

        private void toroltDolgozokButton_Click(object sender, EventArgs e)
        {
            try
            {
                var toroltDolgozok = new ToroltDolgozok();
                toroltDolgozok.Closed += (s, args) => this.Show();
                toroltDolgozok.Closed += (s, args) => comboBoxokFeltoltese();
                toroltDolgozok.Closed += (s, args) => kiurit();
                toroltDolgozok.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a törölt dolgozók combobox menyitásakor!\n" + ex.Message);
            }
        }

        private void iktatasokDataGridViewFeltoltese()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();

                MySqlDataAdapter mDA = new MySqlDataAdapter();
                string sql = "select iktatasok.foszam as 'Főszám', iktatasok.alszam as 'Alszám', iktatasok.evszam as 'Évszám', iktatasok.partner_id as 'Partner ID', partnerek.nev as 'Partner név', iktatasok.irany_id as 'Irány ID', iranyok.tipus as 'Irány', iktatasok.datum as 'Dátum', iktatasok.megnevezes as 'Megnevezés', iktatasok.hatarido as 'Határidő', iktatasok.elvegzo_dolgozo_id as 'Elvégző dolgozó ID', dolgozok.vezeteknev as 'Dolgozó vezetékneve', dolgozok.keresztnev as 'Dolgozó keresztneve', iktatasok.eloirat as 'Előirat', iktatasok.torolt as 'Törölt' from iktatasok, partnerek, iranyok, dolgozok where iktatasok.partner_id = partnerek.id and iktatasok.irany_id = iranyok.id and iktatasok.elvegzo_dolgozo_id = dolgozok.id";
                mDA.SelectCommand = new MySqlCommand(sql, conn);

                DataTable table = new DataTable();
                mDA.Fill(table);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;

                iktatasokDataGridView.DataSource = bSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az iktatások datagridview feltöltésekor.\n" + ex.Message);
            }
        }

        private void cellaFormazasIktatasok()
        {
            foreach (DataGridViewRow sor in iktatasokDataGridView.Rows)
            {
                if (Convert.ToBoolean(sor.Cells["Törölt"].Value) == true)
                {
                    sor.DefaultCellStyle.BackColor = Color.Gray;
                }
            }
        }

        private void modositasButton_Click(object sender, EventArgs e)
        {
            try
            {
                int foszam = 0;
                int alszam = 0;
                int evszam = 0;
                object foszamMezo = foszamComboBox2.SelectedItem;
                if (foszamMezo != null)
                {
                    foszam = Convert.ToInt32(foszamMezo.ToString().Split('-')[0]);
                    alszam = Convert.ToInt32(foszamMezo.ToString().Split('-')[1].Split('/')[0]);
                    evszam = Convert.ToInt32(foszamMezo.ToString().Split(' ')[0].Split('/')[1]);

                }
                int partner_id = Convert.ToInt32(partnerComboBox2.SelectedItem.ToString().Split('.')[0]);
                int irany_id = Convert.ToInt32(iranyComboBox2.SelectedItem.ToString().Split('.')[0]);
                DateTime datum = datumDateTimePicker2.Value;
                string megnevezes = megnevezesTextBox2.Text;
                DateTime hatarido = hataridoDateTimePicker2.Value;
                int elvegzo_dolgozo_id = Convert.ToInt32(dolgozoComboBox2.SelectedItem.ToString().Split('.')[0]); ;
                string eloirat = "";
                object eloiratMezo = eloiratComboBox2.SelectedItem;
                if (eloiratMezo != null)
                {
                    eloirat = eloiratMezo.ToString().Split(' ')[0];
                }

                Iktatas ikt = new Iktatas();
                if (foszam == eredetiFoszam && alszam == eredetiAlszam && evszam == eredetiEvszam)
                {
                    ikt.setFoszam(foszam);
                    ikt.setAlszam(alszam);
                    ikt.setEvszam(evszam);
                    ikt.setPartner_id(partner_id);
                    ikt.setIrany_id(irany_id);
                    ikt.setDatum(datum);
                    ikt.setMegnevezes(megnevezes);
                    ikt.setHatarido(hatarido);
                    ikt.setElvegzo_dolgozo_id(elvegzo_dolgozo_id);
                    ikt.setEloirat(eloirat);
                }
                else
                {
                    ikt.setFoszam(foszam);
                    ikt.setEvszam(evszam);
                    ikt.setPartner_id(partner_id);
                    ikt.setIrany_id(irany_id);
                    ikt.setDatum(datum);
                    ikt.setMegnevezes(megnevezes);
                    ikt.setHatarido(hatarido);
                    ikt.setElvegzo_dolgozo_id(elvegzo_dolgozo_id);
                    ikt.setEloirat(eloirat);
                }

                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();

                string sqlIktatas = "update iktatasok set foszam = '" + ikt.getFoszam() + "', alszam = '" + ikt.getAlszam() + "', evszam = '" + ikt.getEvszam() + "', partner_id = '" + ikt.getPartner_id() + "', irany_id = '" + ikt.getIrany_id() + "', datum = '" + ikt.getDatum().ToString("yyyy-MM-dd") + "', megnevezes = '" + ikt.getMegnevezes() + "', hatarido = '" + ikt.getHatarido().ToString("yyyy-MM-dd") + "', elvegzo_dolgozo_id = '" + ikt.getElvegzo_dolgozo_id() + "', eloirat = '" + ikt.getEloirat() + "' where foszam = '" + eredetiFoszam + "' and alszam = '" + eredetiAlszam + "' and evszam = '" + eredetiEvszam + "'";
                MySqlCommand cmd = new MySqlCommand(sqlIktatas, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                kiurit();
                comboBoxokFeltoltese();
                iktatasokDataGridViewFeltoltese();
                iktatasokDataGridView.CurrentCell = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibásan töltötte ki az adatokat, kérem ellenőrizze!\n" + ex.Message);
            }
        }

        private void iktatasokDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    eredetiFoszam = Convert.ToInt32(iktatasokDataGridView.Rows[e.RowIndex].Cells["Főszám"].FormattedValue.ToString());
                    eredetiAlszam = Convert.ToInt32(iktatasokDataGridView.Rows[e.RowIndex].Cells["Alszám"].FormattedValue.ToString());
                    eredetiEvszam = Convert.ToInt32(iktatasokDataGridView.Rows[e.RowIndex].Cells["Évszám"].FormattedValue.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba az eredeti főszám, alszám, évszám meghatározásakor.\n" + ex.Message);
                }
                try
                {
                    string partnerId = iktatasokDataGridView.Rows[e.RowIndex].Cells["Partner ID"].FormattedValue.ToString();

                    conn.Open();
                    string sqlPartner = "select * from partnerek where id = '" + partnerId + "'";
                    MySqlCommand cmd = new MySqlCommand(sqlPartner, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    rdr.Read();
                    string sor = rdr[0].ToString() + ". " + rdr[1].ToString() + " " + rdr[2].ToString() + " " + rdr[3].ToString() + ", " + rdr[4].ToString() + " " + rdr[5].ToString() + " " + rdr[6].ToString() + " " + rdr[7].ToString() + " " + rdr[8].ToString() + " " + rdr[9].ToString();

                    partnerComboBox2.SelectedItem = sor;

                    rdr.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a partner comboboxba való betöltésekor.\n" + ex.Message);
                }

                try
                {
                    string iranyId = iktatasokDataGridView.Rows[e.RowIndex].Cells["Irány ID"].FormattedValue.ToString();

                    conn.Open();
                    string sqlIrany = "select * from iranyok where id = '" + iranyId + "'";
                    MySqlCommand cmd = new MySqlCommand(sqlIrany, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    rdr.Read();
                    string sor = rdr[0].ToString() + ". " + rdr[1].ToString();

                    iranyComboBox2.SelectedItem = sor;

                    rdr.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba az irány comboboxba való betöltésekor.\n" + ex.Message);
                }

                try
                {
                    string dolgozoId = iktatasokDataGridView.Rows[e.RowIndex].Cells["Elvégző dolgozó ID"].FormattedValue.ToString();

                    conn.Open();
                    string sqlDolgozo = "select * from dolgozok where id = '" + dolgozoId + "'";
                    MySqlCommand cmd = new MySqlCommand(sqlDolgozo, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    rdr.Read();
                    string sor = rdr[0].ToString() + ". " + rdr[1].ToString() + " " + rdr[2].ToString() + " " + rdr[3].ToString() + " " + rdr[4].ToString() + " " + rdr[5].ToString();
                    dolgozoComboBox2.SelectedItem = sor;

                    rdr.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba az elvégző dolgozó comboboxba való betöltésekor.\n" + ex.Message);
                }

                try
                {
                    string eloirat = iktatasokDataGridView.Rows[e.RowIndex].Cells["Előirat"].FormattedValue.ToString();
                    if (eloirat != "" && eloirat != null)
                    {
                        string foszam = eloirat.Split('-')[0];
                        string alszam = eloirat.Split('-')[1].Split('/')[0];
                        string evszam = eloirat.Split('/')[1];

                        conn.Open();
                        string sqlEloirat = "select iktatasok.foszam, iktatasok.alszam, iktatasok.evszam, partnerek.nev, iktatasok.megnevezes from iktatasok, partnerek where iktatasok.partner_id = partnerek.id and iktatasok.foszam = '" + foszam + "' and iktatasok.alszam = '" + alszam + "' and iktatasok.evszam = '" + evszam + "'";
                        MySqlCommand cmd = new MySqlCommand(sqlEloirat, conn);
                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            string sor = rdr[0].ToString() + "-" + rdr[1].ToString() + "/" + rdr[2].ToString() + " " + rdr[3].ToString() + " " + rdr[4].ToString();
                            eloiratComboBox2.SelectedItem = sor;
                        }
                        rdr.Close();
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba az előirat comboboxba való betöltésekor.\n" + ex.Message);
                }

                try
                {
                    string foszam = iktatasokDataGridView.Rows[e.RowIndex].Cells["Főszám"].FormattedValue.ToString();
                    string alszam = iktatasokDataGridView.Rows[e.RowIndex].Cells["Alszám"].FormattedValue.ToString();
                    string evszam = iktatasokDataGridView.Rows[e.RowIndex].Cells["Évszám"].FormattedValue.ToString();
                    conn.Open();
                    int most = DateTime.Now.Year;
                    string sqlFoszam = "select iktatasok.foszam, iktatasok.alszam, iktatasok.evszam, partnerek.nev, iktatasok.megnevezes from iktatasok, partnerek where iktatasok.partner_id = partnerek.id and iktatasok.foszam = '" + foszam + "' and iktatasok.alszam = '" + alszam + "' and iktatasok.evszam = '" + evszam + "'";
                    MySqlCommand cmd = new MySqlCommand(sqlFoszam, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    rdr.Read();
                    string sor = rdr[0].ToString() + "-" + rdr[1].ToString() + "/" + rdr[2].ToString() + " " + rdr[3].ToString() + " " + rdr[4].ToString();
                    foszamComboBox2.SelectedItem = sor;
                    rdr.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a főszám comboboxba való betöltésekor.\n" + ex.Message);
                }

                try
                {
                    string megnevezes = iktatasokDataGridView.Rows[e.RowIndex].Cells["Megnevezés"].FormattedValue.ToString();
                    megnevezesTextBox2.Text = megnevezes;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a megnevezés textboxba való betöltésekor.\n" + ex.Message);
                }

                try
                {
                    DateTime datum = Convert.ToDateTime(iktatasokDataGridView.Rows[e.RowIndex].Cells["Dátum"].FormattedValue.ToString());
                    datumDateTimePicker2.Value = datum;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a beérkezés / kiküldés dátumának DateTimePickerbe való betöltésekor.\n" + ex.Message);
                }

                try
                {
                    DateTime hatarido = Convert.ToDateTime(iktatasokDataGridView.Rows[e.RowIndex].Cells["Határidő"].FormattedValue.ToString());
                    hataridoDateTimePicker2.Value = hatarido;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a határidő DateTimePickerbe való betöltésekor.\n" + ex.Message);
                }

                try
                {
                    bool torolt = (bool)iktatasokDataGridView.Rows[e.RowIndex].Cells["Törölt"].Value;
                    if (torolt)
                    {
                        torlesButton.Text = "Törlés visszavonása";
                    }
                    else
                    {
                        torlesButton.Text = "Törlés";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a Törlés / Törlés visszavonása gomb szövegének beállításakor.\n" + ex.Message);
                }
            }
            partnerComboBox2.Enabled = true;
            iranyComboBox2.Enabled = true;
            datumDateTimePicker2.Enabled = true;
            megnevezesTextBox2.Enabled = true;
            hataridoDateTimePicker2.Enabled = true;
            dolgozoComboBox2.Enabled = true;
            eloiratComboBox2.Enabled = true;
            foszamComboBox2.Enabled = true;
            modositasButton.Enabled = true;
            torlesButton.Enabled = true;
        }

        private void iktatasokDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            cellaFormazasIktatasok();
        }

        private void torlesButton_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();

                string sqltorolt = "select torolt from iktatasok where foszam = '" + eredetiFoszam + "' and alszam = '" + eredetiAlszam + "' and evszam = '" + eredetiEvszam + "'";
                MySqlCommand cmd = new MySqlCommand(sqltorolt, conn);
                bool torolt = (bool)cmd.ExecuteScalar();
                conn.Close();

                conn.Open();
                string sqlUpdate = "";
                if (torolt)
                {
                    sqlUpdate = "update iktatasok set iktatasok.torolt = 0 where foszam = '" + eredetiFoszam + "' and alszam = '" + eredetiAlszam + "' and evszam = '" + eredetiEvszam + "'";
                    torlesButton.Text = "Törlés";
                }
                else
                {
                    sqlUpdate = "update iktatasok set iktatasok.torolt = 1 where foszam = '" + eredetiFoszam + "' and alszam = '" + eredetiAlszam + "' and evszam = '" + eredetiEvszam + "'";
                    torlesButton.Text = "Törlés visszavonása";
                }
                cmd = new MySqlCommand(sqlUpdate, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                iktatasokDataGridViewFeltoltese();
                comboBoxokFeltoltese();
                kiurit();
                iktatasokDataGridView.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a törlés / törlés visszavonása során.\n" + ex.Message);
            }
        }

        private void ujButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            kiurit();
            comboBoxokFeltoltese();
            iktatasokDataGridViewFeltoltese();
        }

        private void felhasznaloiAdatokBetoltese()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sqlFelhasznalo = "select * from felhasznalok where felhasznalonev = '" + this.belepettFelhasznalo + "'";
                MySqlCommand cmd = new MySqlCommand(sqlFelhasznalo, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    felhasznalonevTextBox.Text = rdr[0].ToString();
                    jelszoTextBox.Text = Titkositas.Decrypt(rdr[1].ToString(), true);
                    vezeteknevTextBox.Text = rdr[2].ToString();
                    keresztnevTextBox.Text = rdr[3].ToString();
                    emailTextBox.Text = rdr[4].ToString();
                    telefonTextBox.Text = rdr[5].ToString();
                    if (Convert.ToBoolean(rdr[6]))
                    {
                        adminCheckBox.Checked = true;
                    }
                    else
                    {
                        adminCheckBox.Checked = false;
                    }
                    if (Convert.ToBoolean(rdr[7]))
                    {
                        aktivCheckBox.Checked = true;
                    }
                    else
                    {
                        aktivCheckBox.Checked = false;
                    }
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a felhaználói adatok betöltésekor.\n" + ex.Message);
            }
        }

        private void sajatAdatModositasButton_Click(object sender, EventArgs e)
        {
            try
            {
                string jelszo = Titkositas.Encrypt(jelszoTextBox.Text, true);
                string email = emailTextBox.Text;
                string telefon = telefonTextBox.Text;

                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sqlmodositas = "update felhasznalok set jelszo = '" + jelszo + "', email = '" + email + "', telefon = '" + telefon + "' where felhasznalonev = '" + this.belepettFelhasznalo + "'";
                MySqlCommand cmd = new MySqlCommand(sqlmodositas, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                felhasznaloiAdatokBetoltese();
                felhasznalokDataGridViewFeltoltese();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a saját adatok módosításakor.\n" + ex.Message);
            }
        }

        private void felhasznalokDataGridViewFeltoltese()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();

                MySqlDataAdapter mDA = new MySqlDataAdapter();
                string sql = "select felhasznalonev as 'Felhasználónév', jelszo as 'Jelszó', vezeteknev as 'Vezetéknév', keresztnev as 'Keresztnév', email as 'Email', telefon as 'Telefon', admin as 'Admin', aktiv as 'Aktív' from felhasznalok";
                mDA.SelectCommand = new MySqlCommand(sql, conn);

                DataTable table = new DataTable();
                mDA.Fill(table);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;

                felhasznalokDataGridView.DataSource = bSource;
                felhasznalokDataGridView.Columns["Jelszó"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a felhasználók datagridview feltöltésekor.\n" + ex.Message);
            }
        }

        private void felvitelButton_Click(object sender, EventArgs e)
        {
            try
            {
                kivalsztottFelhasznalo = felhasznalonevTextBox2.Text;
                string jelszo = Titkositas.Encrypt(jelszoTextBox2.Text, true);
                string vezeteknev = vezeteknevTextBox2.Text;
                string keresztnev = keresztnevTextBox2.Text;
                string email = emailTextBox2.Text;
                string telefon = telefonTextBox2.Text;
                bool admin = adminCheckBox2.Checked;
                bool aktiv = aktivCheckBox2.Checked;
                Felhasznalo felhasznalo = new Felhasznalo(kivalsztottFelhasznalo, jelszo, vezeteknev, keresztnev, email, telefon, admin, aktiv);

                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sqlFelhasznaloFelvitel = "insert into felhasznalok (felhasznalonev, jelszo, vezeteknev, keresztnev, email, telefon, admin, aktiv) values ('" + felhasznalo.getFelhasznalonev() + "', '" + felhasznalo.getJelszo() + "', '" + felhasznalo.getVezeteknev() + "', '" + felhasznalo.getKeresztnev() + "', '" + felhasznalo.getEmail() + "', '" + felhasznalo.getTelefon() + "', '" + Convert.ToInt16(felhasznalo.getAdmin()) + "', '" + Convert.ToInt16(felhasznalo.getAktiv()) + "')";
                MySqlCommand cmd = new MySqlCommand(sqlFelhasznaloFelvitel, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                felhasznalokDataGridViewFeltoltese();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a felhasználó felvitelekor.\n" + ex.Message);
            }
        }

        private void felhasznalokDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    string felhasznalonev = felhasznalokDataGridView.Rows[e.RowIndex].Cells["Felhasználónév"].FormattedValue.ToString();
                    felhasznalonevTextBox2.Text = felhasznalonev;
                    kivalsztottFelhasznalo = felhasznalonev;
                    felhasznalonevTextBox2.Enabled = false;
                    string jelszo = Titkositas.Decrypt(felhasznalokDataGridView.Rows[e.RowIndex].Cells["Jelszó"].FormattedValue.ToString(), true);
                    jelszoTextBox2.Text = jelszo;
                    string vezeteknev = felhasznalokDataGridView.Rows[e.RowIndex].Cells["Vezetéknév"].FormattedValue.ToString();
                    vezeteknevTextBox2.Text = vezeteknev;
                    string keresztnev = felhasznalokDataGridView.Rows[e.RowIndex].Cells["Keresztnév"].FormattedValue.ToString();
                    keresztnevTextBox2.Text = keresztnev;
                    string email = felhasznalokDataGridView.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString();
                    emailTextBox2.Text = email;
                    string telefon = felhasznalokDataGridView.Rows[e.RowIndex].Cells["Telefon"].FormattedValue.ToString();
                    telefonTextBox2.Text = telefon;
                    bool admin = (bool)felhasznalokDataGridView.Rows[e.RowIndex].Cells["Admin"].Value;
                    adminCheckBox2.Checked = admin;
                    bool aktiv = (bool)felhasznalokDataGridView.Rows[e.RowIndex].Cells["Aktív"].Value;
                    aktivCheckBox2.Checked = aktiv;
                    if (aktiv)
                    {
                        felhasznaloTorleseButton.Text = "Törlés";
                    }
                    else
                    {
                        felhasznaloTorleseButton.Text = "Törlés visszavonása";
                    }
                    felhasznaloModbutton.Enabled = true;
                    felhasznaloTorleseButton.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a felhasználó adatainak textboxba való betöltésekor.\n" + ex.Message);
                }
            }
        }

        private void felhasznaloTorleseButton_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();

                string sqlAktiv = "select aktiv from felhasznalok where felhasznalonev = '" + kivalsztottFelhasznalo + "'";
                MySqlCommand cmd = new MySqlCommand(sqlAktiv, conn);
                bool aktiv = (bool)cmd.ExecuteScalar();
                conn.Close();

                conn.Open();
                string sqlUpdate = "";
                if (aktiv)
                {
                    sqlUpdate = "update felhasznalok set aktiv = 0 where felhasznalonev = '" + kivalsztottFelhasznalo + "'";
                    felhasznaloTorleseButton.Text = "Törlés visszavonása";
                    aktivCheckBox2.Checked = false;
                }
                else
                {
                    sqlUpdate = "update felhasznalok set aktiv = 1 where felhasznalonev = '" + kivalsztottFelhasznalo + "'";
                    felhasznaloTorleseButton.Text = "Törlés";
                    aktivCheckBox2.Checked = true;
                }
                cmd = new MySqlCommand(sqlUpdate, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                felhasznalokDataGridViewFeltoltese();
                felhasznalokDataGridView.CurrentCell = null;
                kiuritAdminFelulet();
                kivalsztottFelhasznalo = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a törlés / törlés visszavonása során.\n" + ex.Message);
            }
        }

        private void cellaFormazasFelhasznalok()
        {
            foreach (DataGridViewRow sor in felhasznalokDataGridView.Rows)
            {
                if (Convert.ToBoolean(sor.Cells["Aktív"].Value) == false)
                {
                    sor.DefaultCellStyle.BackColor = Color.Gray;
                }
            }
        }

        private void felhasznalokDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            cellaFormazasFelhasznalok();
        }

        private void felhasznaloModbutton_Click(object sender, EventArgs e)
        {
            try
            {
                string jelszo = Titkositas.Encrypt(jelszoTextBox2.Text, true);
                string vezeteknev = vezeteknevTextBox2.Text;
                string keresztnev = keresztnevTextBox2.Text;
                string email = emailTextBox2.Text;
                string telefon = telefonTextBox2.Text;
                bool admin = adminCheckBox2.Checked;
                bool aktiv = aktivCheckBox2.Checked;
                Felhasznalo felhasznalo = new Felhasznalo(kivalsztottFelhasznalo, jelszo, vezeteknev, keresztnev, email, telefon, admin, aktiv);

                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sqlFelhasznaloModositas = "update felhasznalok set jelszo = '" + felhasznalo.getJelszo() + "', vezeteknev = '" + felhasznalo.getVezeteknev() + "', keresztnev = '" + felhasznalo.getKeresztnev() + "', email = '" + felhasznalo.getEmail() + "', telefon = '" + felhasznalo.getTelefon() + "', admin = '" + Convert.ToInt16(felhasznalo.getAdmin()) + "', aktiv = '" + Convert.ToInt16(felhasznalo.getAktiv()) + "' where felhasznalonev = '" + felhasznalo.getFelhasznalonev() + "'";
                Console.WriteLine(sqlFelhasznaloModositas);
                MySqlCommand cmd = new MySqlCommand(sqlFelhasznaloModositas, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                felhasznalokDataGridViewFeltoltese();
                kiuritAdminFelulet();
                felhasznaloiAdatokBetoltese();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a felhasználó módosításakor.\n" + ex.Message);
            }
        }

        private void kiuritAdminFelulet()
        {
            felhasznalonevTextBox2.Text = "";
            jelszoTextBox2.Text = "";
            vezeteknevTextBox2.Text = "";
            keresztnevTextBox2.Text = "";
            emailTextBox2.Text = "";
            telefonTextBox2.Text = "";
            adminCheckBox2.Checked = false;
            aktivCheckBox2.Checked = false;
            felhasznalonevTextBox2.Enabled = true;
            felhasznaloModbutton.Enabled = false;
            felhasznaloTorleseButton.Enabled = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
