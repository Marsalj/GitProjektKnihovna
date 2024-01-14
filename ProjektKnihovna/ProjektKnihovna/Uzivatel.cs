using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKnihovna
{
    [Serializable()]
    public class Uzivatel
    {
        private string _jmeno;
        private string _email;
        private string _heslo;
        private decimal _penezenka;

        public string Jmeno
        {
            get { return _jmeno; }
            set { _jmeno = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Heslo
        {
            get { return _heslo; }
            set { _heslo = value; }
        }

        public decimal Penezenka
        {
            get { return _penezenka; }
            set { _penezenka += value;}
        }
        public BindingList<Kniha> Koupene { get; set; } = new BindingList<Kniha>();

        public Uzivatel() { }
        public Uzivatel(string jmeno, string email, string heslo)
        {
            Jmeno = jmeno;
            Email = email;
            Heslo = heslo;
            Penezenka = 0;
        }
    }
}
