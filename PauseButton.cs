using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject _pauseScreen;


    public void OnClick()
    {
        gameObject.SetActive(false);
        _pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
