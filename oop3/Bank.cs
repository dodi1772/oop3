using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop3
{
    internal class Bank
    {
        private List<bankszamla> szamlak = new List<bankszamla>();

        public void SzamlaCreate(string TulNev, int kezdoEgyenleg)
        {
            bankszamla ujszamla = new bankszamla(TulNev, kezdoEgyenleg);
            szamlak.Add(ujszamla);
            Console.Clear();
            Console.WriteLine($"Új számla létrehozva: {ujszamla.Szamlaadatok()}");
        }
        public bankszamla SzamlaKeres(string szamlaSzam)
        {
            foreach (var szamla in szamlak)
            {
                if (szamla.SzamlaSzam == szamlaSzam)
                {
                    return szamla;
                }
            }
            return null;
        }
        public void Osszesbankszamla()
        {
            if (szamlak.Count == 0)
            {
                Console.WriteLine("Nincs egy számla sem a rendszerben.");
            }
            else
            {
                Console.WriteLine("Összes számla:");
                foreach (var szamla in szamlak)
                {
                    Console.WriteLine($"{szamla.Szamlaadatok()}");
                }
            }
        }
        public bankszamla GetTranzakcioTortenet(string Szamlaszam)
        {
            foreach (var szamla in szamlak)
            {
                if (szamla.SzamlaSzam==Szamlaszam)
                {
                    return szamla;
                }
            }
            return null;
        }
        public void OsszesKamatKiszamitas(double evesKamatSzazalek)
        {
            if (szamlak.Count==0)
            {
                Console.WriteLine("Nincs számla a rendszerben.");
            }
            else
            {
                Console.WriteLine($"Összes számla kamatai ({evesKamatSzazalek}%): ");
                foreach (var szamla in szamlak)
                {
                    double kamat = (szamla.Egyenleg * (evesKamatSzazalek/100));
                    kamat=Math.Round(kamat,2);
                    Console.WriteLine($"{szamla.SzamlaSzam} - {kamat} HUF");
                }
            }
        }
        public void SzamlaTorles(string Szamlaszam)
        {
            int tempint = 0;
            for (int i = 0; i < szamlak.Count; i++)
            {
                if (szamlak[i].SzamlaSzam==Szamlaszam)
                {
                    tempint = i;
                    break;
                }
            }
            Console.WriteLine($"A(z) {szamlak[tempint].SzamlaSzam} számla törlése sikeresen megtörtént.");
            szamlak[tempint].VisszaSzamoz();
            szamlak.RemoveAt(tempint);
        }
        public void UjTulaj(string Szamlaszam, string tulnev)
        {
            foreach (var szamla in szamlak)
            {
                if (szamla.SzamlaSzam==Szamlaszam)
                {
                    szamla.TulNev = tulnev;
                    Console.WriteLine($"A tulajdonos cseréje sikeres volt. Új tulaj neve: {tulnev}");
                }
            }
        }
        public void Jelentes()
        {
            double sumvaltozo = 0;
            Console.WriteLine("Összes tulajdonos neve:");
            foreach (var szamla in szamlak)
            {
                Console.WriteLine(szamla.TulNev,"\n");
                sumvaltozo += szamla.Egyenleg;
            }
            Console.WriteLine($"Összes banki egyenleg: {sumvaltozo}");
            Console.WriteLine($"Számlánkénti átlag: {sumvaltozo/szamlak.Count}");

        }
        public void SzamlaKeresTulAlapjan(string tulnev)
        {
            Console.WriteLine($"'{tulnev}'-hez tartozó számlák:");
            foreach (var szamla in szamlak)
            {
                if (szamla.TulNev==tulnev)
                {
                    Console.WriteLine($"{szamla.SzamlaSzam} - {szamla.Egyenleg} HUF");
                }
            }
        }
    }
}
