using System;
using System.Collections.Generic;
using System.Linq;
using Controller.Models;
using Controller.Services.Interfaces;

namespace Controller.Services;

public class PersonCreator : IPersonCreator
{
    public IEnumerable<Person> Create(int amountToGenerate, IPersonCreator.Builder? builder)
    {
        return Enumerable.Range(1, amountToGenerate).Select(_ =>
        {
            // Roughly 50/50 chance here of generating either a male or a female
            Person personToGenerate = Random.Shared.Next(0, 2) switch
            {
                0 => new Male(),
                _ => new Female()
            };

            // Build the Person
            builder?.Invoke(personToGenerate);

            return personToGenerate;
        });
    }
}