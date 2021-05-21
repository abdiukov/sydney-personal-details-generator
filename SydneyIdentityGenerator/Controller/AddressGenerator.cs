using System;
using System.IO;
using System.Linq;

namespace Controller
{
    class AddressGenerator
    {
        private readonly Random random = new();
        private const string SYDNEY_ADDRESSES_FILE_NAME = "sydney_addresses.txt";
        private const int NUMBER_OF_LINES_SYDNEY_ADDRESSES_FILE = 1424149;
        public string GenerateRandomSydneyAddress()
        {
            int randomlyGeneratedLine = random.Next(0, NUMBER_OF_LINES_SYDNEY_ADDRESSES_FILE - 1);

            return File.ReadLines(SYDNEY_ADDRESSES_FILE_NAME).Skip(randomlyGeneratedLine).First();
        }
    }
}
