using Controller.Models;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Controller;

#nullable enable
public class Control
{
    public delegate void Builder(Person t);

    public async Task GeneratePersonsAndWriteToCsv(int amountToGenerate, Builder? builder, string fileName)
    {
        var records = GeneratePersons(amountToGenerate, builder);
        await CsvFileWriter.Write(fileName, records);
    }

    public static IEnumerable GeneratePersons(int amountToGenerate, Builder? builder)
    {
        return Enumerable.Range(1, amountToGenerate).Select(i =>
            {
                Person personToGenerate;

                // Roughly 50/50 chance here of generating either a male or a female
                if (i % 2 == 0)
                    personToGenerate = new Male();
                else
                    personToGenerate = new Female();

                builder?.Invoke(personToGenerate);

                return personToGenerate;
            });
    }
}