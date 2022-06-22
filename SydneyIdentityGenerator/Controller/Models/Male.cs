namespace Controller.Models;

public class Male : IPerson
{
    // custom properties
    public override string FirstName => Helper.NameGenerator.GenerateRandomMaleFirstName();
    public override string Gender => "male";
}
