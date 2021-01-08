using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableGameObjectAction : MonoBehaviour
{
    public void EnableGameObject(float waitSeconds)
    {
        StopAllCoroutines();
        StartCoroutine(EnableGameObjectCoroutine(waitSeconds));
    }

    public void DisableGameObject(float waitSeconds)
    {
        StopAllCoroutines();
        StartCoroutine(DisableGameObjectCoroutine(waitSeconds));
    }

    public void EnableGameObjectNoForceStop(float waitSeconds)
    {
        StartCoroutine(EnableGameObjectCoroutine(waitSeconds));
    }

    public void DisableGameObjectNoForceStop(float waitSeconds)
    {
        StartCoroutine(DisableGameObjectCoroutine(waitSeconds));
    }

    IEnumerator EnableGameObjectCoroutine(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        gameObject.SetActive(true);

        yield return null;
    }

    IEnumerator DisableGameObjectCoroutine(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        gameObject.SetActive(false);

        yield return null;
    }
}
