using Controller.Models;

namespace Controller;

public class Builder<T> where T : Person
{
    public delegate void BuildInstructions(T t);
    public BuildInstructions buildInstructions = null;
    public void BuildFirstName() => buildInstructions += (T t) => t.BuildFirstName();
    public void BuildLastName() => buildInstructions += (T t) => t.BuildLastName();
    public void BuildAddress() => buildInstructions += (T t) => t.BuildAddress();
    public void BuildPhoneNumber() => buildInstructions += (T t) => t.BuildPhoneNumber();
    public void BuildGender() => buildInstructions += (T t) => t.BuildGender();
    public void BuildEmail() => buildInstructions += (T t) => t.BuildEmail();
    public void BuildDateOfBirth() => buildInstructions += (T t) => t.BuildDateOfBirth();
}