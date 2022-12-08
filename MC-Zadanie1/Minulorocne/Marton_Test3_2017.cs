using UNIZA.FRI.RandomNumberGenerators;

namespace MonteCarlo.Minulorocne
{
    public class Marton_Test3_2017
    {
        public void MonteCarlo()
        {
            var pocetReplikacii = 1000000;
            var pretekarov = 66;

            var casPlavania = 0.0;
            var casCyklistika = 0.0;
            var casBeh = 0.0;

            var genCasPlavanie = new TriangularRNG(20.0, 32.0, 40.0);
            var genCasCyklistika = new TriangularRNG(60.0, 70.0, 86.0);
            var genCasBeh = new TriangularRNG(36.0, 46.0, 63.0);

            var casDefekt = 0.0;
            var casSnurok = 0.0;

            var genCasDefekt = new UniformContinuousRNG(0.5, 5.0);
            var genCasSnurok = new UniformContinuousRNG(1.0, 3.0);

            var pravedpodobnost = new UniformContinuousRNG();

            var celkoveDobre = 0.0;

            for (int i = 0; i < pocetReplikacii; i++)
            {
                var dobreUmiestnenie = 0;
                for (int j = 1; j <= pretekarov; j++)
                {
                    var casPretekara = 0.0;

                    casPlavania = genCasPlavanie.Sample();
                    casPretekara += casPlavania;

                    casCyklistika = genCasCyklistika.Sample();
                    
                    var pravdeCyklistika = pravedpodobnost.Sample();
                    var pocetDefektov = 0;

                    if (pravdeCyklistika < 0.015)
                    {
                        pocetDefektov = 3;
                    } 
                    else if (pravdeCyklistika < 0.055)
                    {
                        pocetDefektov = 2;
                    } 
                    else if (pravdeCyklistika < 0.125)
                    {
                        pocetDefektov = 1;
                    }

                    for (int k = 0; k < pocetDefektov; k++)
                    {
                        casDefekt = genCasDefekt.Sample();
                        casPretekara += casDefekt;
                    }
                    casPretekara += casCyklistika;

                    casBeh = genCasBeh.Sample();
                    var pocetSnurok = 0;
                    var praveSnurky = pravedpodobnost.Sample();

                    if (praveSnurky < 0.045)
                    {
                        pocetSnurok = 2;
                    } 
                    else if (praveSnurky < 0.145)
                    {
                        pocetSnurok = 1;
                    }

                    for (int k = 0; k < pocetSnurok; k++)
                    {
                        casSnurok = genCasSnurok.Sample();
                        casPretekara += casSnurok;
                    }

                    casPretekara += casBeh;

                    if (casPretekara <= 140)
                    {
                        dobreUmiestnenie++;
                    }
                }

                celkoveDobre += (double)dobreUmiestnenie / pretekarov;
            }

            var priemernaPostupnost = ((double)celkoveDobre / pocetReplikacii) * 100;
            Console.WriteLine($"Z regionalnych pretekov sa na celosloveske kvalifikovalo - {Math.Round(priemernaPostupnost, 2)} % pretekarov");
        }
    }
}
