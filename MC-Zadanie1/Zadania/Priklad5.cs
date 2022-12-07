using UNIZA.FRI.RandomNumberGenerators;

namespace MonteCarlo.Zadania
{
    public class Priklad5
    {

        public void MonteCarlo()
        {
            var pocetReplikacii = 10000000;
            var pravdepodobnostAno = 0.8;

            var genVestica1 = new UniformContinuousRNG();
            var genVestica2 = new UniformContinuousRNG();
            var genVestica3 = new UniformContinuousRNG();

            var genVesticaT1 = new TriangularRNG(0.3, 0.8, 1);
            var genVesticaT2 = new TriangularRNG(0.3, 0.8, 1);
            var genVesticaT3 = new TriangularRNG(0.3, 0.8, 1);

            var pravdepodobnost1a2 = 0;
            var pocetRovnakych = 0;

            var pocetRovnakychPriTroch = 0;
            var pravde1a2a3 = 0;

            var pravdepodobnost1a2T = 0;
            var pocetRovnakychT = 0;

            var pocetRovnakychPriTrochT = 0;
            var pravde1a2a3T = 0;

            for (int i = 0; i < pocetReplikacii; i++)
            {
                var vestica1 = genVestica1.Sample() < pravdepodobnostAno;
                var vestica2 = genVestica2.Sample() < pravdepodobnostAno;
                var vestica3 = genVestica3.Sample() < pravdepodobnostAno;

                var vestica1T = genVestica1.Sample() < genVesticaT1.Sample();
                var vestica2T = genVestica2.Sample() < genVesticaT2.Sample();
                var vestica3T = genVestica3.Sample() < genVesticaT3.Sample();

                if (vestica1 == vestica2)
                {
                    pocetRovnakych++;
                    if (vestica1 && vestica2)
                    {
                        pravdepodobnost1a2++;
                    }
                }

                if (vestica1T == vestica2T)
                {
                    pocetRovnakychT++;
                    if (vestica1T && vestica2T)
                    {
                        pravdepodobnost1a2T++;
                    }
                }

                if (vestica1 == vestica2 && vestica1 == vestica3 && vestica2 == vestica3)
                {
                    pocetRovnakychPriTroch++;

                    if (vestica1 && vestica2 && vestica3)
                    {
                        pravde1a2a3++;
                    }
                }

                if (vestica1T == vestica2T && vestica1T == vestica3T && vestica2T == vestica3T)
                {
                    pocetRovnakychPriTrochT++;

                    if (vestica1T && vestica2T && vestica3T)
                    {
                        pravde1a2a3T++;
                    }
                }
            }

            var priemernaPravde1a2 = ((double)pravdepodobnost1a2 / pocetRovnakych) * 100;
            var priemernaPravde1a2a3 = ((double)pravde1a2a3 / pocetRovnakychPriTroch) * 100;

            var priemernaPravde1a2T = ((double)pravdepodobnost1a2T / pocetRovnakychT) * 100;
            var priemernaPravde1a2a3T = ((double)pravde1a2a3T / pocetRovnakychPriTrochT) * 100;

            Console.WriteLine($"Prva a druha maju zaroven pravdu {Math.Round(priemernaPravde1a2, 2)}");
            Console.WriteLine($"Prva a druha maju zaroven pravdu {Math.Round(priemernaPravde1a2a3, 2)}");
            Console.WriteLine($"Prva a druha maju zaroven pravdu {Math.Round(priemernaPravde1a2T, 2)}");
            Console.WriteLine($"Prva a druha maju zaroven pravdu {Math.Round(priemernaPravde1a2a3T, 2)}");
        }
    }
}
