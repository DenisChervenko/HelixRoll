using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TMP_Text _score;

    [Header("Time")]
    [SerializeField] private float _timeBetwenScoreIncrement;
    private float _elapsedTime;

    [Header("Score")]
    [SerializeField] private int _scoreCount;
    static public int _tempForScore;

    private void FixedUpdate()
    {
        if(PoolOject._buttonWasPressed)
        {
            _elapsedTime += Time.fixedDeltaTime;

            if(_elapsedTime >= _timeBetwenScoreIncrement)
            {
                _tempForScore += _scoreCount;
                _score.text = Convert.ToString(_tempForScore);

                _elapsedTime = 0;
            }
        }
    }
}
