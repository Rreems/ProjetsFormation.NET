using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Demo03Mock.Tests
{
    [TestClass]
    public class JeuTests
    {
        [TestMethod]
        public void Jouer_Win()
        {
            //Arrange 
            //IDe dewin = new De20(); // aléatoire donc test invalide => 1/20 chance de réussir
            //IDe dewin = new FakeDe20Win();
            IDe dewin = Mock.Of<IDe>();
            Mock.Get(dewin)
                .Setup(d => d.Lancer())
                .Returns(20);

            Jeu jeu = new Jeu(dewin);

            //Act
            var res = jeu.Jouer();

            //Assert
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Jouer_Loose()
        {
            //Arrange
            //IDe deloose = new De20(); // aléatoire donc test invalide => 19/20 chance de réussir
            //IDe deloose = new FakeDe20Loose();
            IDe deloose = Mock.Of<IDe>();
            Mock.Get(deloose)
                .Setup(d => d.Lancer())
                .Returns(19);

            Jeu jeu = new(deloose);

            //Act
            bool result = jeu.Jouer();

            //Assert
            Assert.IsFalse(result);
        }
    }
}
