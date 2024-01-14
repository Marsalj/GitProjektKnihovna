using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKnihovna
{
    [Serializable()]
    public class Ekniha : Kniha
    {
        private int _pocetStran;
        public int PocetStran
        {
            get { return _pocetStran; }
            set { _pocetStran = value; }
        }

        public Ekniha() { }
        public Ekniha(string nazev, decimal cena, int pocetStran) : base(nazev, cena)
        {
            Nazev = nazev;
            Cena = cena;
            Typ = "Ekniha";
            PocetStran = pocetStran;
        }
    }
}
