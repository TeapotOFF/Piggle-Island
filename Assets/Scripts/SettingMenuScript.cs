using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenuScript : MonoBehaviour
{
    public AudioMixerGroup Mixer;
    private float _volumeValue;

    private void Awake()
    {
        GetComponentInChildren<Slider>().value = Mathf.Pow(10f, PlayerPrefs.GetFloat("MasterVolume", 1) / 20f);
        GetComponentInChildren<Toggle>().isOn = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
    }

    public void ToggleMusic(bool enabled)
    {
        if (enabled)
        {
            _volumeValue = PlayerPrefs.GetFloat("MasterVolume", 1);
            Mixer.audioMixer.SetFloat("MasterVolume", _volumeValue);
        }
        else
            Mixer.audioMixer.SetFloat("MasterVolume", -80);

        PlayerPrefs.SetInt("MusicEnabled", enabled ? 1 : 0);
    }

    public void ChangeVolume(float volume)
    {
        if (GetComponentInChildren<Toggle>().isOn)
        {
            _volumeValue = Mathf.Log10(volume) * 20f;
            Mixer.audioMixer.SetFloat("MasterVolume", _volumeValue);

            PlayerPrefs.SetFloat("MasterVolume", _volumeValue);
        }
    }

    public void AccessButton()
    {
        gameObject.SetActive(false);
    }
}