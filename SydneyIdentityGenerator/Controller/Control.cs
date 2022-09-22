using Controller.Models;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Controller;
public class Control
{
    public delegate void BuildInstructions(Person t);

    public async Task GeneratePersonsAndWriteToCsv(int amountToGenerate, BuildInstructions builder, string fileName)
    {
        var records = GeneratePersons(amountToGenerate, builder);
        await CsvFileWriter.Write(fileName, records);
    }

    public static IEnumerable GeneratePersons(int amountToGenerate, BuildInstructions? builder)
    {
        return Enumerable.Range(1, amountToGenerate).Select(i =>
            {
                Person personToGenerate;

                // Roughly 50/50 chance here of generating either a male or a female
                if (i % 2 == 0)
                    personToGenerate = new Male();
                else
                    personToGenerate = new Female();

                if (builder != null)
                    builder(personToGenerate);

                return personToGenerate;
            });
    }
}