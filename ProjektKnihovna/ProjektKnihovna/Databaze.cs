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

        public static void Koupit(Kniha K)
        {
            PrihlasenyUzivatel.Koupene.Add(K);
        }

        public static void Odstranit(Kniha K)
        {
            PrihlasenyUzivatel.Koupene.Remove(K);
        }

        public static void Serializuj()
        {
            XmlSerializer serializer1 = new XmlSerializer(typeof(List<Uzivatel>));
            using (FileStream stream = new FileStream("uzivatele.xml", FileMode.Create))
            {
                serializer1.Serialize(stream, Uzivatele);
            }

            XmlSerializer serializer2 = new XmlSerializer(typeof(List<Kniha>));
            using (FileStream stream = new FileStream("nabidka.xml", FileMode.Create))
            {
                serializer2.Serialize(stream, Nabidka);
            }
        }

        public static void Deserializuj()
        {
            XmlSerializer deserializer1 = new XmlSerializer(typeof (List<Uzivatel>));
            using (FileStream stream = new FileStream("uzivatele.xml", FileMode.Open))
            {
                Uzivatele = (List<Uzivatel>)deserializer1.Deserialize(stream);
            }

            XmlSerializer deserializer2= new XmlSerializer(typeof(List<Kniha>));
            using (FileStream stream = new FileStream("nabidka.xml", FileMode.Open))
            {
                Nabidka = (List<Kniha>)deserializer2.Deserialize(stream);
            }
        }
    }
}
