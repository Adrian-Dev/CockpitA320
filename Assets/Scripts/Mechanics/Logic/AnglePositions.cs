using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglePositions : MonoBehaviour
{
    [SerializeField] List<float> _innerTargetValues; //Excluding min and max from hinge and having values in increasing order

    public float TargetAngle { get { return _targetAngle; } }
    public int TargetIndex { get { return _targetIndex; } }

    private float _targetAngle;
    private int _targetIndex;

    private HingeJoint _hingeJoint;

    void Awake()
    {
        _targetAngle = 0f;
        _targetIndex = 0;

        _hingeJoint = GetComponent<HingeJoint>();
    }

    public void UpdateTargetAngle()
    {
        float angle = _hingeJoint.angle;

        if (_innerTargetValues.Count > 0) 
        {
            int i = 0;

            while (i < _innerTargetValues.Count && angle > _innerTargetValues[i])
            {
                ++i;
            }

            if (i == 0)
            {
                float halfValue = (_hingeJoint.limits.min + _innerTargetValues[i]) / 2f;
                if(angle > halfValue)
                {
                    _targetAngle = _innerTargetValues[i];
                    _targetIndex = 1 ;
                }
                else
                {
                    _targetAngle = _hingeJoint.limits.min;
                    _targetIndex = 0;
                }
            }
            else if (i == _innerTargetValues.Count)
            {
                float halfValue = (_innerTargetValues[i - 1] + _hingeJoint.limits.max) / 2f;

                if (angle > halfValue)
                {
                    _targetAngle = _hingeJoint.limits.max;
                    _targetIndex = _innerTargetValues.Count + 1;

                }
                else
                {
                    _targetAngle = _innerTargetValues[i - 1];
                    _targetIndex = _innerTargetValues.Count;
                }
            }
            else
            {
                float halfValue = (_innerTargetValues[i - 1] + _innerTargetValues[i]) / 2f;

                if (angle > halfValue)
                {
                    _targetAngle = _innerTargetValues[i];
                    _targetIndex = i + 1;

                }
                else
                {
                    _targetAngle = _innerTargetValues[i - 1];
                    _targetIndex = i;
                }
            }
        }
        else
        {
            float halfValue = (_hingeJoint.limits.min + _hingeJoint.limits.max) / 2f;

            if (angle > halfValue)
            {
                _targetAngle = _hingeJoint.limits.max;
                _targetIndex = 1;

            }
            else
            {
                _targetAngle = _hingeJoint.limits.min;
                _targetIndex = 0;
            }
        }

    }
}
