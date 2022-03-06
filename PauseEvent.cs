using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEvent : MonoBehaviour
{
    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private GameObject _pauseButton;

    private float _tempForTimeScale;

    private Animator _pauseButtonAnimator;
    private Animator _pauseScreenAnimator;

    private void Start()
    {
        _pauseButtonAnimator = _pauseButton.GetComponent<Animator>();
        _pauseScreenAnimator = _pauseScreen.GetComponent<Animator>();
    }

    public void EventShowPauseScreen()
    {
        _pauseScreenAnimator.SetTrigger("ShowPauseScreen");
        _pauseButtonAnimator.SetTrigger("HidePauseButton");
    }
    public void EventPauseScene()
    {
        _tempForTimeScale = SpeedBoost._tempForSpeed;
        Time.timeScale = 0;
    }
    public void OnClickShowPauseScreen()
    {
        _pauseButtonAnimator.SetTrigger("Scale");
    }

    public void EventHidePauseScreen()
    {
        _pauseScreenAnimator.SetTrigger("HidePauseScreen");
        _pauseButtonAnimator.SetTrigger("ShowPauseButton");
    }     
    
    public void OnClickHidePauseScreen()
    {
        Time.timeScale = _tempForTimeScale;

        _pauseScreenAnimator.SetTrigger("ScaleResumeButton");
    }
}
