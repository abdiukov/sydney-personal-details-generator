namespace Model
{
    public class Person
    {
        public override string ToString()
        {
            return FirstName + LastName + Address + PhoneNumber + DateOfBirth + Gender + Email;
        }

        public Person(string firstName, string lastName, string address, string phoneNumber, string gender, string email, string dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public string FirstName
        {
            get; set;
        }

        public string LastName
        {
            get; set;
        }

        public string Address
        {
            get; set;
        }

        public string PhoneNumber
        {
            get; set;
        }

        public string Gender
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public string DateOfBirth
        {
            get; set;
        }

    }
}
