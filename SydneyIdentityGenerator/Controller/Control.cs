using Controller.Models;
using Controller.Services;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controller;
public class Control
{
    public Task GeneratePersonsAndWriteToCsv(int amountToGenerate, Builder<Person>.BuildInstructions parameters, string fileName)
    {
        IEnumerable records = GeneratePersons(amountToGenerate, parameters);
        CsvFileWriter.Write(fileName, records);
        return Task.CompletedTask;
    }

    private IEnumerable<Person> GeneratePersons(int amountToGenerate, Builder<Person>.BuildInstructions buildDelegate)
    {
        IEnumerable<Person> maleList = Enumerable.Range(1, amountToGenerate / 2)
            .Select(i =>
            {
                var male = new Male();
                buildDelegate(male);
                return male;
            });
        IEnumerable<Person> femaleList = Enumerable.Range(1, amountToGenerate / 2)
            .Select(i =>
            {
                var female = new Female();
                buildDelegate(female);
                return female;
            });
        return maleList.Concat(femaleList);
    }
}