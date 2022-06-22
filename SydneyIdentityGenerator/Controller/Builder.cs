using Controller.Models;

namespace Controller;

//public class Builder<T> where T : IPerson
//{
//    public delegate T BuildInstructions(T t);
//    public BuildInstructions buildInstructions = null;
//    public void BuildFirstName() => buildInstructions += (T t) => { _ = t.FirstName; return t; } ;
//    public void BuildLastName() => buildInstructions += (T t) => { _ = t.LastName; return t; };
//    public void BuildAddress() => buildInstructions += (T t) => { _ = t.Address; return t; };
//    public void BuildPhoneNumber() => buildInstructions += (T t) => { _ = t.PhoneNumber; return t; };
//    public void BuildGender() => buildInstructions += (T t) => { _ = t.Gender; return t; };
//    public void BuildEmail() => buildInstructions += (T t) => { _ = t.Email; return t; }; 
//    public void BuildDateOfBirth() => buildInstructions += (T t) => { _ = t.DateOfBirth; return t; }; 
//}