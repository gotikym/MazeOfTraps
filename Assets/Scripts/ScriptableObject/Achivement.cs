using UnityEngine;

[CreateAssetMenu(fileName = "New Achivement", menuName = "Scriptable Objects/Achivement")]
public class Achivement : ScriptableObject
{
    [SerializeField] private int _index;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _image;

    public int Index => _index;
    public string Name => _name;
    public string Description => _description;
    public Sprite Image => _image;
}