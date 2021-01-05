using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrottleAudio : MonoBehaviour
{
    [SerializeField] AudioClip _audioTurbineIdle;
    [SerializeField] AudioClip _audioTurbineContinuous;
    [SerializeField] AudioClip _audioTurbineAccelerate;
    [SerializeField] AudioClip _audioTurbineDecelerate;
    [SerializeField] AudioClip _audioTurbineContinuousReverse;
    [SerializeField] AudioClip _audioTurbineAccelerateReverse;
    [SerializeField] AudioClip _audioTurbineDecelerateReverse;

    AudioSource _audioSource;

    ThrottlePosition _throttlePosition;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _throttlePosition = GetComponent<ThrottlePosition>();
    }

    public void UpdateThrottleSound()
    {
        StartCoroutine(UpdateThrottleSoundCoroutine());
    }

    IEnumerator UpdateThrottleSoundCoroutine()
    {
        if (_throttlePosition.CurrentPosition != _throttlePosition.PreviousPosition)
        {
            if (_throttlePosition.CurrentPosition > ThrottlePosition.Position.Idle &&
                _throttlePosition.PreviousPosition == ThrottlePosition.Position.Idle) // Acceleration
            {
                _audioSource.clip = _audioTurbineAccelerate;
                _audioSource.loop = false;
                _audioSource.Play();
                yield return new WaitUntil(() => (!_audioSource.isPlaying));

                _audioSource.clip = _audioTurbineContinuous;
                _audioSource.loop = true;
                _audioSource.Play();
            }
            else if (_throttlePosition.CurrentPosition < ThrottlePosition.Position.Idle &&
                _throttlePosition.PreviousPosition == ThrottlePosition.Position.Idle) // Max Reverse Acceleration
            {
                _audioSource.clip = _audioTurbineAccelerateReverse;
                _audioSource.loop = false;
                _audioSource.Play();
                yield return new WaitUntil(() => (!_audioSource.isPlaying));

                _audioSource.clip = _audioTurbineContinuousReverse;
                _audioSource.loop = true;
                _audioSource.Play();
            }
            else if (_throttlePosition.PreviousPosition > ThrottlePosition.Position.Idle &&
                _throttlePosition.CurrentPosition == ThrottlePosition.Position.Idle)
            {
                _audioSource.clip = _audioTurbineDecelerate;
                _audioSource.loop = false;
                _audioSource.Play();
               // yield return new WaitUntil(() => (!_audioSource.isPlaying));
            }
            else if (_throttlePosition.PreviousPosition < ThrottlePosition.Position.Idle &&
                _throttlePosition.CurrentPosition == ThrottlePosition.Position.Idle)
            {
                _audioSource.clip = _audioTurbineDecelerateReverse;
                _audioSource.loop = false;
                _audioSource.Play();
              // yield return new WaitUntil(() => (!_audioSource.isPlaying));
            }
        }

        yield return null;
    }
}


