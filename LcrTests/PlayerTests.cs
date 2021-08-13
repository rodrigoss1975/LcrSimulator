using LeftCenterRight;
using LeftCenterRight.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LcrTests
{
    /// <summary>
    /// Tests Player class
    /// </summary>
    [TestClass]
    public class PlayerTests
    {

        private IDie die;
        private Player currentPlayer;
        private Player rightPlayer;
        private Player leftPlayer;
        private Pool centerPool;

        /// <summary>
        /// Initialises the players and die
        /// </summary>
        /// <param name="result"></param>
        private void PreparePlayersAndPool(char result)
        {
            die = new DieMock(result);
            currentPlayer = new Player();
            rightPlayer = new Player();
            leftPlayer = new Player();
            centerPool = new Pool();
        }

        [TestMethod]
        public void PlayTurnShouldTransferChipToRightPlayerWhenRollEqualsR()
        {
            //arrange
            PreparePlayersAndPool('R');
            currentPlayer.PlayTurn(leftPlayer, rightPlayer, centerPool, die);
            //act
            Assert.IsTrue(rightPlayer.Chips == 6, "Right Player shoud have received 3 chips and have 6 chips.");
            Assert.IsTrue(currentPlayer.Chips == 0, "Current Player shoud have transfered 3 chip and have 0 chips.");
        }
        [TestMethod]
        public void PlayTurnShouldTransferChipToLeftPlayerWhenRollEqualsL()
        {
            //arrange
            PreparePlayersAndPool('L');
            currentPlayer.PlayTurn(leftPlayer, rightPlayer, centerPool, die);
            //act
            Assert.IsTrue(leftPlayer.Chips == 6, "Left Player shoud have received 3 chips and have 6 chips.");
            Assert.IsTrue(currentPlayer.Chips == 0, "Current Player shoud have transfered 3 chip and have 0 chips.");
        }
        [TestMethod]
        public void PlayTurnShouldTransferChipToPoolWhenRollEqualsC()
        {
            //arrange
            PreparePlayersAndPool('C');
            currentPlayer.PlayTurn(leftPlayer, rightPlayer, centerPool, die);
            //act
            Assert.IsTrue(centerPool.Chips == 3, "Center Pool shoud have received 3 chips and have 3 chips.");
            Assert.IsTrue(currentPlayer.Chips == 0, "Current Player shoud have transfered 3 chip and have 0 chips.");
        }
        [TestMethod]
        public void PlayTurnShouldNotTransferChipsWhenRollEqualsDot()
        {
            //arrange
            PreparePlayersAndPool('.');
            currentPlayer.PlayTurn(leftPlayer, rightPlayer, centerPool, die);
            //act
            Assert.IsTrue(currentPlayer.Chips == 3, "Current Player shoud have 3 chips.");
        }
        [TestMethod]
        public void ReceiveChipShouldIncreaseChipsByOne()
        {
            //arrange
            currentPlayer = new Player();
            currentPlayer.ReceiveChip();
            //act
            Assert.IsTrue(currentPlayer.Chips == 4, "Current Player shoud have 4 chips.");
        }
    }
}
