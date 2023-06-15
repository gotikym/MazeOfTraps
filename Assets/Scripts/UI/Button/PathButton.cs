using System;
using UnityEngine;
using UnityEngine.UI;

public class PathButton : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private GameObject _path;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Button _pathButton;

    private const string PathLabel = "Line";

    public event Action<string> PathUsed;

    private void Awake()
    {
        LockedButton();
        FindGoodsPath();
    }

    private void OnEnable()
    {
        _inventory.InventoryChanged += InventoryChanged;
    }

    private void OnDisable()
    {
        _inventory.InventoryChanged -= InventoryChanged;
    }

    public void UsePath()
    {
        _path.SetActive(true);
        PathUsed?.Invoke(PathLabel);
        LockedButton();
        FindGoodsPath();
    }

    private void InventoryChanged()
    {
        FindGoodsPath();
    }

    private void FindGoodsPath()
    {
        foreach (var item in _inventory.Bag)
        {
            if (item.Label == PathLabel)
                UnlockedButton();
            else
                LockedButton();
        }
    }

    private void LockedButton()
    {
        _pathButton.interactable = false;
        _buttonImage.color = Color.grey;
    }

    private void UnlockedButton()
    {
        _pathButton.interactable = true;
        _buttonImage.color = Color.white;
    }
}
