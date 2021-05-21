namespace Controller
{
    class EmailGenerator
    {
        private string GenerateEmail(string firstName, string lastName)
        {
            return firstName + "." + lastName + "@gmail.com";
        }

    }
}
