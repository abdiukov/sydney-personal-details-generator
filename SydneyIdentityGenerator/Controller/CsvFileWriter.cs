using CsvHelper;
using Model;
using System.Globalization;
using System.IO;

namespace Controller
{
    public class CsvFileWriter
    {
        public static string[] Write(string fileName, int amountToWrite)
        {
            //defining file writers
            StreamWriter stream = new(fileName);
            CsvWriter writer = new(stream, CultureInfo.InvariantCulture);

            //getting a header of the csv file (the first line in csv file)
            string csvHeader = "";
            foreach (var item in UserChoice.ChosenParameters)
            {
                csvHeader += item + ",";
            }

            //writing the header
            writer.WriteField(csvHeader, false);

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
