using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace iktato
{
    internal class Iktatas
    {
        readonly string connStr = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;

        private int foszam;
        private int alszam;
        private int evszam;
        private int partner_id;
        private int irany_id;
        private DateTime datum;
        private string megnevezes;
        private DateTime hatarido;
        private int elvegzo_dolgozo_id;
        private string eloirat;

        public Iktatas() { }

        public Iktatas(int foszam, int partner_id, int irany_id, DateTime datum, string megnevezes, DateTime hatarido, int elvegzo_dolgozo_id, string eloirat)
        {
            setFoszam(foszam);
            setEvszam();
            setPartner_id(partner_id);
            setIrany_id(irany_id);
            setDatum(datum);
            setMegnevezes(megnevezes);
            setHatarido(hatarido);
            setElvegzo_dolgozo_id(elvegzo_dolgozo_id);
            setEloirat(eloirat);
        }

        public int getFoszam() { return foszam; }
        public int getAlszam() { return alszam; }
        public int getEvszam() { return evszam; }
        public int getPartner_id() { return partner_id; }
        public int getIrany_id() { return irany_id; }
        public DateTime getDatum() { return datum; }
        public string getMegnevezes() { return megnevezes; }
        public DateTime getHatarido() { return hatarido; }
        public int getElvegzo_dolgozo_id() { return elvegzo_dolgozo_id; }
        public string getEloirat() { return eloirat; }

        public void setFoszam(int foszam)
        {
            if (foszam >= 1)
            {
                this.foszam = foszam;
                setAlszam(true, foszam);
            }
            else if (foszam == 0)
            {
                setFoszam();
            }
            else
            {
                MessageBox.Show("Nem (jól) adott meg a főszámot, kérem ellenőrizze!");
                throw new ArgumentException("Hibás a főszám.", nameof(foszam));
            }
        }

        public void setFoszam()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sqlUtolsoFoszam = "select foszam from iktatasok order by foszam desc limit 1;";
                MySqlCommand cmd = new MySqlCommand(sqlUtolsoFoszam, conn);
                object utolsoFoszam = cmd.ExecuteScalar();

                if (utolsoFoszam != null)
                {
                    this.foszam = Convert.ToInt32(utolsoFoszam) + 1;
                    setAlszam(1);
                }
                else
                {
                    this.foszam = 1;
                    setAlszam(1);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az adatbázis kapcsolatban (főszám beállítása).\n" + ex.Message);
            }
        }

        public void setAlszam(int alszam)
        {
            if (alszam >= 1)
            {
                this.alszam = alszam;
            }
            else
            {
                MessageBox.Show("Hibás alszám, kérem ellenőrizze!");
                throw new ArgumentException("Hibás az alszám.", nameof(partner_id));
            }
        }

        public void setAlszam(bool vanFoszam, int foszam)
        {
            if (vanFoszam)
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    string sqlUtolsoAlszam = "select alszam from iktatasok where foszam = '" + foszam + "' order by alszam desc limit 1";
                    MySqlCommand cmd = new MySqlCommand(sqlUtolsoAlszam, conn);
                    object utolsoAlszam = cmd.ExecuteScalar();

                    if (utolsoAlszam != null)
                    {
                        this.alszam = Convert.ToInt32(utolsoAlszam) + 1;
                    }
                    else
                    {
                        this.alszam = 1;
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba az adatbázis kapcsolatban (alszám beállítása).\n" + ex.Message);
                }
            }
        }
        
        public void setEvszam()
        {
            DateTime most = DateTime.Now;
            evszam = (int)most.Year;
        }

        public void setEvszam(int ev)
        {
            DateTime most = DateTime.Now;
            if (ev >= 1950 && ev <= most.Year)
            {
                evszam = ev;                
            }
            else
            {
                MessageBox.Show("Nem (jól) adott meg az évszámot, kérem ellenőrizze!");
                throw new ArgumentException("Hibás az évszám.", nameof(ev));
            }
        }

        public void setPartner_id(int partner_id)
        {
            if (partner_id >= 1)
            {
                this.partner_id = partner_id;
            }
            else
            {
                MessageBox.Show("Nem (jól) adott meg a partnert, kérem ellenőrizze!");
                throw new ArgumentException("Hibás a partnerid.", nameof(partner_id));
            }
        }

        public void setIrany_id(int irany_id)
        {
            if (irany_id >= 1)
            {
                this.irany_id = irany_id;
            }
            else
            {
                MessageBox.Show("Nem (jól) adott meg az irányt, kérem ellenőrizze!");
                throw new ArgumentException("Hibás a irány id.", nameof(irany_id));
            }
        }

        public void setDatum(DateTime datum)
        {
            DateTime most = DateTime.Now;
            evszam = (int)most.Year;
            if (datum.Year == evszam)
            {
                this.datum = datum;
            }
            else
            {
                MessageBox.Show("A dátum mezőben megadott érték nem erre az évre esik, kérem ellenőrizze!");
                throw new ArgumentException("Hibás dátum.", nameof(datum));
            }
        }

        public void setMegnevezes(string megnevezes)
        {
            if (megnevezes == null || megnevezes == "")
            {
                MessageBox.Show("A megnevezés kitöltése kötelező!");
                throw new ArgumentNullException(nameof(megnevezes));
            }
            else
            {
                this.megnevezes = megnevezes;
            }
        }

        public void setHatarido(DateTime hatarido)
        {
            if (hatarido >= this.datum)
            {
                this.hatarido = hatarido;
            }
            else
            {
                MessageBox.Show("A határidő hibás, korábbi mint a beérkezés dátuma.");
                throw new ArgumentException("Hibás határidő!", nameof(hatarido));
            }
        }

        public void setElvegzo_dolgozo_id(int elvegzo_dolgozo_id)
        {
            if (elvegzo_dolgozo_id >= 1)
            {
                this.elvegzo_dolgozo_id = elvegzo_dolgozo_id;
            }
            else
            {
                MessageBox.Show("Nem (jól) adott meg az elvégző dolgozót, kérem ellenőrizze!");
                throw new ArgumentException("Hibás az elvégző dolgozó.", nameof(elvegzo_dolgozo_id));
            }
        }

        public void setEloirat(string eloirat)
        {
            this.eloirat = eloirat;
        }
    }
}