namespace Controller
{
    using RandomNameGeneratorLibrary;
    class NameGenerator
    {
        private readonly PersonNameGenerator nameGenerator = new();
        public string GenerateFirstName(string gender)
        {
            if (gender == "male")
            {
                return nameGenerator.GenerateRandomMaleFirstName();
            }
            else
            {
                return nameGenerator.GenerateRandomFemaleFirstName();
            }
        }

        public string GenerateLastName()
        {
            return nameGenerator.GenerateRandomLastName();
        }
    }
}
