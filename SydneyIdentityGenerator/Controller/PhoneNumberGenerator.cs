using System;

namespace Controller
{
    class PhoneNumberGenerator
    {
        private readonly Random random = new();

        public string GeneratePhoneNumber()
        {
            string FirstTwoNumbers = "04";
            string output = FirstTwoNumbers;

            //3th, 4th number
            output += random.Next(0, 10);
            output += random.Next(0, 10);
            output += "-";

            //5th, 6th, 7th number
            output += random.Next(0, 10);
            output += random.Next(0, 10);
            output += random.Next(0, 10);
            output += "-";

            //8th 9th and 10th number
            output += random.Next(0, 10);
            output += random.Next(0, 10);
            output += random.Next(0, 10);

            return output;
        }
    }
}
