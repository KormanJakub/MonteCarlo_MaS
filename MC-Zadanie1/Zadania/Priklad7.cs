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
            var pocetReplikacii = 100000;

            var genDopyt = new TriangularRNG(1000.0, 4000.0, 8500.0);

            var zostatok = 0;
            var trebaDorobit = 0;

            var minStrata = Double.MaxValue;
            var minVakcin = 0;

            var pocetVakcin = 0;


            for (pocetVakcin = 1000; pocetVakcin <= 5600; pocetVakcin++)
            {
                var strata = 0.0;

                for (int i = 0; i < pocetReplikacii; i++)
                {
                    dopyt = (int)Math.Round(genDopyt.Sample());

                    if (pocetVakcin < dopyt)
                    {
                        trebaDorobit = dopyt - pocetVakcin;
                    }
                    else
                    {
                        zostatok = pocetVakcin - dopyt;
                    }

                    strata += (trebaDorobit * naklady) + (zostatok * nepouzitelne);
                }

                var priemernaStrata = (double) strata / pocetReplikacii;

                if (minStrata > priemernaStrata)
                {
                    minStrata = priemernaStrata;
                    minVakcin = pocetVakcin;
                }
            }

            Console.WriteLine($"Pri pocte {minVakcin} vakcin je najmensia strata.");
        }
    }
}
