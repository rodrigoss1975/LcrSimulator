using LeftCenterRight.Interfaces;

namespace LeftCenterRight
{
    /// <summary>
    /// Class representing a player in an RCL game
    /// </summary>
    public class Player : IPlayer
    {
        private int _chips;

        /// <summary>
        /// Desfault constructor
        /// </summary>
        public Player()
        {
            _chips = 3;
        }
        /// <summary>
        /// Number of chips the player has
        /// </summary>
        public int Chips { get => _chips; }

        /// <summary>
        /// Receives a chip
        /// </summary>
        public void ReceiveChip()
        {
            _chips++;
        }
        /// <summary>
        /// Send chips to other players
        /// or the pool
        /// </summary>
        /// <param name="recipient">Recipient of the chip being transfered</param>
        private void SendChip(IRecipient recipient)
        {
            recipient.ReceiveChip();
            _chips--;
        }

        /// <summary>
        /// Represents a player rolling the dice
        /// and transfering chips according to 
        /// the dice results
        /// </summary>
        /// <param name="leftPlayer"></param>
        /// <param name="rightPlayer"></param>
        /// <param name="centerPool"></param>
        /// <param name="die"></param>
        public void PlayTurn(IRecipient leftPlayer, IRecipient rightPlayer, IRecipient centerPool, IDie die)
        {
            var rolls = Chips < 3 ? Chips : 3;
            for (var i = 0; i < rolls; i++)
            {
                switch (die.Roll())
                {
                    case 'L':
                        SendChip(leftPlayer);
                        break;
                    case 'R':
                        SendChip(rightPlayer);
                        break;
                    case 'C':
                        SendChip(centerPool);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
