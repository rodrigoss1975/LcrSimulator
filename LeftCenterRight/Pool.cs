using LeftCenterRight.Interfaces;

namespace LeftCenterRight 
{
    /// <summary>
    /// Represents the center pool
    /// which can receive chips
    /// </summary>
    public class Pool : IRecipient
    {
        private int _chips = 0;
        public int Chips { get => _chips; }

        /// <summary>
        /// Receives a chip
        /// </summary>
        public void ReceiveChip()
        {
            _chips++;
        }
    }
}
