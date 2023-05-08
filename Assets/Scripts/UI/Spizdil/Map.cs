using UnityEngine;

[CreateAssetMenu (fileName = "New Map", menuName = "Scriptable Objects/Map")]
public class Map : ScriptableObject
{
    [SerializeField] private int _index;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _image;
    [SerializeField] private Object _sceneToLoad;
    [SerializeField] private string _sceneName;

    public int Index => _index;
    public string Name => _name;
    public string Description => _description;
    public Sprite Image => _image;
    public Object SceneToLoad => _sceneToLoad;
    public string SceneName => _sceneName;
}
