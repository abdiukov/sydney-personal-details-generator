namespace Controller
{
    public class Control
    {
        private readonly EmailGenerator emailGenerator = new();
        private readonly GenderGenerator genderGenerator = new();
        private readonly NameGenerator nameGenerator = new();
        private readonly AddressGenerator addressGenerator = new();
        private readonly DateOfBirthGenerator dateOfBirthGenerator = new();
        private readonly PhoneNumberGenerator phoneNumberGenerator = new();


        public void GeneratePersonsAndWriteToCsv(int amountToGenerate, string parameters)
        {
            GeneratePersons(amountToGenerate, parameters);

            CsvFileWriter.Write("test.csv", parameters, amountToGenerate);
        }

        private void GeneratePersons(int amountToGenerate, string parameters)
        {
            string gender;
            string firstName;
            string lastName;
            string email;
            string address;
            string dateOfBirth;
            string phoneNumber;

            //gender firstname, lastname, email
            gender = genderGenerator.GenerateGender();
            firstName = nameGenerator.GenerateFirstName(gender);
            lastName = nameGenerator.GenerateLastName();
            email = emailGenerator.GenerateEmail(firstName, lastName);

            //address, dateOfBirth, phoneNumber
            phoneNumber = phoneNumberGenerator.GeneratePhoneNumber();
            address = addressGenerator.GenerateRandomSydneyAddress();
            dateOfBirth = dateOfBirthGenerator.GenerateRandomDate();
        }
    }
}
