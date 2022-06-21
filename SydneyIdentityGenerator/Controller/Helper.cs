using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Controller;
public class Helper
{
    public readonly static Random Random = new();
    public readonly static PersonNameGenerator NameGenerator = new();
    public readonly static AddressGenerator AddressGenerator = new();
}

public class AddressGenerator
{
    private const string SYDNEY_ADDRESSES_FILE_NAME = "sydney_addresses.txt";
    private const int NUMBER_OF_LINES_SYDNEY_ADDRESSES_FILE = 1366279;
    private static IEnumerable<string> readFile = File.ReadLines(SYDNEY_ADDRESSES_FILE_NAME);
    public string GenerateRandomSydneyAddress()
    {
        int randomlyGeneratedLine = Helper.Random.Next(0, NUMBER_OF_LINES_SYDNEY_ADDRESSES_FILE);
        return readFile.Skip(randomlyGeneratedLine).First();
    }
}

public class CsvFileWriter
{
    public static void Write(string fileName, object records)
    {
        using StreamWriter writer = new(fileName);

        writer.Write(records);

        //// TODO: FIND A CSV WRITER THAT SERIALIZES THE OBJECTS NICELY

        //// write first line
        //// await writer.WriteAsync(parameters);

        //// write the contents of records
        //foreach (IPerson item in records)
        //{
        //    //var toWrite = parameters.GetInvocationList().Select(x => x.DynamicInvoke(item));

        //  //  await writer.WriteLineAsync(toWrite.ToString());
        //}
    }
}