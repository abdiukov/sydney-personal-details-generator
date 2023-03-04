using System.Collections;
using System.Threading.Tasks;
using Controller.Services.Interfaces;

namespace Controller.Services;
public class CsvFileWriterService
{
    private ICsvWriterFactory _csvWriterFactory;
    public CsvFileWriterService(ICsvWriterFactory factory) 
    {
        _csvWriterFactory = factory;
    }

    public async Task WriteToFile(string fileName, IEnumerable recordsToWrite)
    {
        var csvWriter = _csvWriterFactory.Create(fileName);

        await csvWriter.WriteRecordsAsync(recordsToWrite);
    }
}
