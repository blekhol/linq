using System.Globalization;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Diak> diakok = File.ReadAllLines("diakok.csv")
                .Skip(1)
                .Select(sor =>
                {
                    string[] adatok = sor.Split(";");

                    return new Diak(adatok[0], int.Parse(adatok[1]), adatok[2], double.Parse(adatok[3], CultureInfo.GetCultureInfo("hu-HU")));
                }).ToList();

            Console.WriteLine("Átlagok");
            foreach (var o in diakok.GroupBy(diak => diak.Osztaly))
            {
                Console.WriteLine(o.Average(diak => diak.Atlag));
            }

            var osztalyok = diakok.GroupBy(diak => diak.Osztaly).OrderByDescending(osztaly => osztaly.Average(diak => diak.Atlag));

            Console.WriteLine();
            Console.WriteLine("Átlagok sorrendben: ");
            foreach (var o in osztalyok)
            {
                Console.WriteLine($"{o.Key}: {o.Average(diak => diak.Atlag)}");
            }

            Console.WriteLine();
            Console.WriteLine("Osztályokban legnagyobb átlagok(első):");
            foreach (var o in osztalyok)
            {
                var legjobbDiak = o.Where(diak => diak.Atlag == o.Max(diak => diak.Atlag));
                Console.WriteLine($"{o.Key}: {legjobbDiak.ToList()[0].Nev}, átlag: {legjobbDiak.ToList()[0].Atlag}");
            }

            var eletkorok = diakok.GroupBy(diak => diak.Eletkor);
            Console.WriteLine();
            Console.WriteLine("Életkorok: ");
            foreach (var e in eletkorok)
            {
                Console.WriteLine($"{e.Key}: {e.Count()}");
            }

            Console.WriteLine();
            Console.WriteLine("Osztályokban legnagyobb átlagok(az összes):");
            foreach (var o in osztalyok)
            {
                var legjobbDiak = o.Where(diak => diak.Atlag == o.Max(diak => diak.Atlag));
                foreach(var d in legjobbDiak)
                {
                    Console.WriteLine($"{o.Key}: {d.Nev}, átlag: {d.Atlag}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Bukó diákok: ");
            var buko = diakok.Where(diak => diak.Atlag < 2.00);
            if(buko.Count() > 0)
            {
                foreach (var b in buko)
                {
                    Console.WriteLine($"{b.Nev}: {b.Atlag}");
                }
            }
            else
            {
                Console.WriteLine("Nincs bukó diák");
            }
        }
    }
}
