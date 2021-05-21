
using System;

namespace Controller
{

    class GenderGenerator
    {
        private readonly Random random = new();
        public string GenerateGender()
        {
            switch (random.Next(1, 2))
            {
                case 1:
                    return "male";
                default:
                    return "female";
            }

        }
    }
}
