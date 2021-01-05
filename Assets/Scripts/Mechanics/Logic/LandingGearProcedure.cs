using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingGearProcedure : MonoBehaviour
{
    [SerializeField] List<MeshRenderer> _trianglesMeshRenderers;

    [SerializeField] Material _triangleON;
    [SerializeField] Material _triangleOFF;

    [SerializeField] List<TMPro.TextMeshProUGUI> _lightsUNLK;

    bool _shouldFail;
    bool _alreadyWorking;

    private void Awake()
    {
        _shouldFail = true;
        _alreadyWorking = false;
    }

    public void LandingProcedureGearUP()
    {
        if (!_alreadyWorking)
        {
            if (_shouldFail)
            {
                StartCoroutine(LandingProcedureGearUPFAILCoroutine());
            }
            else
            {
                StartCoroutine(LandingProcedureGearUPOKCoroutine());
            }
        }
    }

    public void LandingProcedureGearDOWN()
    {
        if (!_alreadyWorking)
        {
            {
                StartCoroutine(LandingProcedureGearDOWNCoroutine());
            }
        }
    }

    IEnumerator LandingProcedureGearUPFAILCoroutine()
    {
        _alreadyWorking = true;

        //Despues de subir la palanca
        float _timeBefore;

        _timeBefore = Time.unscaledTime;
        yield return new WaitUntil(() => (Time.unscaledTime - _timeBefore) > 1f);
        TurnOnUNLK();

        _timeBefore = Time.unscaledTime;
        yield return new WaitUntil(() => (Time.unscaledTime - _timeBefore) > 2f);
        TurnOffTriangles();

        _timeBefore = Time.unscaledTime;
        yield return new WaitUntil(() => (Time.unscaledTime - _timeBefore) > 2f);
        _lightsUNLK[0].color = new Color(_lightsUNLK[0].color.r, _lightsUNLK[0].color.g, _lightsUNLK[0].color.b, 0.13f);
        _lightsUNLK[1].color = new Color(_lightsUNLK[1].color.r, _lightsUNLK[1].color.g, _lightsUNLK[1].color.b, 0.13f);

        _shouldFail = false;
        _alreadyWorking = false;

        yield return null;
    }


    IEnumerator LandingProcedureGearUPOKCoroutine()
    {
        _alreadyWorking = true;

        //Despues de subir la palanca
        float _timeBefore;

        _timeBefore = Time.unscaledTime;
        yield return new WaitUntil(() => (Time.unscaledTime - _timeBefore) > 1f);
        TurnOnUNLK();

        _timeBefore = Time.unscaledTime;
        yield return new WaitUntil(() => (Time.unscaledTime - _timeBefore) > 2f);
        TurnOffTriangles();

        _timeBefore = Time.unscaledTime;
        yield return new WaitUntil(() => (Time.unscaledTime - _timeBefore) > 2f);
        TurnOffUNLK();

        _shouldFail = true;
        _alreadyWorking = false;

        yield return null;
    }

    IEnumerator LandingProcedureGearDOWNCoroutine()
    {
        _alreadyWorking = true;

        //Despues de bajar la palanca    
        float _timeBefore;

        TurnOnUNLK();

        _timeBefore = Time.unscaledTime;
        yield return new WaitUntil(() => (Time.unscaledTime - _timeBefore) > 2f);
        TurnOnTriangles();

        _timeBefore = Time.unscaledTime;
        yield return new WaitUntil(() => (Time.unscaledTime - _timeBefore) > 1f);
        TurnOffUNLK();

        _alreadyWorking = false;

        yield return null;
    }

    void TurnOnTriangles()
    {
        for (int i = 0; i < _trianglesMeshRenderers.Count; ++i)
        {
            _trianglesMeshRenderers[i].material = _triangleON;
        }
    }

    void TurnOffTriangles()
    {
        for (int i = 0; i < _trianglesMeshRenderers.Count; ++i)
        {
            _trianglesMeshRenderers[i].material = _triangleOFF;
        }
    }

    void TurnOnUNLK()
    {
        for (int i = 0; i < _lightsUNLK.Count; ++i)
        {
            _lightsUNLK[i].color = new Color(_lightsUNLK[i].color.r, _lightsUNLK[i].color.g, _lightsUNLK[i].color.b, 1f);
        }
    }

    void TurnOffUNLK()
    {
        for (int i = 0; i < _lightsUNLK.Count; ++i)
        {
            _lightsUNLK[i].color = new Color(_lightsUNLK[i].color.r, _lightsUNLK[i].color.g, _lightsUNLK[i].color.b, 0.13f);
        }
    }

    public void ShowTriangles(float waitSeconds)
    {
        StartCoroutine(ShowTrianglesCoroutine(waitSeconds));
    }

    public void HideTriangles(float waitSeconds)
    {
        StartCoroutine(HideTrianglesCoroutine(waitSeconds));
    }

    IEnumerator ShowTrianglesCoroutine(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        for (int i = 0; i < _trianglesMeshRenderers.Count; ++i)
        {
            _trianglesMeshRenderers[i].enabled = true;
        }

        yield return null;
    }

    IEnumerator HideTrianglesCoroutine(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        for (int i = 0; i < _trianglesMeshRenderers.Count; ++i)
        {
            _trianglesMeshRenderers[i].enabled = false;
        }

        yield return null;
    }
}
