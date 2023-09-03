using System;
using System.Windows.Forms;

namespace iktato
{
    internal class Dolgozo
    {
        private string vezeteknev;
        private string keresztnev;
        private string munkakor;
        private string telefon;
        private string email;

        public Dolgozo(string vezeteknev, string keresztnev, string munkakor, string telefon, string email)
        {
            setVezeteknev(vezeteknev);
            setKeresztnev(keresztnev);
            setMunkakor(munkakor);
            setTelefon(telefon);
            setEmail(email);
        }

        public string getVezeteknev() { return vezeteknev; }
        public string getKeresztnev() { return keresztnev; }
        public string getMunkakor() { return munkakor; }
        public string getTelefon() { return telefon; }
        public string getEmail() { return email; }

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

        public void setMunkakor(string munkakor)
        {
            if (munkakor == null || munkakor == "")
            {
                MessageBox.Show("A munkakör kitöltése kötelező!");
                throw new ArgumentNullException(nameof(munkakor));
            }
            else
            {
                this.munkakor = munkakor;
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
    }
}
