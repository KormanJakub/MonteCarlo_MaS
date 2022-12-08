using UNIZA.FRI.RandomNumberGenerators;

namespace MonteCarlo.Minulorocne
{
    public class Jancigova_Test_2016
    {
        public void MonteCarlo()
        {
            var pocetReplikacii = 1000000;
            var pocetStran = 3407;

            var anickaPrecitala = 0.0;
            var anickaDni = 0;

            var zuzkaPrecitala = 0.0;

            var genAnickaPrecitala = new NormalDistributionRNG(150.0, 33.0);
            var genAnickaDni = new UniformDiscreteRNG(1, 5);

            var genZuzkaPrecitala = new TriangularRNG(29.0, 34.0, 52.0);

            var pravdeZuzka = 0;
            var pravdeAnicka = 0;

            for (int i = 0; i < pocetReplikacii; i++)
            {
                var precitaneAnicka = 0.0;
                var precitaneZuzka = 0.0;

                var pocetDniAnicka = 0;
                var pocetDniZuzka = 0;

                anickaDni = genAnickaDni.Sample();

                while (precitaneAnicka <= pocetStran)
                {
                    anickaPrecitala = genAnickaPrecitala.Sample();

                    precitaneAnicka += anickaPrecitala;
                    pocetDniAnicka += anickaDni;

                    if (pocetDniAnicka >= pocetStran)
                    {
                        break;
                    }
                }

                while (precitaneZuzka <= pocetStran)
                {
                    zuzkaPrecitala = genZuzkaPrecitala.Sample();

                    precitaneZuzka += zuzkaPrecitala;
                    pocetDniZuzka++;

                    if (pocetDniZuzka >= pocetStran)
                    {
                        break;
                    }
                }

                if (pocetDniZuzka < pocetDniAnicka)
                {
                    pravdeZuzka++;
                } 
                else
                {
                    pravdeAnicka++;
                }
            }

            var pravdePriemerZuzka = ((double)pravdeZuzka / pocetReplikacii) * 100;
            var pravdePriemerAnicka = ((double)pravdeAnicka / pocetReplikacii) * 100;

            Console.WriteLine($"Zuzka precita {Math.Round(pravdePriemerZuzka, 2)}");
            Console.WriteLine($"Anicka precita {Math.Round(pravdePriemerAnicka, 2)}");
        }
    }
}
