using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup Mixer;
    private void Start()
    {
        bool enabledMusic = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        var volumeVale = PlayerPrefs.GetFloat("MasterVolume", 1);
        if (enabledMusic)
            Mixer.audioMixer.SetFloat("MasterVolume", volumeVale);
        else Mixer.audioMixer.SetFloat("MasterVolume", -80);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene(1);
    }
}
