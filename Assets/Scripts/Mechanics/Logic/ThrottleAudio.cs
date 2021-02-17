using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrottleAudio : MonoBehaviour
{
    [SerializeField] AudioClip _audioAccelerationFromIdleToClimb;
    [SerializeField] AudioClip _audioAccelerationClimbConstante;
    [SerializeField] AudioClip _audioDecelerationFromClimbToIdle;
    [SerializeField] AudioClip _audioAccelerationFromClimbToMaxCont;
    [SerializeField] AudioClip _audioAccelerationMaxContConstante;
    [SerializeField] AudioClip _audioDecelerationFromMaxContToClimb;
    [SerializeField] AudioClip _audioAccelerationFromMaxContToMaxTO;
    [SerializeField] AudioClip _audioAccelerationMaxTOConstante;
    [SerializeField] AudioClip _audioDecelerationFromMaxTOToMaxCont;
    [SerializeField] AudioClip _audioAccelerationFromIdleToMaxReverse;
    [SerializeField] AudioClip _audioAccelerationMaxReverseConstante;
    [SerializeField] AudioClip _audioDecelerationFromMaxReverseToIdle;

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
            if (_throttlePosition.CurrentPosition == ThrottlePosition.Position.MaxClimb &&
                _throttlePosition.PreviousPosition == ThrottlePosition.Position.Idle) 
            {
                _audioSource.clip = _audioAccelerationFromIdleToClimb;
                _audioSource.loop = false;
                _audioSource.Play();
                yield return new WaitUntil(() => (!_audioSource.isPlaying));

                _audioSource.clip = _audioAccelerationClimbConstante;
                _audioSource.loop = true;
                _audioSource.Play();
            }
            else if (_throttlePosition.CurrentPosition == ThrottlePosition.Position.MaxContinuous &&
                _throttlePosition.PreviousPosition == ThrottlePosition.Position.MaxClimb)
            {
                _audioSource.clip = _audioAccelerationFromClimbToMaxCont;
                _audioSource.loop = false;
                _audioSource.Play();
                yield return new WaitUntil(() => (!_audioSource.isPlaying));

                _audioSource.clip = _audioAccelerationMaxContConstante;
                _audioSource.loop = true;
                _audioSource.Play();
            }
            else if (_throttlePosition.CurrentPosition == ThrottlePosition.Position.MaxTakeOff &&
                    _throttlePosition.PreviousPosition == ThrottlePosition.Position.MaxContinuous)
            {
                _audioSource.clip = _audioAccelerationFromMaxContToMaxTO;
                _audioSource.loop = false;
                _audioSource.Play();
                yield return new WaitUntil(() => (!_audioSource.isPlaying));

                _audioSource.clip = _audioAccelerationMaxTOConstante;
                _audioSource.loop = true;
                _audioSource.Play();
            }
            else if (_throttlePosition.CurrentPosition == ThrottlePosition.Position.MaxContinuous &&
                _throttlePosition.PreviousPosition == ThrottlePosition.Position.MaxTakeOff)
            {
                _audioSource.clip = _audioDecelerationFromMaxTOToMaxCont;
                _audioSource.loop = false;
                _audioSource.Play();
                yield return new WaitUntil(() => (!_audioSource.isPlaying));

                _audioSource.clip = _audioAccelerationMaxContConstante;
                _audioSource.loop = true;
                _audioSource.Play();
            }
            else if (_throttlePosition.CurrentPosition == ThrottlePosition.Position.MaxClimb &&
                _throttlePosition.PreviousPosition == ThrottlePosition.Position.MaxContinuous)
            {
                _audioSource.clip = _audioDecelerationFromMaxContToClimb;
                _audioSource.loop = false;
                _audioSource.Play();
                yield return new WaitUntil(() => (!_audioSource.isPlaying));

                _audioSource.clip = _audioAccelerationClimbConstante;
                _audioSource.loop = true;
                _audioSource.Play();
            }
            else if (_throttlePosition.CurrentPosition == ThrottlePosition.Position.Idle &&
                _throttlePosition.PreviousPosition == ThrottlePosition.Position.MaxClimb)
            {
                _audioSource.clip = _audioDecelerationFromClimbToIdle;
                _audioSource.loop = false;
                _audioSource.Play();
            }
            else if (_throttlePosition.CurrentPosition == ThrottlePosition.Position.MaxReverse &&
                _throttlePosition.PreviousPosition == ThrottlePosition.Position.Idle)
            {
                _audioSource.clip = _audioAccelerationFromIdleToMaxReverse;
                _audioSource.loop = false;
                _audioSource.Play();
                yield return new WaitUntil(() => (!_audioSource.isPlaying));

                _audioSource.clip = _audioAccelerationMaxReverseConstante;
                _audioSource.loop = true;
                _audioSource.Play();
            }
            else if (_throttlePosition.CurrentPosition == ThrottlePosition.Position.Idle &&
                _throttlePosition.PreviousPosition == ThrottlePosition.Position.MaxReverse)
            {
                _audioSource.clip = _audioDecelerationFromMaxReverseToIdle;
                _audioSource.loop = false;
                _audioSource.Play();
            }

        }

        yield return null;
    }
}


