using UNIZA.FRI.RandomNumberGenerators;

namespace MonteCarlo.Zadania
{
    public class Priklad8
    {

        public void MonteCarlo()
        {
            var rozloha = 300;
            var stihnutie = 0.1;
            var cas = 20;
            var pocetReplikacii = 100000;

            var schopnost = 0.0;
            var genSchopnost = new TriangularRNG(1.0, 3.0, 3.5);
            var pocetKombajnov = 0;
            var pravdepodobnost = 0.0;


            while (pravdepodobnost <= stihnutie)
            {
                pocetKombajnov++;
                var prekrocenie = 0;

                for (int p = 0; p < pocetReplikacii; p++)
                {
                    var zozate = 0.0;

                    for (int i = 0; i < cas; i++)
                    {
                        for (int k = 0; k < pocetKombajnov; k++)
                        {
                            schopnost = Math.Round(genSchopnost.Sample(), 2);
                            zozate += schopnost;
                        }
                    }

                    if (zozate > rozloha)
                    {
                        prekrocenie++;
                    }
                }

                pravdepodobnost = (double)prekrocenie / pocetReplikacii;
            }

            Console.WriteLine($"Staci: {pocetKombajnov}");
            
        }
    }
}
