using CsvHelper;
using Model;
using System.Globalization;
using System.IO;

namespace Controller
{
    public class CsvFileWriter
    {
        public static void Write(string fileName, string parameters, Person[] records)
        {
            //defining file writers
            StreamWriter stream = new(fileName);
            CsvWriter writer = new(stream, CultureInfo.InvariantCulture);
            writer.WriteField(parameters, false);

            //writing the rest of file
            for (int i = 0; i < records.Length; i++)
            {
                writer.WriteField("\n" + records[i].ToString(), false);
            }

            //disposing
            writer.Flush();
            stream.Close();
        }

    }
}
