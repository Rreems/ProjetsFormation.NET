using Demo01.Bibliotheque;

namespace Demo01.TestsNUnit
{
    [TestFixture]
    public sealed class CalculTest // ne pas oublier le public
    {
        private Calcul? _calcul;

        // fonctionne aussi mais pas recommandé pour NUnit et MSTest
        //public CalculTest()
        //{
        //    _calcul = new();
        //}

        //[OneTimeSetUp]// s'exécutera UNE FOIS AVANT TOUT LES TEST
        //public void OneTimeSetUp()
        //{
        //    _calcul = new Calcul();
        //}

        //[OneTimeTearDown]  // s'exécutera UNE FOIS APRES TOUT LES TEST
        //public void OneTimeTearDown()
        //{
        //    _calcul = null;
        //}

        [SetUp] // s'exécutera AVANT CHAQUE TEST
        public void SetUp()
        {
            _calcul = new Calcul();
        }

        [TearDown]  // s'exécutera APRES CHAQUE TEST
        public void TearDown()
        {
            _calcul = null;
        }

        [Test]
        public void WhenAddition_10_30_Then_40() // ne pas oublier le public
        {
            // Arrange
            //var calcul = new Calcul();

            // Act
            var result = _calcul.Addition(10, 30);

            // Assert
            //Assert.AreEqual(40, result);
            Assert.That(result, Is.EqualTo(40));
        }

        [Test]
        public void WhenDivision_30_10_Then_3()
        {
            // Arrange 
            var calcul = new Calcul();

            // Act
            double result = calcul.Division(30, 10);

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }


        [Test]
        public void WhenDivision_1_0_Then_DivideByZeroException()
        {
            // Arrange 
            var calcul = new Calcul();

            // Act et Assert
            Assert.Throws<DivideByZeroException>(() => calcul.Division(1, 0));
        }
    }
}
