namespace Controller.Models;

public abstract class IPerson
{
    public virtual string FirstName => Helper.NameGenerator.GenerateRandomFirstName();
    public virtual string LastName => Helper.NameGenerator.GenerateRandomLastName();
    public virtual string Address => Helper.AddressGenerator.GenerateRandomSydneyAddress();
    public virtual string PhoneNumber => $"04{Helper.Random.Next(100000, 999999)}";
    public virtual string Email => $"{FirstName}.{LastName}@gmail.com";
    public virtual string DateOfBirth => $"{1950 + Helper.Random.Next(0, 53)}/{Helper.Random.Next(1, 13)}/${Helper.Random.Next(1, 29)}";
    public virtual string Gender => "non-binary";
}