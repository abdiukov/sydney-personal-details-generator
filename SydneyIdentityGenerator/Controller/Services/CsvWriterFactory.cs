using CsvHelper;
using System.Globalization;
using System.IO;

namespace Controller.Services;
public class CsvWriterFactory
{
    public CsvWriter Create(string fileName)
    {
        var streamWriter = new StreamWriter(fileName);
        var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

        return csvWriter;
    }
}