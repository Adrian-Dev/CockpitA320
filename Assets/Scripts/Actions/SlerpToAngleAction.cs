using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlerpToAngleAction : MonoBehaviour
{
    public float ReturnLookSpeed { get { return _returnLookSpeed; } }
    [SerializeField] float _returnLookSpeed = 30f;

    AnglePositions _anglePositions;
    private HingeJoint _hingeJoint;
    private bool _isMoving;

    void Awake()
    {
        _anglePositions = GetComponent<AnglePositions>();
        _hingeJoint = GetComponent<HingeJoint>();
        _isMoving = false;
    }


    public void MoveToAngle()
    {        
       StartCoroutine(MoveToTargetCoroutine(_anglePositions.TargetAngle));
    }

    IEnumerator MoveToTargetCoroutine(float targetValue)
    {
        if (!_isMoving)
        {
            _isMoving = true;
            while (Mathf.Abs(_hingeJoint.angle - targetValue) > 1f)
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(targetValue, transform.localRotation.y, transform.localRotation.z), Time.deltaTime * _returnLookSpeed);
                yield return new WaitForEndOfFrame();
            }
            _isMoving = false;
        }

        yield return null;
    }
}
