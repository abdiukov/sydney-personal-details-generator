using System.Collections;
using CsvHelper;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Globalization;

namespace Controller.Services;
public class CsvFileWriterService
{
    /*
     * TODO: find a way to use factory
     */
    public async Task WriteToFile(string fileName, IEnumerable recordsToWrite)
    {
        await using var streamWriter = new StreamWriter(fileName);
        await using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

        await csvWriter.WriteRecordsAsync(recordsToWrite);
    }
}
