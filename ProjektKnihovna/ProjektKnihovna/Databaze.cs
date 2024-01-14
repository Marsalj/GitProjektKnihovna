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

        public static void Serializuj(string jmenoSouboru)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Uzivatel>));
            using (TextWriter writer  = new StringWriter(jmenoSouboru))
            {
                serializer.Serialize(writer, Uzivatele);
            }
        }

        public static BindingList<T> Deserializuj<T>(string jmenoSouboru)
        {
            using (Stream stream = File.Open(jmenoSouboru, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BindingList<T>));
                return serializer.Deserialize(stream) as BindingList<T>;
                stream.Close();
            }
        }

    }
}
