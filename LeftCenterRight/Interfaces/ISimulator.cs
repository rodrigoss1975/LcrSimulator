namespace LeftCenterRight.Interfaces
{
    /// <summary>
    /// Defines the interface used by Simulator
    /// </summary>
    public interface ISimulator
    {
        GameStats RunSimulation(int numberOfPlayers, int numberOfGames);
    }
}
