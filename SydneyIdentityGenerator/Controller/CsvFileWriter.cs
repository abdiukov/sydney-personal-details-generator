using CsvHelper;
using System.Globalization;
using System.IO;

namespace Controller
{
    public class CsvFileWriter
    {
        public static string[] Write(string fileName, string parameters, int amountToWrite)
        {
            //defining file writers
            StreamWriter stream = new(fileName);
            CsvWriter writer = new(stream, CultureInfo.InvariantCulture);
            writer.WriteField(parameters, false);

            //writing the rest of file
            for (int i = 0; i < amountToWrite; i++)
            {
                writer.WriteField("\n" + "stringgoeshere", false);
            }


            //disposing
            writer.Flush();
            stream.Close();

            return new string[10];
        }

    }
}
