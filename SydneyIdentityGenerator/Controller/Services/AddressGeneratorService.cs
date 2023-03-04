using System.Collections.Generic;
using System;
using System.IO;
using Controller.Services.Interfaces;

namespace Controller.Services;
public class AddressGeneratorService : IAddressGeneratorService
{
    private readonly IReadOnlyList<string> ReadFileLinesList;
    public AddressGeneratorService(string addressFileName)
    {
        // A NoSQL database could be used here, instead of storing addresses in a text file.
        var fileName = addressFileName ?? Constants.DefaultAddressFileName;
        ReadFileLinesList = File.ReadAllLines(fileName);
    }

    public string GetRandomAddress()
    {
        var randomIndex = Random.Shared.Next(0, ReadFileLinesList.Count);
        return ReadFileLinesList[randomIndex];
    }
}