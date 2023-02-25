using System.Collections;
using System.Threading.Tasks;

namespace Controller.Services.Interfaces;

public interface IFileWriterService
{
    Task Write(string fileName, IEnumerable recordsToWrite);
}