using System.Collections.Generic;
using UnityEngine;

public class AllItems : MonoBehaviour
{
    [SerializeField] private List<Goods> _allGoods;

    public List<Goods> AllGoods => _allGoods;
}
