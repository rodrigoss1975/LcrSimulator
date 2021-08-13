using LeftCenterRight.Interfaces;

namespace LcrTests
{
    public class PlayerMock : IPlayer
    {
        public int Chips => throw new System.NotImplementedException();

        public void PlayTurn(IRecipient leftPlayer, IRecipient rightPlayer, IRecipient centerPool, IDie die)
        {
            throw new System.NotImplementedException();
        }

        public void ReceiveChip()
        {
            throw new System.NotImplementedException();
        }
    }
}
