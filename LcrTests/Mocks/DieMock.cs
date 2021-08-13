using LeftCenterRight.Interfaces;

namespace LcrTests
{
    /// <summary>
    /// Mocks Die class
    /// </summary>
    public class DieMock : IDie
    {
        private char _result;
        public DieMock(char result)
        {
            _result = result;
        }

        public char Roll()
        {
            return _result;
        }
    }
}
