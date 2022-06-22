using CsvHelper;
using RandomNameGeneratorLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
    public static async void Write(string fileName, IEnumerable records)
    {
        using (var writer = new StreamWriter(fileName))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            await csv.WriteRecordsAsync(records);
        }

    }
}