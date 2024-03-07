using System;

/// <summary>
/// Класс, который считает количество ресурсов и оповещает ResourceView при изменении
/// </summary>
public class ResourceCounter: IDisposable
{
    public event Action<int> GoldChanged;
    public event Action<int> SilverChanged;
    public event Action<int> ResourcesChanged;

    private Clicker _clicker;
    private IPersistentData _persistentData;

    public ResourceCounter(Clicker clicker, IPersistentData persistentData)
    {
        _clicker = clicker;
        _persistentData = persistentData;

        _clicker.GoldClicked += AddGold;
        _clicker.SilverClicked += AddSilver;
    }

    public void Dispose()
    {
        _clicker.GoldClicked -= AddGold;
        _clicker.SilverClicked -= AddSilver;
    }

    public void ShowStartData()
    {
        GoldChanged?.Invoke(_persistentData.PlayerData.NumberOfGold);
        SilverChanged?.Invoke(_persistentData.PlayerData.NumberOfSilver);
        ResourcesChanged?.Invoke(_persistentData.PlayerData.NumberOfResources);
    }

    private void AddGold(int value)
    {
        if (value < 0)
            throw new ArgumentException(nameof(value));

        _persistentData.PlayerData.AddGold(value);

        GoldChanged?.Invoke(_persistentData.PlayerData.NumberOfGold);
        ResourcesChanged?.Invoke(_persistentData.PlayerData.NumberOfResources);
    }

    private void AddSilver(int value)
    {
        if (value < 0)
            throw new ArgumentException(nameof(value));

        _persistentData.PlayerData.AddSilver(value);

        SilverChanged?.Invoke(_persistentData.PlayerData.NumberOfSilver);
        ResourcesChanged?.Invoke(_persistentData.PlayerData.NumberOfResources);
    }
}
