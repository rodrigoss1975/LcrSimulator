namespace LeftCenterRight.Interfaces
{
    /// <summary>
    /// Interface for classes that 
    /// can receive chips
    /// </summary>
    public interface IRecipient
    {
        int Chips { get; }
        void ReceiveChip();
    }
}
