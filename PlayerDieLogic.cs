using System.Timers;
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class PlayerDieLogic : MonoBehaviour, IUnityAdsListener
{

    [Header("Ads")]
    [SerializeField] private bool _testMode = false;

    [Header("Music")]
    [SerializeField] private GameObject _soundObject;

    private string _video = "Interstitial_Android";

#if UNITY_IOS

    private string _gameId = "4645516";

#endif

#if UNITY_ANDROID

    private string _gameId = "4645517";

#endif

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, _testMode);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            PlayerPrefs.SetInt("Score", Score._tempForScore);
            Score._tempForScore = 0;
            _soundObject.SetActive(false);

            ShowAdsVideo(_video);
        }   
    }

    

    private void ShowAdsVideo(string placementId)
    {
        Advertisement.Show(placementId);
    }

    #region InterfaceForAds

    public void OnUnityAdsReady(string placementId)
    {

    }

    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }
    #endregion

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Skipped)
        {
            Time.timeScale = 1;
            PoolOject._buttonWasPressed = false;
            SceneManager.LoadScene(0);
        }
        
        if(showResult == ShowResult.Finished)
        {
            Time.timeScale = 1;
            PoolOject._buttonWasPressed = false;
            SceneManager.LoadScene(0);
        }
    }
}
