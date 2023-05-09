using UnityEngine;
using IJunior.TypedScenes;

public class LoadLevelScene : MonoBehaviour
{
    [SerializeField] private GameObject _loadScreen;

    private const int NumberLevel1 = 1;
    private const int NumberLevel2 = 2;
    private const int NumberLevel3 = 3;

    private int _numberLevel;

    private void OnEnable()
    {
        ChooseLevel.LevelChoosed += OnLevelChoosed;
    }

    private void OnDisable()
    {
        ChooseLevel.LevelChoosed -= OnLevelChoosed;        
    }

    public void LoadLevel()
    {
        _loadScreen.SetActive(true);

        switch (_numberLevel)
        {
            case NumberLevel1: Level1.Load(); break;
            case NumberLevel2: Level2.Load(); break;
            case NumberLevel3: Level3.Load(); break;
        }
    }

    private void OnLevelChoosed(int numberLevel)
    {
        _numberLevel = numberLevel;
    }
}