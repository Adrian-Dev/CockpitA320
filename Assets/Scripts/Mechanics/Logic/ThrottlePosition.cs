using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrottlePosition : MonoBehaviour
{
    AnglePositions _anglePositions;

    BNG.Lever _lever;
    bool _alreadyWaiting;
    public enum Position
    {
        MaxReverse = 0,
        Idle = 1,
        MaxClimb = 2,
        MaxContinuous = 3,
        MaxTakeOff = 4
    }
    public Position CurrentPosition { get { return _currentPosition; } }
    public Position PreviousPosition { get { return _previousPosition; } }

    Position _currentPosition;
    Position _previousPosition;

    private void Awake()
    {
        _currentPosition = Position.Idle;
        _previousPosition = Position.Idle;

        _anglePositions = GetComponent<AnglePositions>();
        _lever = GetComponent<BNG.Lever>();
        _alreadyWaiting = false;
    }

    public void UpdatePosition()
    {
        _currentPosition = (Position)_anglePositions.TargetIndex;
    }

    public void SavePosition()
    {
        _previousPosition = (Position)_anglePositions.TargetIndex;
    }

    public void WaitCanBeGrabbed(float value)
    {
        if (!_alreadyWaiting)
        {
            StartCoroutine(SetCanBeGrabbedCoroutine(value));
        }
    }

    IEnumerator SetCanBeGrabbedCoroutine(float value)
    {
        _alreadyWaiting = true;

        float timeBefore = Time.unscaledTime;

        while((Time.unscaledTime - timeBefore) < value)
        {
            _lever.enabled = false;
            yield return new WaitForEndOfFrame();
        }

        _alreadyWaiting = false;

        yield return null;
    }


}
