using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjektKnihovna
{
    public abstract class Kniha
    {
        private string _nazev;
        private decimal _cena;
        private string _typ;
        public string Nazev
        {
            get { return _nazev; }
            set { _nazev = value; }
        }

        public decimal Cena
        {
            get { return _cena; }
            set { _cena = value; }
        }

        public string Typ
        {
            get { return _typ; }
            set { _typ = value; }
        }

        public Kniha() { }
        public Kniha (string nazev, decimal cena)
        {
            Nazev = nazev;
            Cena = cena;
        }
    }
}
