using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuffTimer : MonoBehaviour
{
    [SerializeField] private GameObject _buffTimerImage;
    [SerializeField] private Image _buffBarFilling;
    [SerializeField] private TMP_Text _timerBuffText;

    private float _currentTime;
    private Coroutine _previosesTask;

    private void OnEnable()
    {
        Dice.Buffed += OnBuffed;
    }

    private void OnDisable()
    {
        Dice.Buffed -= OnBuffed;
    }

    private void OnBuffed(Buff buff)
    {
        _buffTimerImage.SetActive(true);

        if (_previosesTask != null)
            StopCoroutine(_previosesTask);

        _previosesTask = StartCoroutine(FillingTimeBar(buff.Duration, buff.Name));
    }

    private IEnumerator FillingTimeBar(float buffTime, string buffName)
    {
        _currentTime = buffTime;

        while (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            _buffBarFilling.fillAmount = _currentTime / buffTime;

            _timerBuffText.text = buffName + " up " + Mathf.Round(_currentTime).ToString();

            yield return null;
        }

        _buffTimerImage.SetActive(false);
    }
}
