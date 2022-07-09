using Controller.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controller;
public class Control<T> where T : Person
{
    public delegate void BuildInstructions(T t);

    public Task GeneratePersonsAndWriteToCsv(int amountToGenerate, BuildInstructions buildDelegate, string fileName)
    {
        IEnumerable records = GeneratePersons(amountToGenerate, buildDelegate);
        CsvFileWriter.Write(fileName, records);
        return Task.CompletedTask;
    }

    private IEnumerable<Person> GeneratePersons(int amountToGenerate, BuildInstructions buildDelegate)
    {
        return Enumerable.Range(1, amountToGenerate).Select(i =>
            {
                Person personToGenerate;

                // Roughly 50/50 chance here of generating either a male or a female
                if (i % 2 == 0)
                    personToGenerate = new Male();
                else
                    personToGenerate = new Female();

                buildDelegate((T)personToGenerate);
                return personToGenerate;
            });
    }
}