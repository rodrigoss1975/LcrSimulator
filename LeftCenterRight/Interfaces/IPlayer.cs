namespace LeftCenterRight.Interfaces
{
    /// <summary>
    /// Defines the interface for player
    /// it inherits from IRecipient
    /// </summary>
    public interface IPlayer : IRecipient
    {
        void PlayTurn(IRecipient leftPlayer, IRecipient rightPlayer, IRecipient centerPool, IDie die);
    }
}
