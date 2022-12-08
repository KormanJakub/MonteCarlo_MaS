using UNIZA.FRI.RandomNumberGenerators;

namespace MonteCarlo.Minulorocne
{
    public class Medovniky_Test3
    {
        public void MonteCarlo()
        {
            var donesie = 100;
            var pocetReplikacii = 1000000;

            var dnesPredava = 0.0;
            var casPrichodov = 0.0;
            var poslednaHodina = 0.0;

            var genDnesPredava = new TriangularRNG(0.5, 0.75, 1.0);
            var genCasPrichodov = new TriangularRNG(2.0, 6.0, 10.0);
            var genPoslednaHodina = new UniformContinuousRNG(1.0, 3.0);

            var zisk = 0.0;
            var zostalo = 0.0;

            for (int i = 0; i < pocetReplikacii; i++)
            {
                var medovnikov = donesie;
                var dnesZisk = 0.0;
                var predava = 0.0;
                while (predava <= 8 * 60)
                {
                    dnesPredava = genDnesPredava.Sample();

                    if (medovnikov == 0)
                    {
                        medovnikov = 0;
                        break;
                    }

                    if (predava <= 7 * 60)
                    {
                        casPrichodov = genCasPrichodov.Sample();
                        predava += casPrichodov;
                        medovnikov--;

                        dnesZisk += dnesPredava;
                    }
                    else
                    {
                        if (medovnikov >= 10)
                        {
                            poslednaHodina = genPoslednaHodina.Sample();
                            predava += poslednaHodina;

                            medovnikov--;
                            dnesZisk += dnesPredava / 4;
                        } 
                        else
                        {
                            casPrichodov = genCasPrichodov.Sample();
                            predava += casPrichodov;
                            medovnikov--;

                            dnesZisk += dnesPredava;
                        }
                    }
                }

                zisk += dnesZisk;
                zostalo += medovnikov;
            }

            var priemernyZisk = (double)zisk / pocetReplikacii;
            var priemerneZostalo = (double)zostalo / pocetReplikacii;

            Console.WriteLine($"Babke ostáva {Math.Round(priemerneZostalo)} medovnikov. Kazdy den utrzi priemerne {Math.Round(priemernyZisk, 2)} eur.");

        }
    }
}
