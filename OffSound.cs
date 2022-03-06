using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffSound : MonoBehaviour
{
    [SerializeField] private GameObject _soundOn;
    [SerializeField] private GameObject _soundOff;

    [SerializeField] private GameObject _sound;
    private AudioSource _audio;

    private void Start()
    {
        _audio = _sound.GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        _soundOff.SetActive(true);
        _soundOn.SetActive(false);

        _audio.Pause();
    }
}
