using UNIZA.FRI.RandomNumberGenerators;

namespace MonteCarlo.Zadania
{
    public class Priklad7
    {

        public void MonteCarlo()
        {
            var dopyt = 0;
            var nepouzitelne = 50;
            var naklady = 150;

            var genDopyt = new TriangularRNG(1000.0, 4000.0, 8500.0);

            var zostatok = 0;
            var trebaDorobit = 0;

            var minStrata = Double.MaxValue;
            var minVakcin = 0;

            var pocetVakcin = 0;


            for (pocetVakcin = 1000; pocetVakcin <= 10000; pocetVakcin++)
            {
                var strata = 0.0;

                dopyt = (int)Math.Round(genDopyt.Sample());

                if (pocetVakcin < dopyt)
                {
                    trebaDorobit = dopyt - pocetVakcin;
                } else
                {
                    zostatok = pocetVakcin - dopyt;
                }

                strata = (trebaDorobit * naklady) + (zostatok * nepouzitelne);

                if (minStrata > strata)
                {
                    minStrata = strata;
                    minVakcin = pocetVakcin;
                }
            }

            Console.WriteLine($"Pri pocte {minVakcin} vakcin je najmensia strata.");
        }
    }
}
