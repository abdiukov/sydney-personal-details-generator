using CsvHelper;
using RandomNameGeneratorLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace Controller;
public class Helper
{
    public static IPersonNameGenerator NameGenerator { get; set; } = new PersonNameGenerator();
    public static IAddressGenerator AddressGenerator { get; set; } = new SydneyAddressGenerator();
}

public interface IAddressGenerator { string GetRandomAddress(); }
public class SydneyAddressGenerator : IAddressGenerator
{
    // A NoSQL database could be used here, instead of storing addresses in a text file.
    private const string AddressFileName = "sydney_addresses.txt";
    private static readonly IReadOnlyList<string> ReadFileLinesList = File.ReadAllLines(AddressFileName);

    public string GetRandomAddress()
    {
        var randomIndex = Random.Shared.Next(0, ReadFileLinesList.Count);
        return ReadFileLinesList[randomIndex];
    }
}

public class CsvFileWriter
{
    public static async Task WriteToFile(string fileName, IEnumerable recordsToWrite)
    {
        await using var streamWriter = new StreamWriter(fileName);
        await using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
        await csvWriter.WriteRecordsAsync(recordsToWrite);
    }
}