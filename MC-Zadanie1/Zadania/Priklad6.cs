using UNIZA.FRI.RandomNumberGenerators;

namespace MonteCarlo.Zadania
{
    public class Priklad6
    {

        public void MonteCarlo()
        {
            var jednotliveTypy = 5;
            var pocetPretekov = 5;
            var pocetReplikacii = 1000000;

            var genCasFast = new TriangularRNG(40.0, 50.0, 75.0);
            var genCasFurious = new TriangularRNG(35.0, 52.0, 80.0);

            var casFast = 0.0;
            var casFurious = 0.0;

            var pravedpodobnostNaPrveDveMiestaFast = 0;

            for (int i = 0; i < pocetReplikacii; i++)
            {
                List<Cars> cars = new List<Cars>();

                for (int j = 0; j < jednotliveTypy; j++)
                {
                    casFast = Math.Round(genCasFast.Sample(), 2);
                    var car = new Cars
                    {
                        Cas = casFast,
                        IsFast = true
                    };

                    cars.Add(car);
                }

                for (int j = 0; j < jednotliveTypy; j++)
                {
                    casFurious = Math.Round(genCasFurious.Sample(), 2);
                    var car = new Cars
                    {
                        Cas = casFurious,
                        IsFast = false
                    };

                    cars.Add(car);
                }

                var sortedCars = from car in cars
                                 orderby car.Cas ascending
                                 select car;


                if (sortedCars.ElementAt(0).IsFast && sortedCars.ElementAt(1).IsFast)
                {
                    pravedpodobnostNaPrveDveMiestaFast++;
                }
            }

            var celkoveBodyFast = 0;
            var celkoveBodyFurious = 0;

            for (int i = 0; i < pocetReplikacii; i++)
            {
                var bodyFast = 0;
                var bodyFurious = 0;

                for (int x = 0; x < pocetPretekov; x++)
                {
                    List<Cars> cars = new List<Cars>();

                    for (int j = 0; j < 5; j++)
                    {
                        casFast = Math.Round(genCasFast.Sample(), 2);
                        var car = new Cars
                        {
                            Cas = casFast,
                            IsFast = true
                        };

                        cars.Add(car);
                    }

                    for (int j = 0; j < 5; j++)
                    {
                        casFurious = Math.Round(genCasFurious.Sample(), 2);
                        var car = new Cars
                        {
                            Cas = casFurious,
                            IsFast = false
                        };

                        cars.Add(car);
                    }

                    var sortedCars = from car in cars
                                     orderby car.Cas ascending
                                     select car;

                    for (int j = 0; j < sortedCars.Count(); j++)
                    {
                        if (sortedCars.ElementAt(j).IsFast)
                        {
                            bodyFast += 10 - j;
                        }
                        else
                        {
                            bodyFurious += 10 - j;
                        }
                    }
                }

                if (bodyFast > bodyFurious)
                {
                    celkoveBodyFast++;
                }
                else
                {
                    celkoveBodyFurious++;
                }
            }

            var pravdepodobnostFast = ((double)celkoveBodyFast / pocetReplikacii) * 100;
            var pravdepodobnostFurious = ((double)celkoveBodyFurious / pocetReplikacii) * 100;
            var pravdepodobnost = ((double) pravedpodobnostNaPrveDveMiestaFast / pocetReplikacii) * 100;
            Console.WriteLine($"Pravdepodobnost, ze sa Fast umiestna na prvom a zaroven druhom mieste je {Math.Round(pravdepodobnost,2)}");
            Console.WriteLine($"Fast bude mat lepsiu sezonu o {Math.Round(pravdepodobnostFast, 2)}");
            Console.WriteLine($"Furious bude mat lepsiu sezonu o {Math.Round(pravdepodobnostFurious, 2)}");

        }
    }

    class Cars
    {
        public double Cas { get; set; }
        public bool IsFast { get; set; }
    }

}
