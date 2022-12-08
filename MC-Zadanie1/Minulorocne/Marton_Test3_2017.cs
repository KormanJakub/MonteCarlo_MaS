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

            var dobreUmiestnenie = 0;

            for (int i = 0; i < pocetReplikacii; i++)
            {
                for (int j = 1; j <= pretekarov; j++)
                {
                    var casPretekara = 0.0;

                    casPlavania = genCasPlavanie.Sample();
                    casPretekara += casPlavania;

                    casCyklistika = genCasCyklistika.Sample();
                    casDefekt = genCasDefekt.Sample();
                    
                    var pravdeCyklistika = pravedpodobnost.Sample();

                    if (pravdeCyklistika < 0.015)
                    {
                        casPretekara += casDefekt * 3;
                    } 
                    else if (pravdeCyklistika < 0.055)
                    {
                        casPretekara += casDefekt * 2;
                    } 
                    else if (pravdeCyklistika < 0.125)
                    {
                        casPretekara += casDefekt;
                    }

                    casPretekara += casCyklistika;


                    casBeh = genCasBeh.Sample();
                    casSnurok = genCasSnurok.Sample();

                    var praveSnurky = pravedpodobnost.Sample();

                    if (praveSnurky < 0.045)
                    {
                        casPretekara += casSnurok * 2;
                    } 
                    else if (praveSnurky < 0.145)
                    {
                        casPretekara += casSnurok;
                    }

                    casPretekara += casBeh;

                    if (casPretekara <= 140)
                    {
                        dobreUmiestnenie++;
                    }
                }
            }

            var priemernaPostupnost = (((double)dobreUmiestnenie / pretekarov) / pocetReplikacii) * 100;
            Console.WriteLine($"Z regionalnych pretekov sa na celosloveske kvalifikovalo - {Math.Round(priemernaPostupnost, 2)} % pretekarov");
        }
    }
}
