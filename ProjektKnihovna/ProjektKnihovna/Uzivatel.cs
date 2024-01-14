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
        public string Jmeno {  get; set; }
        public string Email { get; set; }
        public string Heslo { get; set; }
        public BindingList<Kniha> Koupene { get; set; } = new BindingList<Kniha>();

        public Uzivatel() { }
        public Uzivatel(string jmeno, string email, string heslo)
        {
            Jmeno = jmeno;
            Email = email;
            Heslo = heslo;
        }
    }
}
