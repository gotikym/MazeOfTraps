using UnityEngine;

public class SwitchMap : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] _maps;
    [SerializeField] private MapDisplay _mapDisplay;

    private int _firstMapIndex = 0;
    private int _currentIndex;

    private void Awake()
    {
        ChooseMap(0);
    }

    public void ChooseMap(int switchMap)
    {
        int _lastMapIndex = _maps.Length - 1;
        _currentIndex += switchMap;

        if (_currentIndex < _firstMapIndex)
            _currentIndex = _lastMapIndex;
        else if (_currentIndex > _lastMapIndex)
            _currentIndex = _firstMapIndex;

        if (_mapDisplay != null)
            _mapDisplay.DisplayMap((Map)_maps[_currentIndex]);
    }
}
