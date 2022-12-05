using UNIZA.FRI.RandomNumberGenerators;

namespace MonteCarlo.Zadania
{
    public class Priklad1
    {
        public void MonteCarlo()
        {
            var cenaVytlacku = 0.15;
            var pocetReplikacii = 1000000;
            var zVratenychCena = 0.65;

            var predajnaCena = 0.0;
            var casPredaja = 0.0;
            var predajPriemerne = 2.7;
            var dopytPoNovinach = 0;
            var pocetBalikov = 0;
            var kupenychNovin = 0;
            var predaneMnozstvo = 0;
            var zostatok = 0;
            var zaNepredaneKusiCena = cenaVytlacku * zVratenychCena;


            var maxBalikov = 0.0;
            var maxZisk = 0.0;

            var genPredajnaCena = new TriangularRNG(0.25, 0.6, 0.95);
            var genCasPredaja = new UniformContinuousRNG(250.0, 420.0);

            for (pocetBalikov = 5; pocetBalikov <= 20; pocetBalikov++)
            {
                var zisk = 0.0;
                for (int i = 0; i < pocetReplikacii; i++)
                {
                    kupenychNovin = pocetBalikov * 10;

                    casPredaja = Math.Round(genCasPredaja.Sample(), 2);
                    dopytPoNovinach = (int)Math.Round(casPredaja / predajPriemerne + 1);

                    predaneMnozstvo = Math.Min(kupenychNovin, dopytPoNovinach);

                    predajnaCena = genPredajnaCena.Sample();

                    zostatok = kupenychNovin - predaneMnozstvo;

                    zisk += predaneMnozstvo * predajnaCena + zostatok * zaNepredaneKusiCena - kupenychNovin * cenaVytlacku;
                }

                var priemernyZisk = zisk / pocetReplikacii;
                if (priemernyZisk > maxZisk)
                {
                    maxZisk = priemernyZisk;
                    maxBalikov = pocetBalikov;
                }
            }

            Console.WriteLine($"Pri nakupe {maxBalikov} balikov kurpier zarobit {maxZisk} za den.");
        }
    }
}
