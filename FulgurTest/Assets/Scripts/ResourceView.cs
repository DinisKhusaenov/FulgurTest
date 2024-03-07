using TMPro;
using UnityEngine;


/// <summary>
///  ласс, который дл€ отображени€ данных ресурсов
/// </summary>
public class ResourceView : MonoBehaviour
{
    [SerializeField] private TMP_Text _gold;
    [SerializeField] private TMP_Text _silver;
    [SerializeField] private TMP_Text _sharedResources;

    private ResourceCounter _resourceCounter;

    public void Initialize(ResourceCounter resource)
    {
        _resourceCounter = resource;

        _resourceCounter.GoldChanged += ChangeGoldText;
        _resourceCounter.SilverChanged += ChangeSilverText;
        _resourceCounter.ResourcesChanged += ChangeSharedResourcesText;
    }

    private void OnDisable()
    {
        _resourceCounter.GoldChanged -= ChangeGoldText;
        _resourceCounter.SilverChanged -= ChangeSilverText;
        _resourceCounter.ResourcesChanged -= ChangeSharedResourcesText;
    }

    private void ChangeGoldText(int value)
    {
        _gold.text = value.ToString();
    }

    private void ChangeSilverText(int value)
    {
        _silver.text = value.ToString();
    }

    private void ChangeSharedResourcesText(int value)
    {
        _sharedResources.text = value.ToString();
    }
}
