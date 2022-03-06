using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private GameObject _pauseButton;

    public void OnClick()
    {
        Time.timeScale = SpeedBoost._tempForSpeed;
        _pauseScreen.SetActive(false);
        _pauseButton.SetActive(true);
    }
}
