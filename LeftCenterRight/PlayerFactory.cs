using LeftCenterRight.Interfaces;

namespace LeftCenterRight
{
    /// <summary>
    /// Creates new instances of IPlayer
    /// </summary>
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer Create()
        {
            return new Player();
        }
    }
}
