using UnityEngine;

public class ScriptableObjectsController : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] _scriptableObjects;
    [SerializeField] private MapDisplay _mapDisplay;

    private int _currentIndex;

    private void Awake()
    {
        ChangeScriptableObject(0);
    }

    public void ChangeScriptableObject(int change)
    {
        _currentIndex += change;

        if (_currentIndex < 0)
            _currentIndex = _scriptableObjects.Length - 1;
        else if (_currentIndex > _scriptableObjects.Length - 1)
            _currentIndex = 0;

        if (_mapDisplay != null)
            _mapDisplay.DisplayMap((Map)_scriptableObjects[_currentIndex]);
    }
}
