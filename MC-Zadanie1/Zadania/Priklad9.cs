using System;
using UNIZA.FRI.RandomNumberGenerators;

namespace MonteCarlo.Zadania
{
    public class Priklad9
    {


        public void MonteCarlo()
        {

            var pocetDni = 7;
            var pocetReplikacii = 1000000;

            var letenkaDnes = 500.0;
            var naplnenostDnes = 0.27;

            var naplnenostLetu = 0.75;

            var stupne = 30;

            var kleslo = 0.0;
            var naplnenost = 0.0;

            var genKleslo = new TriangularRNG(1.0, 4.0, 11.0);
            var genNaplnenost = new UniformContinuousRNG(0.05, 0.14);


            double[] najlepsiaCenaLetenky = new double[pocetDni];


            for (int i = 0; i < pocetReplikacii; i++)
            {
                var myNaplnenost = 0.0;
                var myCenaLetenky = 0.0;
                bool cenaSaMeni = true;

                for (int j = 0; j < pocetDni; j++)
                {
                    
                    if (j == 0)
                    {
                        myCenaLetenky = letenkaDnes;
                        myNaplnenost = naplnenostDnes;
                        najlepsiaCenaLetenky[j] += myCenaLetenky;
                        continue;
                    }
                    
                    kleslo = genKleslo.Sample();
                    naplnenost = genNaplnenost.Sample();

                    myNaplnenost += naplnenost;

                    if (cenaSaMeni)
                    {
                        if (myNaplnenost < naplnenostLetu)
                        {
                            myCenaLetenky -= (myCenaLetenky / 100) * kleslo;
                        }
                        else
                        {
                            myCenaLetenky += (myCenaLetenky / 100) * stupne;
                            cenaSaMeni = false;
                        }
                    }

                    najlepsiaCenaLetenky[j] += myCenaLetenky;

                }
            }

            var minCena = Double.MaxValue;
            var minDen = -1;

            for (int i = 0; i < pocetDni; i++)
            {
                var priemernaCenaLetenky = (double) najlepsiaCenaLetenky[i] / pocetReplikacii;
                if (priemernaCenaLetenky < minCena)
                {
                    minCena = priemernaCenaLetenky;
                    minDen = i;
                }
            }

            Console.WriteLine($"Cestovatel by mal zakupit letenku {minDen}. den za {Math.Round(minCena, 2)} eur");

        }
    }
}
