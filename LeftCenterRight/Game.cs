using LeftCenterRight.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LeftCenterRight
{
    /// <summary>
    /// Class representing a LCR Game
    /// </summary>
    public class Game
    {
        private readonly IPlayerFactory _playerFactory;
        private Pool CenterPool { get; set; }
        private List<IPlayer> Players { get; set; }

        /// <summary>
        /// Creates a new LCR game instance
        /// </summary>
        /// <param name="numberOfPlayers">
        /// The number of players that will take 
        /// part in the game
        /// </param>
        public Game(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        /// <summary>
        /// Initialize instance
        /// </summary>
        private void init(int numberOfPlayers)
        {
            //create player instances and add them to the players list
            Players = new List<IPlayer>();
            for (int i = 0; i < numberOfPlayers; i++)
                Players.Add(_playerFactory.Create());
            CenterPool = new Pool();
        }

        /// <summary>
        /// Play LCR game
        /// </summary>
        /// <returns>The number of rounds played util a player wins</returns>
        public int Play(int numberOfPlayers)
        {
            if (numberOfPlayers < 3) throw new ValidationException("Number of plyers should be 3 or more.");
            IDie die = Die.Instance;
            init(numberOfPlayers);
            int rounds = 0;
            while (Players?.Where(p => p.Chips > 0).Count() > 1)
            {
                rounds++;
                for(int i = 0; i < numberOfPlayers; i++)
                {
                    IPlayer leftPlayer = i == 0 ? Players.Last() : Players[i - 1];
                    IPlayer rightPlayer = i == Players.Count() - 1 ? Players.First() : Players[i + 1];
                    Players[i].PlayTurn(leftPlayer, rightPlayer, CenterPool, die);
                }
            }
            return rounds;
        }
    }
}
