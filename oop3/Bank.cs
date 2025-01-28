﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop3
{
	internal class Bank
	{
		private List<bankszamla> szamlak= new List<bankszamla>();
		
		public void SzamlaCreate(string TulNev, int kezdoEgyenleg)
		{
			bankszamla ujszamla=new bankszamla(TulNev, kezdoEgyenleg);
			szamlak.Add(ujszamla);
            Console.WriteLine($"Új számla létrehozva: {ujszamla.Szamlaadatok()}");
        }
		public bankszamla SzamlaKeres(string szamlaSzam)
		{
            foreach (var szamla in szamlak)
            {
                if (szamla.SzamlaSzam==szamlaSzam)
                {
					return szamla;
                }
            }
			return null;
        }
	}
}
