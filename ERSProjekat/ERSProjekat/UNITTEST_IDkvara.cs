using NUnit.Framework;

namespace ERSProjekat
{
    [TestFixture]
    public class ID_KvaraTests
    {
        [Test]
        public void GetIDKvara_CreatesUniqueID()
        {
            // Pozivamo funkciju za kreiranje ID kvara
            string idKvara1 = ID_Kvara.GetIDKvara();
            string idKvara2 = ID_Kvara.GetIDKvara();

            // Proveravamo da li su kreirani ID-jevi različiti
            Assert.AreNotEqual(idKvara1, idKvara2);
        }

        [Test]
        public void GetIDKvara_FormatIsCorrect()
        {
            // Pozivamo funkciju za kreiranje ID kvara
            string idKvara = ID_Kvara.GetIDKvara();

            // Proveravamo format datuma i rednog broja kvara
            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(idKvara, @"\d{14}_\d{2}$"));
        }
    }
}
