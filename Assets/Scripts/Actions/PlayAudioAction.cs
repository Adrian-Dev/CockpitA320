using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioAction : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;

    public void PlayAudio()
    {
        _audioSource.clip = _audioClip;
        _audioSource.Play();
    }

    public void PlayAudioClip(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }
}
