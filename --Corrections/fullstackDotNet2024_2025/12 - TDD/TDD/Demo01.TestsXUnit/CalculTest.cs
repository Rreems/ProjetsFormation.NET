using Demo01.Bibliotheque;

namespace Demo01.TestsXUnit
{
    public sealed class CalculTest : IDisposable
    {
        private Calcul? _calcul;

        // SetUp
        public CalculTest()
        {
            _calcul = new();
        }

        // TearDown
        public void Dispose()
        {
            _calcul = null;
        }

        // IClassFixture à utiliser pour les OneTime...

        [Fact]
        public void WhenAddition_10_30_Then_40() // ne pas oublier le public
        {
            // Arrange
            //var calcul = new Calcul();

            // Act
            var result = _calcul.Addition(10, 30);

            // Assert
            Assert.Equal(40, result);
        }

        [Fact]
        public void WhenDivision_30_10_Then_3()
        {
            // Arrange 
            var calcul = new Calcul();

            // Act
            double result = calcul.Division(30, 10);

            // Assert
            Assert.Equal(3, result);
        }


        [Fact]
        public void WhenDivision_1_0_Then_DivideByZeroException()
        {
            // Arrange 
            var calcul = new Calcul();

            // Act et Assert
            Assert.Throws<DivideByZeroException>(() => calcul.Division(1, 0));
        }
    }
}
