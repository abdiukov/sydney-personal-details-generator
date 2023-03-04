using System.Collections.Generic;
using Controller.Models;

namespace Controller.Services.Interfaces;

public interface IPersonCreator
{
    public delegate void Builder(Person t);
    IEnumerable<Person> Create(int amountToGenerate, Builder builder);
}