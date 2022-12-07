using UNIZA.FRI.RandomNumberGenerators;

namespace MonteCarlo._2015
{
    public class Zadanie_2
    {
        public void MonteCarlo()
        {
            var pocetReplikacii = 1000000;
            var pocetRokov = 8;
            var cenaNaftoveho = 2500.0;

            var spotrebaBenzin = 5;
            var spotrebaNafta = 7;

            var cenaBenzin = 1.1;
            var cenaNafty = 1;

            var pocetKm = 0;
            var genPocetKm = new TriangularRNG(10000.0, 18000.0, 25000.0);

            var celkovyBenzin = 0.0;
            var celkovaNafta = 0.0;

            var pravNafta = 0;

            for (int i = 0; i < pocetReplikacii; i++)
            {
                var benzin = 0.0;
                var nafta = cenaNaftoveho;

                for (int j = 1; j <= pocetRokov; j++)
                {
                    pocetKm = (int)Math.Round(genPocetKm.Sample());
                    var najazdiNaBenzine = (pocetKm / 100) * spotrebaBenzin;
                    var najazdiNaNafte = (pocetKm / 100) * spotrebaNafta;

                    var cenaZaRokBenzin = najazdiNaBenzine * cenaBenzin;
                    var cenaZaRokNafta = najazdiNaNafte * cenaNafty;

                    benzin += cenaZaRokBenzin;
                    nafta += cenaZaRokNafta;
                }

                if (nafta < benzin)
                {
                    pravNafta++;
                }

                celkovyBenzin += benzin;
                celkovaNafta += nafta;

            }

            var priemerBenzin = (double)celkovyBenzin / pocetReplikacii;
            var priemerNafta = (double)celkovaNafta / pocetReplikacii;

            var priemerPravNafta = ((double)pravNafta / pocetReplikacii) * 100;

            Console.WriteLine($"Benzin vychadza na 8 rokov {priemerBenzin}");
            Console.WriteLine($"Nafta vychadza na 8 rokov {priemerNafta}");

            Console.WriteLine($"Naftu je na {priemerPravNafta} % lepsie zakupit");
        }
    }
}
