using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRudderTrimAction : MonoBehaviour
{
    [SerializeField] RudderValue _rudderValue;
    HingeJoint _hingeJoint;

    private void Awake()
    {
        _hingeJoint = GetComponent<HingeJoint>();
    }

    public void CheckAndExecRudderTrimValue()
    {
        if(Mathf.Abs(_hingeJoint.angle - _hingeJoint.limits.min) < 0.1f)
        {
            _rudderValue.IncreaseRudderLeft();
        }
        else if (Mathf.Abs(_hingeJoint.angle - _hingeJoint.limits.max) < 0.1f)
        {
            _rudderValue.IncreaseRudderRight();
        }
    }
}
