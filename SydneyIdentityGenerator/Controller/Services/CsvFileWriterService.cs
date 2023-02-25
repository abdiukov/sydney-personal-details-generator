using System.Collections;
using CsvHelper;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace Controller.Services;
public class CsvFileWriterService
{
    public static async Task WriteToFile(string fileName, IEnumerable recordsToWrite)
    {
        await using var streamWriter = new StreamWriter(fileName);
        await using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

        await csvWriter.WriteRecordsAsync(recordsToWrite);
    }
}
