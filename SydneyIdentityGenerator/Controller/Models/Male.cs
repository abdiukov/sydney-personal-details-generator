namespace Controller.Models;
public class Male : IPerson
{
    public string FirstName => Helper.NameGenerator.GenerateRandomMaleFirstName();
    public string Gender => "male";
}
