using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProgressScore : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _score;

    private string _minScore = "0";
    private string _maxScore = "3";

    private void Start()
    {
        _score.text = $"{_minScore} / {_maxScore}";
    }

    private void OnEnable()
    {
       // _player.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
       // _player.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score, int maxScore)
    {
        _score.text = $"{score.ToString()} / {maxScore.ToString()}";
    }
}
