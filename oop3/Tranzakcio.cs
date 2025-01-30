using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop3
{
    internal class Tranzakcio
    {
        public string Tipus { get; }
        public int Osszeg { get; }
        public DateTime Datum { get; }

        public Tranzakcio(string tipus, int osszeg, DateTime datum)
        {
            Tipus = tipus;
            Osszeg = osszeg;
            Datum = datum;
        }

        public override string ToString()
        {
            return $"{Datum}: {Tipus} - {Osszeg} Ft";
        }

    }
}
