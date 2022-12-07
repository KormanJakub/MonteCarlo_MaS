using UNIZA.FRI.RandomNumberGenerators;

namespace MonteCarlo._2015
{
    public class Zadanie_1
    {

        public void MonteCarlo()
        {
            var pocetZapasov = 15;
            var pocetReplikacii = 1000000;

            var prvaStvrtina = 0;
            var druhaStvrtina = 0;
            var tretiaStvrtina = 0;
            var stvrtaStvrtina = 0;

            var genPrvaStvrtina = new TriangularRNG(22.0, 44.0, 66.0);
            var genDruhaStvrtina = new UniformDiscreteRNG(25, 45);
            var genTretiaStvrtina = new UniformDiscreteRNG(30, 60);
            var genStvtaStvrtina = new TriangularRNG(28.0, 40.0, 65.0);

            var celkoveBody = 0;


            for (int i = 0; i < pocetReplikacii; i++)
            {
                var pocetBodov = 0;
                var malViacAko100 = 0;
                for (int j = 0; j < pocetZapasov; j++)
                {
                    prvaStvrtina = (int)Math.Ceiling(genPrvaStvrtina.Sample());
                    druhaStvrtina = genDruhaStvrtina.Sample();
                    tretiaStvrtina = genTretiaStvrtina.Sample();
                    stvrtaStvrtina = (int)Math.Ceiling(genStvtaStvrtina.Sample());
                    pocetBodov = prvaStvrtina + druhaStvrtina + tretiaStvrtina + stvrtaStvrtina;

                    if (pocetBodov > 100)
                    {
                        malViacAko100++;
                    }
                }

                if (malViacAko100 >= 5)
                {
                    celkoveBody++;
                }
            }

            var priemernyPocetZapasov = ((double)celkoveBody / pocetReplikacii) * 100;

            Console.WriteLine($"Pravdepodobnost {priemernyPocetZapasov}");
        }
    }
}
