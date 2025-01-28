using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop3
{
	internal class bankszamla
	{
		//1. statikus getter setter
		private static int kovetkezoSzamlaSzam = 1000;
		public string SzamlaSzam {  get; private set; }
		public string TulNev {  get; private set; }
		public int Egyenleg {  get; private set; }

		//konstruktorok
		//init kezdeti érték
		//public [osztaly neve]
		public bankszamla(string tulnev, int kezdoegyenleg)
		{
			SzamlaSzam = $"ACC{kovetkezoSzamlaSzam++}";
			TulNev = tulnev;
			Egyenleg= kezdoegyenleg;
		}

		//befizet method
		public void befizet(int osszeg)
		{
            if (osszeg>0)
            {
				Egyenleg += osszeg;
                Console.WriteLine($"Az összeg sikeresen befizetve a(z) {SzamlaSzam} számlára.");

            }
            else
            {
                Console.WriteLine("Hibás összeg");
            }
        }
		public void kifizet(int osszeg)
		{
            if (osszeg>0 && Egyenleg>=osszeg)
            {
				Egyenleg -= osszeg;
                Console.WriteLine($"Az összeg kifizetve a(z) {SzamlaSzam} számláról.");
            }
            else
            {
                Console.WriteLine("Az összeg nem lehet több mint a rendelkezésre álló egyenleg, vagy negatív.");
            }
        }
		public string Szamlaadatok()
		{
			return $"\nSzámlaszám: {SzamlaSzam} \nTulajdonos: {TulNev} \nEgyenleg: {Egyenleg}";
		}
	}
}
