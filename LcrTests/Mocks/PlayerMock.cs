using LeftCenterRight.Interfaces;
using System.Collections.Generic;

namespace LcrTests
{
    /// <summary>
    /// Mocks Player Class
    /// </summary>
    public class PlayerMock : IPlayer
    {
        public int Chips { get; set; } = 3;

        public void PlayTurn(IRecipient leftPlayer, IRecipient rightPlayer, IRecipient centerPool, IDie die)
        {
            int count = Chips > 3 ? 3 : Chips;
            List<IRecipient> recipients = new List<IRecipient> { centerPool, rightPlayer, leftPlayer };
            for (int i = 0; i < count; i++)
            {
                recipients[i].ReceiveChip();
                Chips--;
            }
        }

        public void ReceiveChip()
        {
            Chips++;
        }
    }
}
