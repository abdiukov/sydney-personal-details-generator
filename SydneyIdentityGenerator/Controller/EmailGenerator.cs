namespace Controller
{
    class EmailGenerator
    {
        public string GenerateEmail(string firstName, string lastName)
        {
            return firstName + "." + lastName + "@gmail.com";
        }

    }
}
