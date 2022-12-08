using UNIZA.FRI.RandomNumberGenerators;

namespace MonteCarlo._2015
{
    public class Zadanie_3
    {
        public void MonteCarlo()
        {
            var pocetReplikacii = 1000000;
            var pocetBezcov = 20;
            var pocetRozhodcov = 7;

            var hodnotenie = 0.0;
            var genHodnotenie = new TriangularRNG(0, 5.5, 6);

            double[] pocetBodov = new double[pocetRozhodcov];

            for (int i = 0; i < pocetReplikacii; i++)
            {
                for (int x = 0; x < pocetBezcov; x++)
                {
                    for (int j = 0; j < pocetRozhodcov; j++)
                    {
                        hodnotenie = Math.Round(genHodnotenie.Sample(), 1);
                        pocetBodov[j] = hodnotenie;
                    }
                }
            }

            for (int i = 0; i < pocetRozhodcov; i++)
            {

            }
        }
    }
}
