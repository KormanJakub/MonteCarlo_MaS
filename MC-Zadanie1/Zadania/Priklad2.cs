using UNIZA.FRI.RandomNumberGenerators;

namespace MonteCarlo.Zadania
{
    public class Priklad2
    {

        public void MonteCarlo()
        {
            var pocetReplikacii = 1000000;

            var schopnyA = 70;
            var schopnyB = 90;

            var nakladyA = 0.0;
            var nakladyB = 0.0;

            var genNakladyA = new TriangularRNG(1.0, 1.75, 2.5);
            var genNakladyB = new TriangularRNG(0.7, 1.2, 1.7);

            var dopytA = 0.0;
            var dopytB = 0.0;

            var genDopytA = new UniformDiscreteRNG(40, 80);
            var genDopytB = new UniformDiscreteRNG(66, 155);

            var predajnaCenaA = 3;
            var predajnaCenaB = 2;

            var ziskA = 0.0;
            var ziskB = 0.0;

            var predaneMnozstvoA = 0.0;
            var predaneMnozstvoB = 0.0;

            for (int i = 0; i < pocetReplikacii; i++)
            {
                nakladyA = genNakladyA.Sample();
                nakladyB = genNakladyB.Sample();

                dopytA = genDopytA.Sample();
                dopytB = genDopytB.Sample();

                predaneMnozstvoA = Math.Min(schopnyA, dopytA);
                predaneMnozstvoB = Math.Min(schopnyB, dopytB);

                ziskA += (predaneMnozstvoA * predajnaCenaA) - (schopnyA * nakladyA);
                ziskB += (predaneMnozstvoB * predajnaCenaB) - (schopnyB * nakladyB);
            }

            var priemernyZiskA = ziskA / pocetReplikacii;
            var priemernyZiskB = ziskB / pocetReplikacii;

            Console.WriteLine($"Pri typu A zarobi: {priemernyZiskA}");
            Console.WriteLine($"Pri typu B zarobi: {priemernyZiskB}");
        }

    }
}
