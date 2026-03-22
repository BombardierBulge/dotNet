using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemPlecakowy;

namespace TestinngApp
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void Test_CzyZwracaElementy_GdyPojemnoscOk()
        {
            var p = new Problem(10, 1);
            var wynik = p.Rozwiaz(50);
            Assert.IsNotEmpty(wynik.ListaId);
        }

        [TestMethod]
        public void Test_CzyPusty_GdyPojemnoscZero()
        {
            var p = new Problem(10, 1);
            var wynik = p.Rozwiaz(0);
            Assert.IsEmpty(wynik.ListaId);
        }

        [TestMethod]
        public void Test_CzySumaWag_NiePrzekraczaLimitow()
        {
            int pojemnosc = 20;
            var p = new Problem(10, 1);
            var wynik = p.Rozwiaz(pojemnosc);
            Assert.IsLessThanOrEqualTo(pojemnosc,wynik.CalaWaga,  "Waga przekroczyła pojemność!");
        }

        [TestMethod]
        public void Test_CzyWybieraNajbardziejOplacalne()
        {

            var p = new Problem(10, 1);
            int malaPojemnosc = 5;
            var wynik = p.Rozwiaz(malaPojemnosc);

            foreach (var id in wynik.ListaId)
            {
                var przedmiot = p.Przedmioty.First(x => x.Id == id);

                Assert.IsNotNull(przedmiot);
            }
        }

        [TestMethod]
        public void Test_CzyWartosciWagIRatioSaWZakresie()
        {
            int n = 20;
            var p = new Problem(n, 1);

            foreach (var przedmiot in p.Przedmioty)
            {
                Assert.IsTrue(przedmiot.Waga >= 1 && przedmiot.Waga <= 10, $"Waga przedmiotu {przedmiot.Id} poza zakresem!");
                Assert.IsTrue(przedmiot.Wartosc >= 1 && przedmiot.Wartosc <= 10, $"Wartość przedmiotu {przedmiot.Id} poza zakresem!");
            }
        }
    }
}