using UnityEngine;

public class MainMenuAnimation : MonoBehaviour
{
    [SerializeField] private Animator _mainMenu;

    public void OpenChooseLevel()
    {
        _mainMenu.Play("ChooseLevel");
    }

    public void OpenAchivement()
    {
        _mainMenu.Play("ChooseAchivements");
    }

    public void OpenSettings()
    {
        _mainMenu.Play("ChooseSettings");
    }
}
