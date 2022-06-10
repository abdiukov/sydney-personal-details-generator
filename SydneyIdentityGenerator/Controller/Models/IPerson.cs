namespace Controller.Models;
public interface IPerson
{
    string FirstName { get; }
    virtual string LastName => Helper.NameGenerator.GenerateRandomLastName();
    virtual string Address => Helper.AddressGenerator.GenerateRandomSydneyAddress();
    virtual string PhoneNumber => $"04{Helper.Random.Next(100000, 999999)}";
    virtual string Email => $"{FirstName}.{LastName}@gmail.com";
    virtual string DateOfBirth => Helper.DateOfBirthGenerator.GenerateRandomDate();
    string Gender { get; }
    virtual string ToString() => FirstName + LastName + Address + PhoneNumber + DateOfBirth + Gender + Email;
}