using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableComponentAction : MonoBehaviour
{
    public Component _component;

    public void EnableComponent(float waitSeconds)
    {
         StopAllCoroutines();
        if (_component)
        {
            StartCoroutine(EnableComponentCoroutine(waitSeconds));
        }
    }

    public void DisableComponent(float waitSeconds)
    {
        StopAllCoroutines();
        if (_component)
        {
            StartCoroutine(DisableComponentCoroutine(waitSeconds));
        }
    }

    public void EnableComponentNoForceStop(float waitSeconds)
    {
        if (_component)
        {
            StartCoroutine(EnableComponentCoroutine(waitSeconds));
        }
    }

    public void DisableComponentNoForceStop(float waitSeconds)
    {
        if (_component)
        {
            StartCoroutine(DisableComponentCoroutine(waitSeconds));
        }
    }

    IEnumerator EnableComponentCoroutine(float waitSeconds)
    {
        System.Type type = _component.GetType();
        var propertyEnabled = type.GetProperty("enabled");
        if (propertyEnabled != null)
        {
            yield return new WaitForSeconds(waitSeconds);
            propertyEnabled.SetValue(_component, true);
        }
        else
        {
            Debug.Log("It seems '" + _component + "' does not have 'enabled' property.");
        }
        yield return null;
    }

    IEnumerator DisableComponentCoroutine(float waitSeconds)
    {
        System.Type type = _component.GetType();
        var propertyEnabled = type.GetProperty("enabled");
        if (propertyEnabled != null)
        {
            yield return new WaitForSeconds(waitSeconds);
            propertyEnabled.SetValue(_component, false);
        }
        else
        {
            Debug.Log("It seems '" + _component + "' does not have 'enabled' property.");
        }
        yield return null;
    }
}
