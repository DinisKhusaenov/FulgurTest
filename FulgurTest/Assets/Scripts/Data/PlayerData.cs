using Newtonsoft.Json;
using System;

public class PlayerData
{
    private int _numberOfGold;
    private int _numberOfSilver;
    private int _numberOfResources;

    public PlayerData()
    {
        _numberOfGold = 0;
        _numberOfSilver = 0;
        _numberOfResources = 0;
    }

    [JsonConstructor]
    public PlayerData(int numberOfGold, int numberOfSilver, int numberOfResources)
    {
        _numberOfGold = numberOfGold;
        _numberOfSilver = numberOfSilver;
        _numberOfResources = numberOfResources;
    }

    public int NumberOfGold => _numberOfGold;

    public int NumberOfSilver => _numberOfSilver;

    public int NumberOfResources => _numberOfResources;

    public void AddGold(int value)
    {
        if (value < 0)
            throw new ArgumentException(nameof(value));

        _numberOfGold += value;
        _numberOfResources += value;
    }

    public void AddSilver(int value)
    {
        if (value < 0)
            throw new ArgumentException(nameof(value));

        _numberOfSilver += value;
        _numberOfResources += value;
    }
}
