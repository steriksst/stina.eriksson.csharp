using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visualisering
{
    class City
    {
        //Medlemsvariabler
        public string namn;
        public int antalInvanare;
        public int medelInkomst;
        public int antalTuristerPerAr;
        public List<Accommodations> accommodations; //en lista baserad på accommodations
        public int accommodationsCount = 0; //Startvärde
        public double medelKostnaden;

        //Konstruktor
        public City(string namn, int antalInvanare, int medelInkomst, int antalTuristerPerAr)
        {
            this.Namn = namn;
            this.AntalInvanare = antalInvanare;
            this.MedelInkomst = medelInkomst;
            this.AntalTuristerPerAr = antalTuristerPerAr;
            skapaLista(); //Här behövs en lista för Accommodations
        }
        //här skapas en metod för att skapa en lista
        private void skapaLista()
        {
            accommodations = new List<Accommodations>();
        }
        public void laggTillAccomodation(Accommodations ac) //Gör en räknare som lägger till 1 för varje rad i accommodation(?)
        {
            accommodationsCount++;
            accommodations.Add(ac);
        }

        //Getters/Setters
        public string Namn { get => namn; set => namn = value; }
        public int AntalInvanare { get => antalInvanare; set => antalInvanare = value; }
        public int MedelInkomst { get => medelInkomst; set => medelInkomst = value; }
        public int AntalTuristerPerAr { get => antalTuristerPerAr; set => antalTuristerPerAr = value; }
        public List<Accommodations> Accommodations { get => Accommodations; set => Accommodations = value; }
        public int AccommodationsCount { get { return accommodations.Count; } }
        public double MedelKostnaden { get => medelKostnaden; set => medelKostnaden = value; }

    }
}
