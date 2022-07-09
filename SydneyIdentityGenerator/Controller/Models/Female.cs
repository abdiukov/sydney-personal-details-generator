namespace Controller.Models;

public class Female : Person
{
    public override void BuildFirstName() => FirstName = Helper.NameGenerator.GenerateRandomFemaleFirstName();
    public override void BuildGender() => Gender = "female";
}