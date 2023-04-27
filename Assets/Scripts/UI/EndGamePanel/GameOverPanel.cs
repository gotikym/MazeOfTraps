using UnityEngine;

public class GameOverPanel : EndGamePanel
{
    [SerializeField] private Player _player;

    protected override void OnEnable()
    {
        _player.Died += OpenPanel;
    }

    protected override void OnDisable()
    {
        _player.Died -= OpenPanel;
    }
}