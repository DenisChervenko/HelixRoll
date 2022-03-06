using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    public void OnClick()
    {
        PoolOject._buttonWasPressed = false;
        PlayerPrefs.SetInt("Score", Score._tempForScore);
        Score._tempForScore = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
