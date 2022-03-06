using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [Header("Other")]
    [SerializeField] private GameObject _startButton;
    [SerializeField] private GameObject _pauseButton;

    [Header("Sound")]
    [SerializeField] private GameObject _soundOff;
    [SerializeField] private GameObject _soundOn;

    [Header("ControllButton")]
    [SerializeField] private GameObject _leftButton;
    [SerializeField] private GameObject _rightButton;

    [Header("Score")]
    [SerializeField] private GameObject _bestScore;
    [SerializeField] private GameObject _currentScore;

    private void Start()
    {
        SpeedBoost._tempForSpeed = 1;
    }

    public void StartLevel()
    {
        PoolOject._buttonWasPressed = true;
        _startButton.SetActive(false);

        _soundOff.SetActive(false);
        _soundOn.SetActive(false);

        _leftButton.SetActive(true);
        _rightButton.SetActive(true);

        _pauseButton.SetActive(true);

        _bestScore.SetActive(false);
        _currentScore.SetActive(true);
    }
}
