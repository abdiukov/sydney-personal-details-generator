namespace Controller.Models;

public class Female : IPerson
{
    // custom properties
    public override string FirstName => Helper.NameGenerator.GenerateRandomFemaleFirstName();
    public override string Gender => "female";
}