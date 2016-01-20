using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    public class IkkunaVE0
    {
        //tehdään public, ÄLÄ käytä! Edustaa "huonoa" ohjelmointitapaa
        public double leveys;
        public double korkeus;
        public double LaskePintaala()
        {
            return leveys * korkeus;
        }
    }

    public class Ikkuna
    {
        //property = ominaisuus
        //parempi tapa on avata "hallitusti" ominaisuuksien kautta
        private double korkeus;

        public double Korkeus
        {
            get { return korkeus; }
            set { korkeus = value; }
        }

        private double leveys;

        public double Leveys
        {
            get { return leveys; }
            set { leveys = value; }
        }
        //read-only tyyppinen property
        public double PintaAla
        {
            get
            {
                return korkeus * leveys;
            }
        }

        //Metodit
        public double LaskePintaAla()
        {
            //return korkeus * leveys;
            return LaskePintaAla2();
        }

        private double LaskePintaAla2()
        {
            return korkeus * leveys;
        }

    }
}
