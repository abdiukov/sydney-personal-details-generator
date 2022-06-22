using Controller.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using static Controller.Builder<Controller.Models.IPerson>;

namespace Controller;
public class Control
{
    public Task GeneratePersonsAndWriteToCsv(int amountToGenerate, /*BuildInstructions parameters,*/ string fileName)
    {
        IEnumerable<IPerson> records = GeneratePersons(amountToGenerate/*, parameters*/);
        CsvFileWriter.Write(fileName, records);
        return Task.CompletedTask;
    }

    private IEnumerable<IPerson> GeneratePersons(int amountToGenerate/*, BuildInstructions buildDelegate*/)
    {
        IEnumerable<IPerson> maleList = Enumerable.Range(1, amountToGenerate / 2).Select(i => /*buildDelegate*/(new Male()));
        IEnumerable<IPerson> femaleList = Enumerable.Range(1, amountToGenerate / 2).Select(i => /*buildDelegate*/(new Female()));
        return maleList.Concat(femaleList);
    }
}