using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableKinematicRigidbodyAction : MonoBehaviour
{
    public Rigidbody _rigidbody;

    public void ActivateKinematicRigidBody(bool active)
    {
        _rigidbody.isKinematic = active;
    }
}
