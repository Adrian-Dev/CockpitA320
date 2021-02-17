using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglePositions : MonoBehaviour
{
    [SerializeField] List<float> _innerTargetValues; //Excluding min and max from hinge and having values in increasing order

    public float TargetAngle { get { return _targetAngle; } }
    public int TargetRow { get { return _targetRow; } }

    private float _targetAngle;
    private int _targetRow;

    private HingeJoint _hingeJoint;

    void Awake()
    {
        _targetAngle = 0f;
        _targetRow = 0;

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
                    _targetRow = 1 ;
                }
                else
                {
                    _targetAngle = _hingeJoint.limits.min;
                    _targetRow = 0;
                }
            }
            else if (i == _innerTargetValues.Count)
            {
                float halfValue = (_innerTargetValues[i - 1] + _hingeJoint.limits.max) / 2f;

                if (angle > halfValue)
                {
                    _targetAngle = _hingeJoint.limits.max;
                    _targetRow = _innerTargetValues.Count + 1;

                }
                else
                {
                    _targetAngle = _innerTargetValues[i - 1];
                    _targetRow = _innerTargetValues.Count;
                }
            }
            else
            {
                float halfValue = (_innerTargetValues[i - 1] + _innerTargetValues[i]) / 2f;

                if (angle > halfValue)
                {
                    _targetAngle = _innerTargetValues[i];
                    _targetRow = i + 1;

                }
                else
                {
                    _targetAngle = _innerTargetValues[i - 1];
                    _targetRow = i;
                }
            }
        }
        else
        {
            float halfValue = (_hingeJoint.limits.min + _hingeJoint.limits.max) / 2f;

            if (angle > halfValue)
            {
                _targetAngle = _hingeJoint.limits.max;
                _targetRow = 1;

            }
            else
            {
                _targetAngle = _hingeJoint.limits.min;
                _targetRow = 0;
            }
        }

    }
}
