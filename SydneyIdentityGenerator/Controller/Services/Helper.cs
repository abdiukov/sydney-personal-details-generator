using CsvHelper;
using RandomNameGeneratorLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Controller.Services;
public class Helper
{
    public static readonly Random Random = new();
    public static readonly PersonNameGenerator NameGenerator = new();
    public static readonly AddressGenerator AddressGenerator = new();
}

public class AddressGenerator
{
    private const string SydneyAddressesFileName = "sydney_addresses.txt";
    private const int NumberOfLinesSydneyAddressesFile = 1366279;
    private static readonly IEnumerable<string> ReadFile = File.ReadLines(SydneyAddressesFileName);
    public string GenerateRandomSydneyAddress()
    {
        var randomlyGeneratedLine = Helper.Random.Next(0, NumberOfLinesSydneyAddressesFile);
        return ReadFile.Skip(randomlyGeneratedLine).First();
    }
}

public class CsvFileWriter
{
    public static async void Write(string fileName, IEnumerable records)
    {
        await using var writer = new StreamWriter(fileName);
        await using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        await csv.WriteRecordsAsync(records);
    }
}