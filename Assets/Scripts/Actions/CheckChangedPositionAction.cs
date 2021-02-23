using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckChangedPositionAction : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AnglePositions _anglePositions;

    public bool PositionChanged { get { return _positionChanged; } }

    int _savedPosition;
    bool _positionChanged;

    private void Awake()
    {
        _savedPosition = 0;
        _positionChanged = false;
    }

    public void SavePosition()
    {
        _positionChanged = false;
        _savedPosition = _anglePositions.TargetIndex;
    }

    public void CheckIfChanged()
    {
        if(_savedPosition != _anglePositions.TargetIndex)
        {
            _positionChanged = true;
        }
        else
        {
            _positionChanged = false;
        }
    }

    public void PlayAudioIfPositionChanged(AudioClip audioClip)
    {
        CheckIfChanged();
        if (_positionChanged)
        {
            _audioSource.clip = audioClip;
            _audioSource.Play();
        }
    }
}
