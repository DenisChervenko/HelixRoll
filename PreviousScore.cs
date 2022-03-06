using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreviousScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _previousScoreText;

    private int _previousScore;

    private void Start()
    {
        if(PlayerPrefs.HasKey("Score"))
        {
            _previousScore = PlayerPrefs.GetInt("Score");
        }

        if(_previousScore > 0)
        {
            _previousScoreText.text = Convert.ToString(_previousScore);
        }
    }
}
