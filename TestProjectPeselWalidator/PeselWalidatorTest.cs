using NUnit.Framework;

namespace TestProjectPeselWalidator
{
    public class Tests
    {


        [Test]
        public void DodawaniePeselu()
        {
            // ARRANGE
            var nowyPesel = new PeselWalidator_(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1 });

            // ACT
            nowyPesel.WczytajPesel("93041205683");
            int[] peselTestowy = new int[] { 9, 3, 0, 4, 1, 2, 0, 5, 6, 8, 3 }; // Ten sam pesel co liniê wy¿ej

            // ASSERT
            Assert.AreEqual(peselTestowy, nowyPesel.pesel);
        }
        [Test]
        public void SprawdzanieDatyUrodzeniaRocznik93()
        {
            // ARRANGE
            var nowyPesel = new PeselWalidator_();
            nowyPesel.WczytajPesel("93041205683");
            // ACT
            string data = "12/04/1993";
            // ASSERT
            Assert.AreEqual(data, nowyPesel.DataUrodzenia());
        }
        [Test]
        public void SprawdzanieDatyUrodzeniaRocznik02()
        {
            // ARRANGE
            var nowyPesel = new PeselWalidator_();
            nowyPesel.WczytajPesel("02241205683");
            // ACT
            string data = "12/04/2002";
            // ASSERT
            Assert.AreEqual(data, nowyPesel.DataUrodzenia());
        }
        [Test]
        public void SprawdzaniePlciKobieta()
        {
            var nowyPesel = new PeselWalidator_();
            nowyPesel.WczytajPesel("02241205683");
            string k = "Kobieta";
            // ASSERT
            Assert.AreEqual(k, nowyPesel.Plec());
        }
        [Test]
        public void SprawdzaniePlciMezczyzna()
        {
            var nowyPesel = new PeselWalidator_();
            nowyPesel.WczytajPesel("02241205693");
            string m = "Mê¿czyzna";
            // ASSERT
            Assert.AreEqual(m, nowyPesel.Plec());
        }

        [Test]
        public void SprawdzanieLiczbyKontrolnej_Bledna()
        {
            var nowyPesel = new PeselWalidator_();
            nowyPesel.WczytajPesel("02241205693");
            Assert.AreEqual(false, nowyPesel.SprawdzPesel());
            nowyPesel.WczytajPesel("58101182175");
            Assert.AreEqual(false, nowyPesel.SprawdzPesel());
            nowyPesel.WczytajPesel("14301131586");
            Assert.AreEqual(false, nowyPesel.SprawdzPesel());

        }
        [Test]
        public void SprawdzanieLiczbyKontrolnej_Poprawna()
        {
            var nowyPesel = new PeselWalidator_();
            nowyPesel.WczytajPesel("58101184374");
            Assert.AreEqual(true, nowyPesel.SprawdzPesel());
            nowyPesel.WczytajPesel("48101191467");
            Assert.AreEqual(true, nowyPesel.SprawdzPesel());
            nowyPesel.WczytajPesel("14301133486");
            Assert.AreEqual(true, nowyPesel.SprawdzPesel());
        }

    }
}