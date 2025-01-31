using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop3
{
	    internal class bankszamla
    {
        public int kovetkezoSzamlaSzam = 1000;
        public string SzamlaSzam { get; private set; }
        public string TulNev { get; set; }
        public double Egyenleg { get; set; }
        public string Valuta {  get; private set; }

        public int Limit = -10000;

        private List<Tranzakcio> tranzakciok = new List<Tranzakcio>();

        public bankszamla(string tulnev, int kezdoegyenleg, string valuta)
        {
            SzamlaSzam = $"ACC{kovetkezoSzamlaSzam++}";
            TulNev = tulnev;
            Egyenleg = kezdoegyenleg;
            Valuta = valuta;

    }

        public void befizet(int osszeg)
        {
            if (osszeg > 0)
            {
                Egyenleg += osszeg;
                tranzakciok.Add(new Tranzakcio("Befizetés", osszeg, DateTime.Now));
                Console.WriteLine($"Az összeg sikeresen befizetve a(z) {SzamlaSzam} számlára.");
            }
            else
            {
                Console.WriteLine("Hibás összeg");
            }
        }

        public void kifizet(int osszeg)
        {
            if ((Egyenleg - osszeg >= Limit))
            {
                if (osszeg > 0 && Egyenleg >= osszeg)
                {
                    EgyenlegFigyelo(Egyenleg, osszeg);
                    Egyenleg -= osszeg;
                    tranzakciok.Add(new Tranzakcio("Kifizetés", osszeg, DateTime.Now));
                    Console.WriteLine($"Az összeg kifizetve a(z) {SzamlaSzam} számláról.");
                }
                else
                {
                    Console.WriteLine("Az összeg nem lehet több mint a rendelkezésre álló egyenleg, vagy negatív.");
                }
            }
            else
            {
                Console.WriteLine($"Az összeg átlépi a limithatárt ({Limit}).");
            }
        }

        public string Szamlaadatok()
        {
            return $"\nSzámlaszám: {SzamlaSzam} \nTulajdonos: {TulNev} \nEgyenleg: {Egyenleg} \nValuta: {Valuta}";
        }

        public string TranzakcioTortenet()
        {
            Console.WriteLine($"Tranzakciók a(z) {SzamlaSzam} számlához:\n");
            return (string.Format(" ({0}).", string.Join("\n ", tranzakciok)));
        }
        public void KamatotHozzaad(double evesKamatSzazalek)
        {
            double Kamat = Egyenleg * (evesKamatSzazalek / 100);
            Egyenleg = Egyenleg + Kamat;
            Console.WriteLine($"Kamat sikeresen hozzáadva ({evesKamatSzazalek}%).");
        }
        public void VisszaSzamoz()
        {
            kovetkezoSzamlaSzam--;
        }
        private void EgyenlegFigyelo(double egyenleg, int osszeg)
        {
            if (egyenleg-osszeg<1000)
            {
                Console.WriteLine($"Figyelmeztetés: Az egyenleg 1000 {Valuta} alá csökkent.");
            }
        }
        public void ValutaValto(double arfolyam, int osszeg, string kezdovaluta, string celvaluta, string tipus)
        {
            double osszeg_valtva = 0;
            if (Valuta!=celvaluta)
            {
                Console.WriteLine($"A célvaluta nem egyezik a számla valutájával: {Valuta}");
            }
            else
            {
                osszeg_valtva = arfolyam * osszeg;
                Console.WriteLine($"Sikeresen átváltva {kezdovaluta}-ról {celvaluta}-ra.");
                if (tipus=="bef")
                {
                    Egyenleg += osszeg_valtva;
                    Console.WriteLine("Sikeresen hozzáadva az egyenleghez.");
                }
                else if (tipus=="kif")
                {
                    Egyenleg -= osszeg_valtva;
                    Console.WriteLine("Sikeresen levonva az egyenlegből.");
                }
            }
        }
    }
}
