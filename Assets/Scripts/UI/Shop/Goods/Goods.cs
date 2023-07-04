using UnityEngine;

public abstract class Goods : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;

    public int Id => _id;
    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
}