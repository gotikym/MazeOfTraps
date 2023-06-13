using UnityEngine;
using UnityEngine.UI;

public class Path : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _path;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Button _pathButton;

    private const string PathLabel = "Line";

    private void Awake()
    {
        LockedButton();
        FindGoodsPath();
    }

    private void OnEnable()
    {
        _player.InventoryChanged += InventoryChanged;
    }

    private void OnDisable()
    {
        _player.InventoryChanged -= InventoryChanged;
    }

    public void ShowPath()
    {
        _path.SetActive(true);
    }

    private void InventoryChanged()
    {
        FindGoodsPath();
    }

    private void FindGoodsPath()
    {
        foreach (var item in _player.Inventory)
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
