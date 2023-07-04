using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GoodsView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    private Goods _goods;

    public event UnityAction<Goods> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Render(Goods goods)
    {
        _goods = goods;
        _label.text = goods.Label;
        _price.text = goods.Price.ToString();
        _icon.sprite = goods.Icon;
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_goods);
    }
}