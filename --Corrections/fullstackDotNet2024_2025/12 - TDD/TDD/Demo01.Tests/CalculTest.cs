using Demo01.Bibliotheque;

namespace Demo01.Tests
{
    [TestClass]
    public sealed class CalculTest // ne pas oublier le public
    {
        private Calcul? _calcul;

        // fonctionne aussi mais pas recommandé pour NUnit et MSTest
        //public CalculTest()
        //{
        //    _calcul = new();
        //}

        //[ClassInitialize]// s'exécutera UNE FOIS AVANT TOUT LES TEST
        //public void OneTimeSetUp()
        //{
        //    _calcul = new Calcul(); // même instance pour tout les tests
        //}

        //[ClassCleanup]  // s'exécutera UNE FOIS APRES TOUT LES TEST
        //public void OneTimeTearDown()
        //{
        //    _calcul = null;
        //}

        [TestInitialize] // s'exécutera AVANT CHAQUE TEST
        public void SetUp()
        {
            _calcul = new Calcul(); // un instance différente par test
        }

        [TestCleanup]  // s'exécutera APRES CHAQUE TEST
        public void TearDown()
        {
            _calcul = null;
        }

        [TestMethod]
        public void WhenAddition_10_30_Then_40() // ne pas oublier le public
        {
            // Arrange
            //var calcul = new Calcul();

            // Act
            var result = _calcul.Addition(10, 30);

            // Assert
            Assert.AreEqual(40, result);
            //Assert.IsTrue(result == 40); // a éviter car moins d'informations en cas d'échec
        }

        [TestMethod]
        public void WhenDivision_30_10_Then_3()
        {
            // Arrange 
            //var calcul = new Calcul();

            // Act
            double result = _calcul.Division(30, 10);

            // Assert
            Assert.AreEqual(3, result);
        }


        [TestMethod]
        public void WhenDivision_1_0_Then_DivideByZeroException()
        {
            // Arrange 
            //var calcul = new Calcul();

            // Act et Assert
            Assert.ThrowsException<DivideByZeroException>(() => _calcul.Division(1, 0));
            //Assert.ThrowsException<DivideByZeroException>(() => calcul.Division(1, 0), "Division par 0 impossible");
        }
    }
}
