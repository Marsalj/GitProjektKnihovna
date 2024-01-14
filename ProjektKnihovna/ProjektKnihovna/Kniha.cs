using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjektKnihovna
{
    [Serializable()]
    [XmlInclude(typeof(Audiokniha)), XmlInclude(typeof(Ekniha))]
    public abstract class Kniha
    {
        public string Nazev {  get; set; }
        public decimal Cena { get; set; }
        public string Typ { get; set; } = "";
        public Kniha() { }
        public Kniha (string nazev, decimal cena)
        {
            Nazev = nazev;
            Cena = cena;
        }
    }
}
