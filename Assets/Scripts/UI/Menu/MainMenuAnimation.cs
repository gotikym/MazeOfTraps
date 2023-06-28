using UnityEngine;

public class MainMenuAnimation : MonoBehaviour
{
    [SerializeField] private Animator _mainMenu;

    private const string ChooseLevelName = "ChooseLevel";
    private const string ChooseAchivementsName = "ChooseAchivements";
    private const string ChooseSettingsName = "ChooseSettings";

    public void OpenChooseLevel()
    {
        _mainMenu.Play(ChooseLevelName);
    }

    public void OpenAchivement()
    {
        _mainMenu.Play(ChooseAchivementsName);
    }

    public void OpenSettings()
    {
        _mainMenu.Play(ChooseSettingsName);
    }
}
