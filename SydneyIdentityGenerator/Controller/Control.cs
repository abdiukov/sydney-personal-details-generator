using Controller.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controller;
public class Control<T> where T : Person
{
    public delegate void BuildInstructions(T t);

    public async Task GeneratePersonsAndWriteToCsv(int amountToGenerate, BuildInstructions buildDelegate, string fileName)
    {
        var records = GeneratePersons(amountToGenerate, buildDelegate);
        await CsvFileWriter.Write(fileName, records);
    }

    public static IEnumerable GeneratePersons(int amountToGenerate, BuildInstructions? buildDelegate)
    {
        return Enumerable.Range(1, amountToGenerate).Select(i =>
            {
                Person personToGenerate;

                // Roughly 50/50 chance here of generating either a male or a female
                if (i % 2 == 0)
                    personToGenerate = new Male();
                else
                    personToGenerate = new Female();

                if (buildDelegate != null) 
                    buildDelegate((T)personToGenerate);

                return personToGenerate;
            });
    }
}