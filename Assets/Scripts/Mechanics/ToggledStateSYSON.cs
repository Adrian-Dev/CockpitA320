using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggledStateSYSON : MonoBehaviour
{
    [SerializeField] bool _isToggledON = false;
    [SerializeField] Renderer _targetRenderer;
    [SerializeField] Material _materialON;
    [SerializeField] Material _materialOFF;

    private void Start()
    {
        ToggleMaterial();
    }

    public void ToggleState()
    {
        _isToggledON = !_isToggledON;
        ToggleMaterial();
    }

    public void ToggleState(bool value)
    {
        _isToggledON = value;
        ToggleMaterial();
    }

    void ToggleMaterial()
    {
        if (_isToggledON)
        {
            _targetRenderer.material = _materialON;
        }
        else
        {
            _targetRenderer.material = _materialOFF;
        }
    }
}
