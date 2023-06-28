using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Goods> _goods;
    [SerializeField] private Player _player;
    [SerializeField] private GoodsView _template;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _goods.Count; i++)
        {
            AddItem(_goods[i]);
        }
    }

    private void AddItem(Goods goods)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(goods);
    }

    private void OnSellButtonClick(Goods goods, GoodsView view)
    {
        TrySellGoods(goods, view);
    }

    private void TrySellGoods(Goods goods, GoodsView view)
    {
        if (goods.Price <= _player.Money)
        {
            _player.BuyGoods(goods);
            goods.Buy();
            view.SellButtonClick -= OnSellButtonClick;
            DisableItem(view);
        }
    }

    private void DisableItem(GoodsView view)
    {
        view.gameObject.SetActive(false);
    }
}