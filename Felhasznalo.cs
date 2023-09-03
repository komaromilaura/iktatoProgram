using System;
using System.Windows.Forms;

namespace iktato
{
    internal class Felhasznalo
    {
        private string felhasznalonev;
        private string jelszo;
        private string vezeteknev;
        private string keresztnev;
        private string email;
        private string telefon;
        private bool admin;
        private bool aktiv;

        public Felhasznalo(string felhasznalonev, string jelszo, string vezeteknev, string keresztnev, string email, string telefon, bool admin, bool aktiv)
        {
            setFelhasznalonev(felhasznalonev);
            setJelszo(jelszo);
            setVezeteknev(vezeteknev);
            setKeresztnev(keresztnev);
            setEmail(email);
            setTelefon(telefon);
            setAdmin(admin);
            setAktiv(aktiv);
        }

        public string getFelhasznalonev() { return felhasznalonev; }
        public string getJelszo() { return jelszo; }
        public string getVezeteknev() { return vezeteknev; }
        public string getKeresztnev() { return keresztnev; }
        public string getEmail() { return email; }
        public string getTelefon() { return telefon; }
        public bool getAdmin() { return admin; }
        public bool getAktiv() { return aktiv; }

        public void setFelhasznalonev(string felhasznalonev)
        {
            if (felhasznalonev == null || felhasznalonev == "")
            {
                MessageBox.Show("A felhasznalónév kitöltése kötelező!");
                throw new ArgumentNullException(nameof(felhasznalonev));
            }
            else
            {
                this.felhasznalonev = felhasznalonev;
            }
        }

        public void setJelszo(string jelszo)
        {
            if (jelszo == null || jelszo == "")
            {
                MessageBox.Show("A jelszó kitöltése kötelező!");
                throw new ArgumentNullException(nameof(jelszo));
            }
            else
            {
                this.jelszo = jelszo;
            }
        }

        public void setVezeteknev(string vezeteknev)
        {
            if (vezeteknev == null || vezeteknev == "")
            {
                MessageBox.Show("A vezetéknév kitöltése kötelező!");
                throw new ArgumentNullException(nameof(vezeteknev));
            }
            else
            {
                this.vezeteknev = vezeteknev;
            }
        }

        public void setKeresztnev(string keresztnev)
        {
            if (keresztnev == null || keresztnev == "")
            {
                MessageBox.Show("A keresztnév kitöltése kötelező!");
                throw new ArgumentNullException(nameof(keresztnev));
            }
            else
            {
                this.keresztnev = keresztnev;
            }
        }

        public void setEmail(string email)
        {
            if (email == null || email == "")
            {
                MessageBox.Show("Az email cím kitöltése kötelező!");
                throw new ArgumentNullException(nameof(email));
            }
            else
            {
                this.email = email;
            }
        }

        public void setTelefon(string telefon)
        {
            if (telefon == null || telefon == "")
            {
                MessageBox.Show("A telefonszám kitöltése kötelező!");
                throw new ArgumentNullException(nameof(telefon));
            }
            else
            {
                this.telefon = telefon;
            }
        }

        public void setAdmin(bool admin)
        {
            this.admin = admin;
        }

        public void setAktiv(bool aktiv)
        {
            this.aktiv = aktiv;
        }
    }
}
