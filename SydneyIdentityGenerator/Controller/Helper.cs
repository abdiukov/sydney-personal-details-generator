using CsvHelper;
using RandomNameGeneratorLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Controller.Models;

namespace Controller;
public class Helper
{
    public static Random Random = new();
    public static IPersonNameGenerator NameGenerator = new PersonNameGenerator();
    public static IAddressGenerator AddressGenerator = new AddressGenerator();
}

public interface IAddressGenerator { string GenerateRandomSydneyAddress(); }

public class AddressGenerator : IAddressGenerator
{
    // A NoSQL database could be used here, instead of storing addresses in a text file.
    const string SydneyAddressesFileName = "sydney_addresses.txt";
    const int NumberOfLinesSydneyAddressesFile = 1366279;
    static readonly IEnumerable<string> ReadFile = File.ReadLines(SydneyAddressesFileName);

    public string GenerateRandomSydneyAddress()
    {
        var randomlyGeneratedLine = Helper.Random.Next(0, NumberOfLinesSydneyAddressesFile);
        return ReadFile.Skip(randomlyGeneratedLine).First();
    }
}

public class CsvFileWriter
{
    public static async Task Write(string fileName, IEnumerable records)
    {
        using var streamWriter = new StreamWriter(fileName);
        using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
        await csvWriter.WriteRecordsAsync(records);
    }
}