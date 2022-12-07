using UNIZA.FRI.RandomNumberGenerators;

namespace MonteCarlo.Minulorocne
{
    public class Jankovic_Test3_2020
    {
        public void MonteCarlo()
        {
            var peniaze = 10000.0;
            var pocetReplikacii = 1000000;
            var pocetDni = 364;

            var fondA = 0.0;
            var fondB = 0.0;

            var genFondA = new TriangularRNG(-5, 1.4, 3.5);
            var genFondB = new UniformContinuousRNG(-2.5, 4.5);

            var celkovyFondA = 0.0;
            var celkovyFondB = 0.0;

            for (int i = 0; i < pocetReplikacii; i++)
            {
                var obehNaFondeA = peniaze;
                var obehNaFondeB = peniaze;

                for (int j = 1; j <= pocetDni; j++)
                {
                    fondA = (1.0 + (genFondA.Sample() / 100));
                    obehNaFondeA *= fondA;

                    if (j % 7 == 0)
                    {
                        fondB = (1.0 + (genFondB.Sample() / 100));
                        obehNaFondeB *= fondB;
                    }
                }

                celkovyFondA += obehNaFondeA;
                celkovyFondB += obehNaFondeB;
            }

            var priemernyZarobokFondA = celkovyFondA / pocetReplikacii;
            var priemernyZarobokFondB = celkovyFondB / pocetReplikacii;

            Console.WriteLine($"Celkova hodnota majetku po 52 týždňoch investovania do fondu A bude: {priemernyZarobokFondA}");
            Console.WriteLine($"Celkova hodnota majetku po 52 týždňoch investovania do fondu B bude: {priemernyZarobokFondB}");
        }
    }
}
