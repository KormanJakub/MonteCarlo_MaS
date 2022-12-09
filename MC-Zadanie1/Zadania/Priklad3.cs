using UNIZA.FRI.RandomNumberGenerators;

namespace MonteCarlo.Zadania
{
    public class Priklad3
    {
        public void MonteCarlo()
        {
            var obsahStvorca = 1;

            var x = 0.0;
            var y = 0.0;

            var genX = new UniformContinuousRNG();
            var genY = new UniformContinuousRNG();

            var aktualnePi = 0.0;
            var pocetBodov = 0;
            var vsetkyBody = 0;

            while (Math.Abs(aktualnePi - Math.PI) >= 10e-6)
            {
                pocetBodov++;

                x = genX.Sample();
                y = genY.Sample();

                if (Math.Pow(x - 0.5, 2) + Math.Pow(y - 0.5, 2) <= Math.Pow(0.5, 2))
                {
                    vsetkyBody++;
                }

                aktualnePi = (obsahStvorca * ((double)vsetkyBody / pocetBodov)) / Math.Pow(0.5, 2);
            }

            Console.WriteLine($"Pocet bodov, ktore potrebujeme na dosiahnutie {pocetBodov}");
            Console.WriteLine($"Aproximovane PI je {aktualnePi}");
        }
    }
}
