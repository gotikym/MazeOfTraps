using UnityEngine;

public class SwitchMap : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] _maps;
    [SerializeField] private MapDisplay _mapDisplay;

    private int _currentIndex;

    private void Awake()
    {
        ChooseMap(0);
    }

    public void ChooseMap(int switchMap)
    {
        _currentIndex += switchMap;

        if (_currentIndex < 0)
            _currentIndex = _maps.Length - 1;
        else if (_currentIndex > _maps.Length - 1)
            _currentIndex = 0;

        if (_mapDisplay != null)
            _mapDisplay.DisplayMap((Map)_maps[_currentIndex]);
    }
}
