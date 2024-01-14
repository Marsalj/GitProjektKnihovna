using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKnihovna
{
    [Serializable()]
    public class Audiokniha : Kniha
    {

        private string _namluvil;
        public string Namluvil
        {
            get { return _namluvil; }
            set { _namluvil = value; }
        }

        public Audiokniha() { }
        public Audiokniha(string nazev, decimal cena, string namluvil) : base(nazev, cena)
        {
            Nazev = nazev;
            Cena = cena;
            Typ = "Audiokniha";
            Namluvil = namluvil;
        }
    }
}
