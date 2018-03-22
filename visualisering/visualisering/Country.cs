using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visualisering
{
    class Country
    {
        //Medlemsvariabler
        public string namn;
        public int antalInvanare;
        public int bPNperCapita;
        public List<City> cities; //En lista baserad på City-klassen

        //Konstruktor
        public Country(string namn, int antalInvanare, int bPNperCapita)
        {
            this.namn = namn;
            this.antalInvanare = antalInvanare;
            this.bPNperCapita = bPNperCapita;
            skapaLista(); //Här behövs en lista för City
        }

        //här skapas en metod för att skapa en lista
        public void skapaLista()
        {
            cities = new List<City>();
        }

        //Getters/Setters
        public string Namn { get => namn; set => namn = value; }
        public int AntalInvanare { get => antalInvanare; set => antalInvanare = value; }
        public int BPNperCapita { get => bPNperCapita; set => bPNperCapita = value; }
        public List<City> Cities { get => cities; set => cities = value; }

    }
}
