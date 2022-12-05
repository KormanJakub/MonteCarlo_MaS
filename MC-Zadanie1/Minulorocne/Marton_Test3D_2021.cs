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

            var dobraCena = 0.0;
            var dobryDen = 0.0;

            for (int i = 0; i < pocetReplikacii; i++)
            {
                var cenaIneDni = 150.0;
                var kapacitaLietadla = 0.5;
                var najnizsiaCena = 150.0;
                var najlepsiDen = 0;
                for (int j = 0; j < dni; j++)
                {
                    kleslo = Math.Round(genKleslo.Sample(), 2);
                    stupnutie = Math.Round(genStupnutie.Sample(), 2);

                    kapacitaLietadla += stupnutie;

                    if (kapacitaLietadla >= 100)
                    {
                        break;
                    }

                    if (kapacitaLietadla <= naplnenost)
                    {
                        cenaIneDni -= (cenaIneDni / 100) * kleslo;
                    } else
                    {
                        cenaIneDni += (cenaIneDni / 100) * narastCeny;
                    }

                    if (najnizsiaCena > cenaIneDni)
                    {
                        najnizsiaCena = cenaIneDni;
                        najlepsiDen = j;
                    }
                }

                dobraCena += najnizsiaCena;
                dobryDen += najlepsiDen;
            }

            var priemernaCena = (double)dobraCena / pocetReplikacii;
            var priemernyDen = dobryDen / pocetReplikacii;

            Console.WriteLine($"Priemerná najnižšia cena letenky je {Math.Round(priemernaCena,2)} v deň {Math.Ceiling(priemernyDen)}");

        }
    }
}
