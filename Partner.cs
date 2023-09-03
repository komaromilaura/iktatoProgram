using System;
using System.Windows.Forms;

namespace iktato
{
    internal class Partner
    {
        private string nev;
        private int iranyitoszam;
        private string varos;
        private string kozterulet;
        private string kozterulet_jellege;
        private string hazszam;
        private string epulet_emelet_ajto;
        private string telefon;
        private string email;

        public Partner(string nev, int iranyitoszam, string varos, string kozterulet, string kozterulet_jellege, string hazszam, string epulet_emelet_ajto, string telefon, string email)
        {
            setNev(nev);
            setIranyitoszam(iranyitoszam);
            setVaros(varos);
            setKozterulet(kozterulet);
            setKozterulet_jellege(kozterulet_jellege);
            setHazszam(hazszam);
            setEpulet_emelet_ajto(epulet_emelet_ajto);
            setTelefon(telefon);
            setEmail(email);
        }

        public string getNev() { return nev; }
        public int getIranyitoszam() { return iranyitoszam; }
        public string getVaros() { return varos; }
        public string getKozterulet() { return kozterulet; }
        public string getKozterulet_jellege() { return kozterulet_jellege; }
        public string getHazszam() { return hazszam; }
        public string getEpulet_emelet_ajto() { return epulet_emelet_ajto; }
        public string getTelefon() { return telefon; }
        public string getEmail() { return email; }

        public void setNev(string nev)
        {
            if (nev == null || nev == "")
            {
                MessageBox.Show("A név kitöltése kötelező!");
                throw new ArgumentNullException(nameof(nev));
            }
            else
            {
                this.nev = nev;
            }
        }

        public void setIranyitoszam(int iranyitoszam)
        {
            if (iranyitoszam >= 1000 && iranyitoszam <= 9999)
            {
                this.iranyitoszam = iranyitoszam;
            }
            else
            {
                MessageBox.Show("Nem (jól) adott meg az irányítószámot, kérem ellenőrizze!\nAz irányító szám 1111 és 9999 közé eső szám lehet.");
                throw new ArgumentException("Hibás az irányítószám.", nameof(iranyitoszam));
            }
        }

        public void setVaros(string varos)
        {
            if (varos == null || varos == "")
            {
                MessageBox.Show("A város kitöltése kötelező!");
                throw new ArgumentNullException(nameof(varos));
            }
            else
            {
                this.varos = varos;
            }
        }

        public void setKozterulet(string kozterulet)
        {
            if (kozterulet == null || kozterulet == "")
            {
                MessageBox.Show("A közterület kitöltése kötelező!");
                throw new ArgumentNullException(nameof(kozterulet));
            }
            else
            {
                this.kozterulet = kozterulet;
            }
        }

        public void setKozterulet_jellege(string kozterulet_jellege)
        {
            if (kozterulet_jellege == null || kozterulet_jellege == "")
            {
                MessageBox.Show("A közterület jellegének kitöltése kötelező!");
                throw new ArgumentNullException(nameof(kozterulet_jellege));
            }
            else
            {
                this.kozterulet_jellege = kozterulet_jellege;
            }
        }

        public void setHazszam(string hazszam)
        {
            if (hazszam == null || hazszam == "")
            {
                MessageBox.Show("A házszám kitöltése kötelező!");
                throw new ArgumentNullException(nameof(hazszam));
            }
            else
            {
                this.hazszam = hazszam;
            }
        }

        public void setEpulet_emelet_ajto(string epulet_emelet_ajto)
        {
            this.epulet_emelet_ajto = epulet_emelet_ajto;
        }

        public void setTelefon(string telefon)
        {
            this.telefon = telefon;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }
    }
}
