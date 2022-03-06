using System.Xml.Serialization;
using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeSlow : MonoBehaviour
{
    [SerializeField] private float _stepForMinusTimeScale;
    [SerializeField] private GameObject _sound;

    private AudioSource _audio;

    private void Start()
    {
        _audio = _sound.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {   
            _audio.Play();

            Time.timeScale -= _stepForMinusTimeScale;

            if(Time.timeScale <= 1)
            {
                Time.timeScale = 1;
            }
        }
    }
}
