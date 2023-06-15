using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Goods> _bag;
    [SerializeField] private Player _player;
    [SerializeField] private PathButton _path;

    private Goods _removedGoods;

    public List<Goods> Bag => _bag;

    public event Action InventoryChanged;

    private void OnEnable()
    {
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
        InventoryChanged?.Invoke();
    }

    private void UsedGoods(string goodsLabel)
    {
        foreach (var item in _bag)
        {
            if (item.Label == goodsLabel)            
                _removedGoods = item;            
        }

        _bag.Remove(_removedGoods);
        InventoryChanged?.Invoke();
    }
}
