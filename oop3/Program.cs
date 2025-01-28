namespace oop3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			bool fut = true;

			Bank bank = new Bank();
			while (fut)
            {
                Console.WriteLine("\t1. Új számla nyitása\n\t2. Összeg befizetése\n\t3. Összeg levétel\n\t4. Adatlekérés egy számláról\n\t5. Összes számla adatai\n\t6. Kilépés");
                Console.Write("Válassz egy lehetőséget: ");
                int opcio=Convert.ToInt32(Console.ReadLine());
				switch (opcio)
				{
					case 1:
						Console.Clear();
						Console.Write("Add meg a számlatulajdonos nevét: ");
						string szamlatul=Console.ReadLine();
                        Console.Write("Add meg a kezdőtőkét: ");
						int kezdoegyenleg=Convert.ToInt32(Console.ReadLine());
						bank.SzamlaCreate(szamlatul, kezdoegyenleg);
						bankszamla bankszamla1 = new bankszamla(szamlatul,kezdoegyenleg);
						Console.WriteLine($"Számla sikeresen létrehozva");
                        break;
					case 2:
                        Console.WriteLine("Adj meg egy számlaszámot: ");
						string szamlaszambefizet=Console.ReadLine();
						var szamlafizet=bank.SzamlaKeres(szamlaszambefizet);
                        if (szamlafizet!=null)
                        {
                            Console.Write("Add meg a befizetendő összeget: ");
							int osszeg=Convert.ToInt32(Console.ReadLine());
							szamlafizet.befizet(osszeg);
                        }
                        else
                        {
                            Console.WriteLine("Nincs ilyen számla.");
                        }
                        break;
					case 3:
						Console.WriteLine("Adj meg egy számlaszámot: ");
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
						Console.WriteLine("Adj meg egy számlaszámot: ");
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
						bank.Osszesbankszamla();
						break;
					case 6:
                        Console.WriteLine("Kilépés...");
						break;
					default:
                        Console.WriteLine("Kérlek adj meg érvényes számot.");
						break;
                }
            }
        }
	}
}
