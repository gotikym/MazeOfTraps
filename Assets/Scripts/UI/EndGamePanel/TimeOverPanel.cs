using UnityEngine;

public class TimeOverPanel : EndGamePanel
{
    [SerializeField] private Timer _timer;

    protected override void OnEnable()
    {
        _timer.TimeIsUp += OpenPanel;
    }

    protected override void OnDisable()
    {
        _timer.TimeIsUp -= OpenPanel;
    }
}