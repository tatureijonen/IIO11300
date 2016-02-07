using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    class Liiga
    {
        private string etunimi;

        public string Etunimi
        {
            get { return etunimi; }
            set { etunimi = value; }
        }

        private string sukunimi;

        public string Sukunimi
        {
            get { return sukunimi; }
            set { sukunimi = value; }
        }

        private string siirtohinta;

        public string Siirtohinta
        {
            get { return siirtohinta; }
            set { siirtohinta = value; }
        }

        private string seura;

        public string Seura
        {
            get { return seura; }
            set { seura = value; }
        }

        #region CONSTRUCTORS
        public Liiga()
        {
            etunimi = "Etunimi";
            sukunimi = "Sukunimi";
            siirtohinta = "0";
            seura = "Seura";
        }

        public Liiga(string enimi, string snimi, string hinta, string sra)
        {
            this.etunimi = enimi;
            this.sukunimi = snimi;
            this.siirtohinta = hinta;
            this.seura = sra;
        }
        #endregion

        #region METHODS
        public string KokoNimi
        {
            get
            {
                return etunimi + " " + sukunimi;
            }
        }

        public string EsitysNimi
        {
            get
            {
                return etunimi + " " + sukunimi + ", " + seura;
            }
        }
        #endregion
    }
}
