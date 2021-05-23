
using System;

namespace Controller
{

    class GenderGenerator
    {
        private readonly Random random = new();
        public string GenerateGender()
        {
            int numberBetweenOneAndTwo = random.Next(1, 3);
            switch (numberBetweenOneAndTwo)
            {
                case 1:
                    return "male";
                default:
                    return "female";
            }

        }
    }
}
