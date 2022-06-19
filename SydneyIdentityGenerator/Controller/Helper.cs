using Controller.Models;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Controller;
public class Helper
{
    public readonly static Random Random = new();
    public readonly static PersonNameGenerator NameGenerator = new();
    public readonly static AddressGenerator AddressGenerator = new();
    public static readonly DateOfBirthGenerator DateOfBirthGenerator = new();
}

public class DateOfBirthGenerator
{
    public string GenerateRandomDate()
    {
        //generate a year between 1950 and 2002
        int year = 1950 + Helper.Random.Next(0, 53);

        //generate a month between 1 and 12
        int month = Helper.Random.Next(1, 13);

        //generate the day of month between 1 and 28
        int dayOfMonth = Helper.Random.Next(1, 29);

        return $"{year}-{month}-{dayOfMonth}";
    }
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
    public static async void Write(string fileName, MultiDelegate parameters, IPerson[] records)
    {
        using StreamWriter writer = new(fileName);

        // write first line
        // await writer.WriteAsync(parameters);

        // write the contents of records
        foreach (IPerson item in records)
        {
            var toWrite = parameters.GetInvocationList().Select(x => x.DynamicInvoke(item));

            await writer.WriteLineAsync(toWrite.ToString());
        }
    }
}