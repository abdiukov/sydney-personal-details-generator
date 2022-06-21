using Controller.Models;
using System.Threading.Tasks;
using static Controller.Builder<Controller.Models.IPerson>;

namespace Controller;
public class Control
{
    public Task GeneratePersonsAndWriteToCsv(int amountToGenerate, BuildInstructions parameters, string fileName)
    {
        IPerson[] records = GeneratePersons(amountToGenerate, parameters);
        CsvFileWriter.Write(fileName, records);
        return Task.CompletedTask;
    }

    private IPerson[] GeneratePersons(int amountToGenerate, BuildInstructions buildDelegate)
    {
        IPerson[] output = new IPerson[amountToGenerate];
        for (var i = 0; i < amountToGenerate; i++)
        {
            //TODO: for now the decision to generate male or female is not truly random. Does it need to be?
            if (amountToGenerate % 2 == 0)
                output[i] = new Male();
            else
                output[i] = new Female();

            // Build
            buildDelegate(output[i]);
        }

        return output;
    }
}