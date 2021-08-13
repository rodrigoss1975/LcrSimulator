using LeftCenterRight;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LcrTests
{
    [TestClass]
    public class PoolTests
    {
        /// <summary>
        /// Tests Pool class
        /// </summary>
        [TestMethod]
        public void ReceiveChipShouldIncreaseChipsByOne()
        {
            Pool pool = new Pool();
            pool.ReceiveChip();
            Assert.IsTrue(pool.Chips == 1, "Pool shoud have 1 chip.");
        }
    }
}
