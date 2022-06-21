namespace Controller.Models;

public class Female : IPerson
{
    public string FirstName { get; } = Helper.NameGenerator.GenerateRandomFemaleFirstName();
    public string Gender => "female";
}