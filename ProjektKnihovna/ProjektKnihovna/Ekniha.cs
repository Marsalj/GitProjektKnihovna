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
        public int PocetStran {  get; set; }
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
