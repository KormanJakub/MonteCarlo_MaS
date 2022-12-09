using UNIZA.FRI.RandomNumberGenerators;

namespace MonteCarlo.Zadania
{
    public class Priklad4
    {
        public void MonteCarlo()
        {
            var pocetReplikacii = 100000;
            var pocetKrokov = 1000;

            var poholSa = 0;
            var genPoholSa = new UniformDiscreteRNG(0, 1);

            var celkovaPozicia = 0;
            for (int i = 0; i < pocetReplikacii; i++)
            {
                var pozicia = 0;
                for (int j = 0; j < pocetKrokov; j++)
                {
                    poholSa = genPoholSa.Sample();
                    if (poholSa == 0)
                    {
                        pozicia++;
                    } 
                    else
                    {
                        pozicia--;
                    }
                }
                celkovaPozicia += Math.Abs(pozicia);
            }

            var primernaPozicia = (double)celkovaPozicia / pocetReplikacii;
            var teoretickyOdhad = Math.Sqrt((2 * pocetKrokov) / Math.PI);

            Console.WriteLine($"Opity namornik priemerne skonci na pozicii {Math.Round(primernaPozicia, 2)}");
            Console.WriteLine($"Teoreticky odhad je {teoretickyOdhad}");

            var poholSa2D = 0;
            var genPoholSa2D = new UniformDiscreteRNG(0, 3);
            var celkovaPozicia2D = 0;

            for (int i = 0; i < pocetReplikacii; i++)
            {
                var poziciaX = 0;
                var poziciaY = 0;

                for (int j = 0; j < pocetKrokov; j++)
                {
                    poholSa2D = genPoholSa2D.Sample();

                    if (poholSa2D == 0)
                    {
                        poziciaX++;
                    } 
                    else if (poholSa2D == 1)
                    {
                        poziciaX--;
                    } 
                    else if (poholSa2D == 2)
                    {
                        poziciaY++;
                    } 
                    else
                    {
                        poziciaY--;
                    }
                }

                celkovaPozicia2D += (Math.Abs(poziciaX) + Math.Abs(poziciaY));
            }

            var primernaPozicia2D = (double)celkovaPozicia2D / pocetReplikacii;
            var teoretickyOdhad2D = Math.Sqrt((4 * pocetKrokov) / Math.PI);

            Console.WriteLine($"Opity namornik priemerne skonci na pozicii {Math.Round(primernaPozicia2D, 2)}");
            Console.WriteLine($"Teoreticky odhad je {teoretickyOdhad2D}");

            var poholSa3D = 0;
            var genPoholSa3D = new UniformDiscreteRNG(0, 5);
            var celkovaPozicia3D = 0;

            for (int i = 0; i < pocetReplikacii; i++)
            {
                var poziciaX = 0;
                var poziciaY = 0;
                var poziciaZ = 0;

                for (int j = 0; j < pocetKrokov; j++)
                {
                    poholSa3D = genPoholSa3D.Sample();

                    if (poholSa3D == 0)
                    {
                        poziciaX++;
                    }
                    else if (poholSa3D == 1)
                    {
                        poziciaX--;
                    }
                    else if (poholSa3D == 2)
                    {
                        poziciaY++;
                    }
                    else if (poholSa3D == 3)
                    {
                        poziciaY--;
                    } 
                    else if (poholSa3D == 4)
                    {
                        poziciaZ++;
                    } 
                    else
                    {
                        poziciaZ--;
                    }
                }

                celkovaPozicia3D += (Math.Abs(poziciaX) + Math.Abs(poziciaY) + Math.Abs(poziciaZ));
            }

            var primernaPozicia3D = (double)celkovaPozicia3D / pocetReplikacii;
            var teoretickyOdhad3D = Math.Sqrt((6 * pocetKrokov) / Math.PI);

            Console.WriteLine($"Opity namornik priemerne skonci na pozicii {Math.Round(primernaPozicia3D, 2)}");
            Console.WriteLine($"Teoreticky odhad je {teoretickyOdhad3D}");
        }
    }
}
