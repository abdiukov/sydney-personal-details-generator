using Controller.Services;

namespace Controller.Models;

public abstract class Person: PersonBuilder
{
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string Address { get; set; }
    public virtual string PhoneNumber { get; set; }
    public virtual string Email { get; set; }
    public virtual string DateOfBirth { get; set; }
    public virtual string Gender { get; set; }

    public virtual void BuildFirstName() => FirstName = Helper.NameGenerator.GenerateRandomFirstName();
    public virtual void BuildLastName() => LastName = Helper.NameGenerator.GenerateRandomLastName();
    public virtual void BuildAddress() => Address = Helper.AddressGenerator.GenerateRandomSydneyAddress();
    public virtual void BuildPhoneNumber() => PhoneNumber = $"04{Helper.Random.Next(100000, 1000000)}";
    public virtual void BuildEmail() => Email = $"{FirstName}.{LastName}@gmail.com";
    public virtual void BuildDateOfBirth() => DateOfBirth = $"{1950 + Helper.Random.Next(0, 53)}/{Helper.Random.Next(1, 13)}/${Helper.Random.Next(1, 29)}";
    public virtual void BuildGender() => Gender = "non-binary";
}