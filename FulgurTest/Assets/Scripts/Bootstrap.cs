using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Clicker _clicker;
    [SerializeField] private ResourceView _resourceView;

    private ResourceCounter _resourceCounter;
    private PersistentData _persistentData;
    private DataLocalProvider _dataProvider;

    private void Awake()
    {
        _persistentData = new PersistentData();
        _dataProvider = new DataLocalProvider(_persistentData);
        LoadDataOrInit();

        _resourceCounter = new ResourceCounter(_clicker, _persistentData);
        _resourceView.Initialize(_resourceCounter);
        _resourceCounter.ShowStartData();
    }

    private void OnDisable()
    {
        _dataProvider.Save();
        _resourceCounter.Dispose();
    }

    private void LoadDataOrInit()
    {
        if (_dataProvider.TryLoad() == false)
            _persistentData.PlayerData = new PlayerData();
    }
}
