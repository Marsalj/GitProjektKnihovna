using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjektKnihovna
{
    public static class Databaze
    {
        public static List<Uzivatel> Uzivatele { get; set; } = new List<Uzivatel>();
        public static List<Kniha> Nabidka { get; set; } = new List<Kniha>();
        public static Uzivatel PrihlasenyUzivatel { get; set; }

        static Databaze()
        {
            //Uzivatele = Deserializuj<Uzivatel>("uzivatele.xml");
            //Nabidka = Deserializuj<Kniha>("nabidka.xml");
        }

        public static void Koupit( Kniha K)
        {
            PrihlasenyUzivatel.Koupene.Add(K);
        }

        public static void Serializuj(string jmenoSouboru1, string jmenoSouboru2)
        {
            XmlSerializer serializer1 = new XmlSerializer(typeof(List<Uzivatel>));
            using (TextWriter writer = new StreamWriter(@jmenoSouboru1))
            {
                serializer1.Serialize(writer, Uzivatele);
            }

            XmlSerializer serializer2 = new XmlSerializer(typeof(List<Kniha>));
            using (TextWriter writer = new StreamWriter(@jmenoSouboru2))
            {
                serializer2.Serialize(writer, Nabidka);
            }
        }

    }
}
