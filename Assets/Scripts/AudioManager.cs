using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _jumpAudio;
    [SerializeField] private AudioSource _coinSound;
    public void PlayJumpSound()
    {
        _jumpAudio.Play();  
    }

    public void PlayCoinSound()
    {
        _coinSound.Play();
    }
}
