using System;
using UNIZA.FRI.RandomNumberGenerators;

namespace MonteCarlo.Minulorocne
{
    public class Medovniky_Test3
    {
        public void MonteCarlo()
        {
            var pocetReplikacii = 1000000;

            var pocetMedovnikov = 100;

            var cenaPredajGen = new TriangularRNG(0.5, 0.75, 1.0);
            var casMedziPredajmi = new TriangularRNG(2.0, 6.0, 10.0);
            var casMedziPredajmiRychlo = new UniformContinuousRNG(1.0, 3.0);

            var celkovOstalo = 0;
            var celkovyZisk = 0.0;

            for (int i = 0; i < pocetReplikacii; i++)
            {
                var cenaPredaj = cenaPredajGen.Sample();

                var predane = 0;
                var cas = 0.0;
                var predavajuSaRychlo = false;
                var ziskZaDen = 0.0;

                while (cas < 8.0 * 60.0)
                {
                    predane++;
                    ziskZaDen += cenaPredaj;

                    if (predane == pocetMedovnikov)
                        break;

                    cas += predavajuSaRychlo ? casMedziPredajmiRychlo.Sample() : casMedziPredajmi.Sample();

                    if (8 * 60 - cas <= 60 && pocetMedovnikov - predane > 10 && !predavajuSaRychlo)
                    {
                        cenaPredaj /= 4.0;
                        predavajuSaRychlo = true;
                    }
                }

                celkovOstalo += pocetMedovnikov - predane;
                celkovyZisk += ziskZaDen;
            }

            var priemernyZisk = (double)celkovyZisk / pocetReplikacii;
            var priemerneZostalo = (double)celkovOstalo / pocetReplikacii;

            Console.WriteLine($"Babke ostáva {Math.Round(priemerneZostalo)} medovnikov. Kazdy den utrzi priemerne {Math.Round(priemernyZisk, 2)} eur.");

        }
    }
}
