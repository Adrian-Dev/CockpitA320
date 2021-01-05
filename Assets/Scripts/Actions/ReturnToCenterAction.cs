using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToCenterAction : MonoBehaviour
{
    [SerializeField] float _returnLookSpeed = 5f;

    private HingeJoint _hingeJoint;
    private bool _isMoving;
    void Awake()
    {
        _hingeJoint = GetComponent<HingeJoint>();
        _isMoving = false;
    }

    public void MoveToCenter()
    {
        StartCoroutine(MoveToCenterCoroutine());
    }

    IEnumerator MoveToCenterCoroutine()
    {
        if (!_isMoving)
        {
            _isMoving = true;
            while (Mathf.Abs(_hingeJoint.angle) > 1f)
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, Time.deltaTime * _returnLookSpeed);
                yield return new WaitForEndOfFrame();
            }
            _isMoving = false;
        }

        yield return null;
    }
}


