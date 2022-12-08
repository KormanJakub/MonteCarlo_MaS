using UNIZA.FRI.RandomNumberGenerators;

namespace MonteCarlo.Minulorocne
{
    public class Marton_Test3D_2021
    {
  
        public void MonteCarlo()
        {
            var dni = 7;
            var naplnenost = 0.8;
            var narastCeny = 35;
            var pocetReplikacii = 1000000;

            var kleslo = 0.0;
            var stupnutie = 0.0;
            var genKleslo = new TriangularRNG(10.0, 20.0, 30.0);
            var genStupnutie = new UniformContinuousRNG(0.1, 0.15);

            double[] pohodaCena = new double[dni];

            for (int i = 0; i < pocetReplikacii; i++)
            {
                var cenaIneDni = 0.0;
                var kapacitaLietadla = 0.0;
                var cenaSaMeni = true;

                for (int j = 0; j < dni; j++)
                {
                    if (j == 0)
                    {
                        cenaIneDni = 150.0;
                        kapacitaLietadla = 0.5;
                        pohodaCena[j] += cenaIneDni;
                        continue;
                    }

                    kleslo = Math.Round(genKleslo.Sample(), 2);
                    stupnutie = Math.Round(genStupnutie.Sample(), 2);

                    kapacitaLietadla += stupnutie;

                    if (kapacitaLietadla >= 100)
                    {
                        break;
                    }

                    if (cenaSaMeni)
                    {
                        if (kapacitaLietadla <= naplnenost)
                        {
                            cenaIneDni -= (cenaIneDni / 100) * kleslo;
                        }
                        else
                        {
                            cenaIneDni += (cenaIneDni / 100) * narastCeny;
                            cenaSaMeni = false;
                        }
                    }

                    pohodaCena[j] += cenaIneDni;
                }
            }

            var najnizsiaCena = Double.MaxValue;
            var najlepsiDen = -1;

            for (int i = 0; i < dni; i++)
            {
                var priemernaCena = (double)pohodaCena[i] / pocetReplikacii;
                if (najnizsiaCena > priemernaCena)
                {
                    najnizsiaCena = priemernaCena;
                    najlepsiDen = i;
                }
            }

            Console.WriteLine($"Priemerná najnižšia cena letenky je {Math.Round(najnizsiaCena, 2)} v deň {najlepsiDen}");

        }
    }
}
