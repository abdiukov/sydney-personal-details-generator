using System;

namespace Controller
{
    class RandomNumberGenerator
    {
        private readonly Random random = new();

        /// <summary>
        /// Randomly generates an integer.
        /// </summary>
        /// <param name="maximumValue">The maximum value of a generated number</param>
        /// <returns>Number from 1 to maximumValue (maximumValue is provided by user) </returns>
        public int GenerateRandomNumber(int maximumValue)
        {
            return random.Next(1, maximumValue);
        }
    }
}
