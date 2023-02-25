using System.Collections.Generic;
using System;
using System.IO;
using Controller.Services.Interfaces;

namespace Controller.Services;
public class SydneyAddressGeneratorService : IAddressGeneratorService
{
    // A NoSQL database could be used here, instead of storing addresses in a text file.
    private readonly IReadOnlyList<string> ReadFileLinesList = File.ReadAllLines(_addressFileName);
    private string _addressFileName = "sydney_addresses.txt";
    public SydneyAddressGeneratorService(string fileName)
    {
        _addressFileName = fileName;
    }


    public string GetRandomAddress()
    {
        var randomIndex = Random.Shared.Next(0, ReadFileLinesList.Count);
        return ReadFileLinesList[randomIndex];
    }
}