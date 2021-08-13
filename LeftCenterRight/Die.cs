using LeftCenterRight.Interfaces;
using System;

namespace LeftCenterRight
{
    /// <summary>
    /// Singleton class representing a die in LCR,
    /// the die has 6 sides 3 correspond 
    /// to the letters L, C and R, and the 
    /// other 3 correspond to a dot.
    /// </summary>
    public sealed class Die : IDie
    {
        private readonly Random _random;
        private readonly char[] _sides = { '.', 'L', '.', 'C', '.', 'R' };
        private static readonly Lazy<Die> lazy = new Lazy<Die>(() => new Die());

        /// <summary>
        /// Privete default constructor
        /// so no Die instances can be created
        /// by calling new Die
        /// </summary>
        private Die()
        {
            _random = new Random();
        }
        
        /// <summary>
        /// Access single instance of Die
        /// </summary>
        public static IDie Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        /// <summary>
        /// Rolls the die and returns a character
        /// using random numbers and a char array
        /// representing the sides of the die.
        /// </summary>
        /// <returns>
        /// A character that can be 
        /// either L, C, R or a dot
        /// </returns>
        public char Roll()
        {
            return _sides[_random.Next(5)];
        }
    }
}
