using System;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeStart;
    [SerializeField] private TMP_Text _timerText;

    public event Action TimeIsUp;

    private void Start()
    {
        _timerText.text = _timeStart.ToString();
    }

    private void FixedUpdate()
    {
        SubtractTime();
    }

    private void SubtractTime()
    {
        _timeStart -= Time.deltaTime;
        _timerText.text = Mathf.Round(_timeStart).ToString();

        if (_timeStart <= 0)        
            TimeIsUp?.Invoke();
    }
}
