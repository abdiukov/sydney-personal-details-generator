using Controller.Models;

namespace Controller;

public class Builder<T> where T : IPerson
{
    //TODO: rename BuildDelegate to `BuildInstructions`
    public delegate string BuildInstructions(T t);
    public BuildInstructions buildInstructions = null;
    public void BuildFirstName() => buildInstructions += (T t) => t.FirstName;
    public void BuildLastName() => buildInstructions += (T t) => t.LastName;
    public void BuildAddress() => buildInstructions += (T t) => t.Address;
    public void BuildPhoneNumber() => buildInstructions += (T t) => t.PhoneNumber;
    public void BuildGender() => buildInstructions += (T t) => t.Gender;
    public void BuildEmail() => buildInstructions += (T t) => t.Email;
    public void BuildDateOfBirth() => buildInstructions += (T t) => t.DateOfBirth;
}