using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private AllItems _allItems;
    [SerializeField] private List<Goods> _bag;
    [SerializeField] private Player _player;
    [SerializeField] private PathButton _path;

    private const string FirstGoodsKey = "Inventory0";
    private const string InventoryCountKey = "InventoryCount";

    private Goods _removedGoods;

    public List<Goods> Bag => _bag;

    public event Action InventoryChanged;

    private void OnEnable()
    {
        Load();
        _player.BuyedGoods += BuyedGoods;
        _path.PathUsed += UsedGoods;
    }

    private void OnDisable()
    {
        _player.BuyedGoods -= BuyedGoods;
        _path.PathUsed -= UsedGoods;
    }

    public void BuyedGoods(Goods goods)
    {
        _bag.Add(goods);
        PlayerPrefs.SetInt(InventoryCountKey, _bag.Count);
        InventoryChanged?.Invoke();
        Save();
    }

    private void UsedGoods(string goodsLabel)
    {
        foreach (var item in _bag)
        {
            if (item.Label == goodsLabel)
                _removedGoods = item;
        }

        _bag.Remove(_removedGoods);
        PlayerPrefs.SetInt(InventoryCountKey, _bag.Count);
        InventoryChanged?.Invoke();
        Save();
    }

    private void Save()
    {
        if (_bag.Count == 0)
            PlayerPrefs.DeleteKey(FirstGoodsKey);
        else
            for (int i = 0; i < _bag.Count; i++)
                PlayerPrefs.SetInt("Inventory" + i, _bag[i].Id);
    }

    private void Load()
    {
        int inventoryCount = PlayerPrefs.GetInt(InventoryCountKey);

        for (int i = 0; i < inventoryCount; i++)
        {
            for (int j = 0; j < _allItems.AllGoods.Count; j++)
            {
                if (PlayerPrefs.GetInt("Inventory" + i) == _allItems.AllGoods[j].Id)
                    _bag.Add(_allItems.AllGoods[j]);
            }
        }
    }
}
