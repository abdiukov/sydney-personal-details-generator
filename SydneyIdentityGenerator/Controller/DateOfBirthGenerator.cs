using System;

namespace Controller
{
    class DateOfBirthGenerator
    {
        private readonly Random random = new();
        public string GenerateRandomDate()
        {
            //generate a year between 1950 and 2000
            int year = 1950 + random.Next(0, 50);

            //generate a month between 1 and 12
            int month = random.Next(1, 12);

            //generate the day of month between 1 and 28
            int dayOfMonth = random.Next(1, 28);

            return year + "-" + month + "-" + dayOfMonth;
        }
    }
}
