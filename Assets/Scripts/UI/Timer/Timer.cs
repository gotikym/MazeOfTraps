using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeStart;
    [SerializeField] private TMP_Text _timerText;

    private void Start()
    {
        _timerText.text = _timeStart.ToString();
    }

    private void Update()
    {
        _timeStart -= Time.deltaTime;
        _timerText.text = Mathf.Round(_timeStart).ToString();
    }
}
