using Model;

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
            Person[] records = GeneratePersons(amountToGenerate);

            CsvFileWriter.Write("text.csv", parameters, records);
        }

        private Person[] GeneratePersons(int amountToGenerate)
        {

            //defining output
            Person[] output = new Person[amountToGenerate];

            for (int i = 0; i < amountToGenerate; i++)
            {
                string gender = genderGenerator.GenerateGender();
                string firstName = nameGenerator.GenerateFirstName(gender);
                string lastName = nameGenerator.GenerateLastName();
                string email = emailGenerator.GenerateEmail(firstName, lastName);
                string address = addressGenerator.GenerateRandomSydneyAddress();
                string phoneNumber = phoneNumberGenerator.GeneratePhoneNumber();
                string dateOfBirth = dateOfBirthGenerator.GenerateRandomDate();

                Person toAdd = new(firstName, lastName, address, phoneNumber, gender, email, dateOfBirth);
                output[i] = toAdd;
            }
            return output;
        }


    }
}
