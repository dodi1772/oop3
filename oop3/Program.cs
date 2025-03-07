﻿namespace oop3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool fut = true;
            Bank bank = new Bank();
            string tipus = "";
            Console.Write("Adj meg egy éves kamatszázalékot: ");
            int eveskamatszazalek=Convert.ToInt32(Console.ReadLine());
            while (fut)
            {
                Console.WriteLine("\t1. Új számla nyitása\n\t2. Összeg befizetése\n\t3. Összeg levétel\n\t4. Adatlekérés egy számláról\n\t5. Összes számla adatai\n\t6. Tranzakciók számlán belül\n\t7. Összes számla kamat kiszámolása\n\t8. Számla törlése\n\t9. Számla áthelyezése új tulajdonoshoz\n\t10. Jelentés generálás\n\t11. Keresés név alapján\n\t12. Más valuta befizetés\n\t13. Más valuta levétele\n\t14. Kilépés");
                Console.Write("Válassz egy lehetőséget: ");
                int opcio = Convert.ToInt32(Console.ReadLine());
                switch (opcio)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Add meg a számlatulajdonos nevét: ");
                        string szamlatul = Console.ReadLine();
                        Console.Write("Add meg a kezdőtőkét: ");
                        int kezdoegyenleg = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Milyen valuta alapú legyen a számla: ");
                        string valuta= Console.ReadLine();
                        bank.SzamlaCreate(szamlatul, kezdoegyenleg, valuta);
                        Console.WriteLine($"Számla sikeresen létrehozva");
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Adj meg egy számlaszámot: ");
                        string szamlaszambefizet = Console.ReadLine();
                        var szamlafizet = bank.SzamlaKeres(szamlaszambefizet);
                        if (szamlafizet != null)
                        {
                            Console.Write("Add meg a befizetendő összeget: ");
                            int osszeg = Convert.ToInt32(Console.ReadLine());
                            szamlafizet.befizet(osszeg);
                            szamlafizet.KamatotHozzaad(eveskamatszazalek);
                        }
                        else
                        {
                            Console.WriteLine("Nincs ilyen számla.");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Adj meg egy számlaszámot: ");
                        string szamlabolkivetel = Console.ReadLine();
                        var szamlakivetel = bank.SzamlaKeres(szamlabolkivetel);
                        if (szamlakivetel != null)
                        {
                            Console.Write("Add meg a kifizetendő összeget: ");
                            int osszeg = Convert.ToInt32(Console.ReadLine());
                            szamlakivetel.kifizet(osszeg);
                        }
                        else
                        {
                            Console.WriteLine("Nincs ilyen számla.");
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Adj meg egy számlaszámot: ");
                        string szamlaszam = Console.ReadLine();
                        var szamlavane = bank.SzamlaKeres(szamlaszam);
                        if (szamlavane != null)
                        {
                            Console.WriteLine($"{szamlavane.Szamlaadatok()}");
                        }
                        else
                        {
                            Console.WriteLine("Nincs ilyen számla.");
                        }
                        break;
                    case 5:
                        Console.Clear();
                        bank.Osszesbankszamla();
                        break;
                    case 6:
                        Console.Clear();
                        Console.Write("Adj meg egy számlaszámot: ");
                        string szamlaSzam = Console.ReadLine();
                        var tranzakcioadat = bank.GetTranzakcioTortenet(szamlaSzam);
                        if (tranzakcioadat != null)
                        {
                            Console.WriteLine($"{tranzakcioadat.TranzakcioTortenet()}");
                        }
                        else
                        {
                            Console.WriteLine("Nincs ilyen számla.");
                        }
                        break;
                    case 7:
                        Console.Clear();
                        bank.OsszesKamatKiszamitas(eveskamatszazalek);
                        break;
                    case 8:
                        Console.Clear();
                        Console.Write("Adj meg egy számlaszámot: ");
                        string szamSzam= Console.ReadLine();
                        var vaneszamla = bank.SzamlaKeres(szamSzam);
                        if (vaneszamla!=null)
                        {
                            if (vaneszamla.Egyenleg==0)
                            {
                                bank.SzamlaTorles(szamSzam);
                            }
                            else
                            {
                                Console.WriteLine("A számla egyenlege nem 0.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nincs ilyen számla.");
                        }
                        break;
                    case 9:
                        Console.Clear();
                        Console.Write("Adj meg egy számlaszámot: ");
                        string szSzam= Console.ReadLine();
                        var szKereses = bank.SzamlaKeres(szSzam);
                        if (szKereses!=null)
                        {
                            Console.Write("Új tulaj neve: ");
                            string ujTulajdonos=Console.ReadLine();
                            bank.UjTulaj(szSzam, ujTulajdonos);
                        }
                        else
                        {
                            Console.WriteLine("Nincs ilyen számla.");
                        }
                        break;
                    case 10:
                        Console.Clear();
                        bank.Jelentes();
                        break;
                    case 11:
                        Console.Clear();
                        Console.Write("Add meg a tulajdonos nevét: ");
                        string tulajnev=Console.ReadLine();
                        bank.SzamlaKeresTulAlapjan(tulajnev);
                        break;
                    case 12:
                        Console.Clear();
                        tipus = "bef";
                        Console.Write("Adj meg egy számlaszámot: ");
                        string szaSzam = Console.ReadLine();
                        var szKereses1 = bank.SzamlaKeres(szaSzam);
                        if (szKereses1 != null)
                        {
                            Console.Write("Add meg a kezdő árfolyamot: ");
                            string kezdoarfolyam = Console.ReadLine();
                            Console.Write("Add meg a célárfolyamot (meg kell egyeznie a bankszámla valutájával): ");
                            string celarfolyam = Console.ReadLine();
                            Console.Write($"Add meg az árfolyamot(ponttal elválasztva olyan logikával, hogy mennyivel kell szorozni a(z) {kezdoarfolyam}-ot, hogy {celarfolyam}-ot kapj.): ");
                            double valutabeker = Convert.ToDouble(Console.ReadLine());
                            Console.Write($"Add meg {kezdoarfolyam}-ban a berakni kívánt összeget: ");
                            int bekerosszeg = Convert.ToInt32(Console.ReadLine());
                            szKereses1.ValutaValto(valutabeker,bekerosszeg,kezdoarfolyam,celarfolyam,tipus);
                        }
                        else
                        {
                            Console.WriteLine("Nincs ilyen számla.");
                        }

                        break;
                    case 13:
                        Console.Clear();
                        tipus = "kif";
                        Console.Write("Adj meg egy számlaszámot: ");
                        string szaSzam1 = Console.ReadLine();
                        var szKereses2 = bank.SzamlaKeres(szaSzam1);
                        if (szKereses2 != null)
                        {
                            Console.Write("Add meg a kezdő árfolyamot: ");
                            string kezdoarfolyam = Console.ReadLine();
                            Console.Write("Add meg a célárfolyamot (meg kell egyeznie a bankszámla valutájával): ");
                            string celarfolyam = Console.ReadLine();
                            Console.Write($"Add meg az árfolyamot(ponttal elválasztva olyan logikával, hogy mennyivel kell szorozni a(z) {kezdoarfolyam}-ot, hogy {celarfolyam}-ot kapj.): ");
                            double valutabeker = Convert.ToDouble(Console.ReadLine());
                            Console.Write($"Add meg {kezdoarfolyam}-ban a kivenni kívánt összeget: ");
                            int bekerosszeg = Convert.ToInt32(Console.ReadLine());

                            szKereses2.ValutaValto(valutabeker, bekerosszeg, kezdoarfolyam, celarfolyam, tipus);
                        }
                        else
                        {
                            Console.WriteLine("Nincs ilyen számla.");
                        }
                        break;
                    case 14:
                        Console.Clear();
                        Console.WriteLine("Kilépés...");
                        fut = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Kérlek adj meg érvényes számot.");
                        break;
                }
            }
        }
    }
}
