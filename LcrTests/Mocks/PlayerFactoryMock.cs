using LeftCenterRight.Interfaces;

namespace LcrTests
{
    /// <summary>
    /// Mocks PlayerFactory
    /// </summary>
    public class PlayerFactoryMock : IPlayerFactory
    {
        public IPlayer Create() => new PlayerMock();
    }
}
