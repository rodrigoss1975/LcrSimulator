using System.Linq;

namespace LeftCenterRight
{
    /// <summary>
    /// Runs LCR game
    /// </summary>
    public class Simulator
    {

        /// <summary>
        /// Runs the game for the specified number of players
        /// the specified number of times
        /// </summary>
        /// <param name="numberOfPlayers"></param>
        /// <param name="numberOfGames"></param>
        /// <returns>
        /// GameStats instance containg Longest Game,
        /// Shortest Game and Average Game Length
        /// </returns>
        public GameStats RunSimulation(int numberOfPlayers, int numberOfGames)
        {
            var game = new Game(new PlayerFactory());
            int[] results = new int[numberOfGames];
            results = results.Select(r => game.Play(numberOfPlayers)).ToArray();
            return new GameStats { LongestGame = results.Max(), ShortestGame = results.Min(), AverageGameLength = results.Average() };
        }
    }
}
