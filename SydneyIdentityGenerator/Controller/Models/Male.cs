namespace Controller.Models;

public class Male : Person
{
    public override void BuildFirstName() => FirstName = Helper.NameGenerator.GenerateRandomMaleFirstName();
    public override void BuildGender() => Gender = "Male";
}