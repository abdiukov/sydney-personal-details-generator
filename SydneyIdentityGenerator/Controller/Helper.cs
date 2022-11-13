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
    public static IPersonNameGenerator NameGenerator = new PersonNameGenerator();
    public static IAddressGenerator AddressGenerator = new AddressGenerator();
}

public interface IAddressGenerator { string GenerateRandomSydneyAddress(); }
public class AddressGenerator : IAddressGenerator
{
    // A NoSQL database could be used here, instead of storing addresses in a text file.
    private const string SydneyAddressesFileName = "sydney_addresses.txt";
    private static readonly IReadOnlyList<string> ReadFile = File.ReadAllLines(SydneyAddressesFileName);

    public string GenerateRandomSydneyAddress()
    {
        var randomIndex = Random.Shared.Next(0, ReadFile.Count);
        return ReadFile[randomIndex];
    }
}

public class CsvFileWriter
{
    public static async Task Write(string fileName, IEnumerable records)
    {
        await using var streamWriter = new StreamWriter(fileName);
        await using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
        await csvWriter.WriteRecordsAsync(records);
    }
}