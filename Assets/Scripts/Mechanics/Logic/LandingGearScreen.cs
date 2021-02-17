using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingGearScreen : MonoBehaviour
{
    [SerializeField] Material _triangleON;
    [SerializeField] Material _triangleOFF;

    [SerializeField] List<MeshRenderer> _trianglesMeshRenderers;
    [SerializeField] List<TMPro.TextMeshProUGUI> _lightsUNLK;

    bool _alreadyWorking;

    private void Awake()
    {
        _alreadyWorking = false;
    }

    public void TurnOnTriangles()
    {
        for (int i = 0; i < _trianglesMeshRenderers.Count; ++i)
        {
            _trianglesMeshRenderers[i].material = _triangleON;
        }
    }

    public void TurnOffTriangles()
    {
        for (int i = 0; i < _trianglesMeshRenderers.Count; ++i)
        {
            _trianglesMeshRenderers[i].material = _triangleOFF;
        }
    }

    public void TurnOnUNLK()
    {
        for (int i = 0; i < _lightsUNLK.Count; ++i)
        {
            _lightsUNLK[i].color = new Color(_lightsUNLK[i].color.r, _lightsUNLK[i].color.g, _lightsUNLK[i].color.b, 1f);
        }
    }

    public void TurnOffUNLK()
    {
        for (int i = 0; i < _lightsUNLK.Count; ++i)
        {
            _lightsUNLK[i].color = new Color(_lightsUNLK[i].color.r, _lightsUNLK[i].color.g, _lightsUNLK[i].color.b, 0.13f);
        }
    }

    public void TurnOffUNLK(int index)
    {
        _lightsUNLK[index].color = new Color(_lightsUNLK[index].color.r, _lightsUNLK[index].color.g, _lightsUNLK[index].color.b, 0.13f);
    }

    public void ShowTriangles()
    {
        for (int i = 0; i < _trianglesMeshRenderers.Count; ++i)
        {
            _trianglesMeshRenderers[i].enabled = true;
        }
    }

    public void ShowTriangles(float waitSeconds)
    {
        if (!_alreadyWorking)
        {
            StartCoroutine(ShowTrianglesCoroutine(waitSeconds));
        }
    }

    public void HideTriangles()
    {
        for (int i = 0; i < _trianglesMeshRenderers.Count; ++i)
        {
            _trianglesMeshRenderers[i].enabled = false;
        }
    }

    public void HideTriangles(float waitSeconds)
    {
        if (!_alreadyWorking)
        {
            StartCoroutine(HideTrianglesCoroutine(waitSeconds));
        }
    }

    IEnumerator ShowTrianglesCoroutine(float waitSeconds)
    {
        _alreadyWorking = true;

        yield return new WaitForSeconds(waitSeconds);
        for (int i = 0; i < _trianglesMeshRenderers.Count; ++i)
        {
            _trianglesMeshRenderers[i].enabled = true;
        }
        _alreadyWorking = false;

        yield return null;
    }

    IEnumerator HideTrianglesCoroutine(float waitSeconds)
    {
        _alreadyWorking = true;

        yield return new WaitForSeconds(waitSeconds);
        for (int i = 0; i < _trianglesMeshRenderers.Count; ++i)
        {
            _trianglesMeshRenderers[i].enabled = false;
        }
        _alreadyWorking = false;

        yield return null;
    }
}
