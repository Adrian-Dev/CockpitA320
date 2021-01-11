using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateColliderDependingLeverAction : MonoBehaviour
{
    [SerializeField] Collider _boxCollider;

    private BNG.Lever _lever;

    private void Awake()
    {
        _lever = GetComponent<BNG.Lever>();
    }

    public void UpdateButtonBoxCollider(float waitSeconds)
    {
        StartCoroutine(UpdateButtonBoxColliderCoroutine(waitSeconds));
    }

    IEnumerator UpdateButtonBoxColliderCoroutine(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);

        if (_lever.LeverPercentage > 45f)
        {
            _boxCollider.enabled = true;
        }
        yield return null;
    }
}
