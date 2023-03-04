using CsvHelper;
namespace Controller.Services.Interfaces;
public interface ICsvWriterFactory
{
    CsvWriter Create(string fileName);
}
