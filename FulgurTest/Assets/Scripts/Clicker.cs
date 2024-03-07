using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс, который обрабатывает нажатие кнопок
/// </summary>
public class Clicker : MonoBehaviour
{
    private const int NumberOfGold = 1;
    private const int NumberOfSilver = 1;

    public event Action<int> GoldClicked;
    public event Action<int> SilverClicked;

    [SerializeField] private Button _gold;
    [SerializeField] private Button _silver;

    private void OnEnable()
    {
        _gold.onClick.AddListener(OnGoldButtonClicked);
        _silver.onClick.AddListener(OnSilverButtonClicked);
    }

    private void OnDisable()
    {
        _gold.onClick.RemoveListener(OnGoldButtonClicked);
        _silver.onClick.RemoveListener(OnSilverButtonClicked);
    }

    private void OnGoldButtonClicked()
    {
        GoldClicked?.Invoke(NumberOfGold);
    }

    private void OnSilverButtonClicked()
    {
        SilverClicked?.Invoke(NumberOfSilver);
    }
}
