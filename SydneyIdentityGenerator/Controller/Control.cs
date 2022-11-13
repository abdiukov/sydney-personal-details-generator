using Controller.Models;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Controller;

#nullable enable
public class Control
{
    public delegate void Builder(Person t);

    public async Task GeneratePersonsAndWriteToFile(int amountToGenerate, Builder? builder, string fileName)
    {
        var records = GeneratePersons(amountToGenerate, builder);
        await CsvFileWriter.WriteToFile(fileName, records).ConfigureAwait(false);
    }

    public static IEnumerable GeneratePersons(int amountToGenerate, Builder? builder)
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