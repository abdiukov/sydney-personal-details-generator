using Controller.Models;

namespace Controller;
public class Visitor<T> where T : IPerson
{

    string Visit(T t)
    {
        return $"{t.FirstName},{t.LastName},{t.Address},{t.PhoneNumber},{t.DateOfBirth},{t.Gender},{t.Email}";
    }


    private string VisitState()
    {
        return "";
    }

    // ->

}

public class State<T> where T : IPerson
{
    private delegate string StateDelegate();
    StateDelegate stateDelegate = null;
    public void EnableFirstName(T t) => stateDelegate += () => t.FirstName;
    public void EnableLastName (T t) => stateDelegate += () => t.LastName;
    public void EnableAddress(T t) => stateDelegate += () => t.Address;
    public void EnablePhoneNumber(T t) => stateDelegate += () => t.PhoneNumber;
    public void EnableGender(T t) => stateDelegate += () => t.Gender;
    public void EnableEmail(T t) => stateDelegate += () => t.Email;
    public void EnableDateOfBirth(T t) => stateDelegate += () => t.DateOfBirth;
}