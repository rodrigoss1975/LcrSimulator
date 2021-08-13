using LeftCenterRight;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace LcrTests
{
    /// <summary>
    /// Tests Game class
    /// </summary>
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void PlayShouldReturn3When3PlayersPlay()
        {
            //arrange
            Game game = new Game(new PlayerFactoryMock());
            int res = game.Play(3);
            //act
            Assert.IsTrue(res == 3, "Game should end in 3 rounds.");
        }
        [TestMethod]
        public void PlayShouldThrowValidationExceptionWhenNumberOfPlayersIsLessThan3()
        {
            //arrange
            Game game = new Game(new PlayerFactoryMock());
            //act
            Assert.ThrowsException<ValidationException>(() => game.Play(2));
        }

    }
}
