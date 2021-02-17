using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingGearProcedure : MonoBehaviour
{
    [SerializeField] EnableDisableComponentAction _enableDisableComponentActionMainMenu;
    [SerializeField] EnableDisableComponentAction _enableDisableComponentActionGraphicRaycast;

    [SerializeField] LandingGearScreen _landingGearScreen;
    [SerializeField] LandingGearScreen _landingGearScreenZoomedIN;

    [SerializeField] Canvas _toolTipCanvas;
    [SerializeField] List<TMPro.TextMeshProUGUI> _stagesText;

    bool _procedureActive;
    bool _shouldFail;
    bool _alreadyWorking;

    public enum Stage
    {
        DOWN,
        UPFAIL,
        UPOK
    }

    public Stage CurrentStage { get { return _currentStage; } }
    Stage _currentStage;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _alreadyWorking = false;
        _procedureActive = false;

        _shouldFail = true;
        _currentStage = Stage.DOWN;

        for (int i = 0; i < _stagesText.Count; ++i)
        {
            _stagesText[i].enabled = false;
        }

        _toolTipCanvas.enabled = false;

        _landingGearScreenZoomedIN.GetComponent<EnableDisableComponentAction>().DisableComponent(0f);
        _landingGearScreenZoomedIN.HideTriangles();
    }

    public void ExecuteProcedure()
    {
        if (!_procedureActive)
        {
            Initialize();
            StartCoroutine(ExecuteProcedureCoroutine());
        }
    }

    public void StopProcedure()
    {
        StopAllCoroutines();
        Initialize();
        _enableDisableComponentActionGraphicRaycast.EnableComponent(0f);
        _enableDisableComponentActionMainMenu.EnableComponent(0f);
    }

    public void LandingGearProcedureUP()
    {
        if (!_alreadyWorking && _procedureActive)
        {
            if (_shouldFail)
            {
                StartCoroutine(LandingGearProcedureUPFAILCoroutine());
            }
            else
            {
                StartCoroutine(LandingGearProcedureUPOKCoroutine());
            }
        }
    }

    public void LandingGearProcedureDOWN()
    {
        if (!_alreadyWorking && _procedureActive)
        {
            StartCoroutine(LandingGearProcedureDOWNCoroutine());
        }
    }

    IEnumerator ExecuteProcedureCoroutine()
    {
        _procedureActive = true;

        _landingGearScreen.TurnOffUNLK();
        _landingGearScreenZoomedIN.TurnOffUNLK();
        _landingGearScreen.TurnOnTriangles();
        _landingGearScreenZoomedIN.TurnOnTriangles();

        //_toolTipCanvas.enabled = true; // TODO refactor toolTips
        _stagesText[0].enabled = true;
        yield return new WaitUntil(() => CurrentStage == Stage.UPFAIL);
        _stagesText[0].enabled = false;
        //_toolTipCanvas.enabled = false;
        yield return new WaitForSeconds(2f);

        _toolTipCanvas.enabled = true;
        _stagesText[1].enabled = true;
        yield return new WaitUntil(() => CurrentStage == Stage.DOWN);
        _stagesText[1].enabled = false;
        //_toolTipCanvas.enabled = false;
        yield return new WaitForSeconds(2f);

        _toolTipCanvas.enabled = true;
        _stagesText[2].enabled = true;
        yield return new WaitUntil(() => CurrentStage == Stage.UPOK);
        _stagesText[2].enabled = false;


        //_toolTipCanvas.enabled = false;
        yield return new WaitForSeconds(2f);

        _toolTipCanvas.enabled = true;
        _stagesText[3].enabled = true;
        yield return new WaitForSeconds(4f);
        _stagesText[3].enabled = false;
        //_toolTipCanvas.enabled = false;

        _toolTipCanvas.enabled = false;

        _enableDisableComponentActionGraphicRaycast.EnableComponent(1f);
        _enableDisableComponentActionMainMenu.EnableComponent(1f);

        _procedureActive = false;


        yield return null;
    }

    IEnumerator LandingGearProcedureUPFAILCoroutine()
    {
        _alreadyWorking = true;

        //After placing the lever down    
        float _timeBefore;

        _timeBefore = Time.unscaledTime;
        yield return new WaitUntil(() => (Time.unscaledTime - _timeBefore) > 1f);
        _landingGearScreen.TurnOnUNLK();
        _landingGearScreenZoomedIN.TurnOnUNLK();

        _timeBefore = Time.unscaledTime;
        yield return new WaitUntil(() => (Time.unscaledTime - _timeBefore) > 2f);
        _landingGearScreen.TurnOffTriangles();
        _landingGearScreenZoomedIN.TurnOffTriangles();

        _timeBefore = Time.unscaledTime;
        yield return new WaitUntil(() => (Time.unscaledTime - _timeBefore) > 2f);
        _landingGearScreen.TurnOffUNLK(0);
        _landingGearScreenZoomedIN.TurnOffUNLK(0);
        _landingGearScreen.TurnOffUNLK(1);
        _landingGearScreenZoomedIN.TurnOffUNLK(1);

        _shouldFail = false;

        _currentStage = Stage.UPFAIL;

        _alreadyWorking = false;

        yield return null;
    }

    IEnumerator LandingGearProcedureUPOKCoroutine()
    {
        _alreadyWorking = true;

        //After placing the lever up  
        float _timeBefore;

        _timeBefore = Time.unscaledTime;
        yield return new WaitUntil(() => (Time.unscaledTime - _timeBefore) > 1f);
        _landingGearScreen.TurnOnUNLK();
        _landingGearScreenZoomedIN.TurnOnUNLK();

        _timeBefore = Time.unscaledTime;
        yield return new WaitUntil(() => (Time.unscaledTime - _timeBefore) > 2f);
        _landingGearScreen.TurnOffTriangles();
        _landingGearScreenZoomedIN.TurnOffTriangles();

        _timeBefore = Time.unscaledTime;
        yield return new WaitUntil(() => (Time.unscaledTime - _timeBefore) > 2f);
        _landingGearScreen.TurnOffUNLK();
        _landingGearScreenZoomedIN.TurnOffUNLK();

        _shouldFail = true;

        _currentStage = Stage.UPOK;

        _alreadyWorking = false;

        yield return null;
    }

    IEnumerator LandingGearProcedureDOWNCoroutine()
    {
        _alreadyWorking = true;

        //After placing the lever down    
        float _timeBefore;

        _landingGearScreen.TurnOnUNLK();
        _landingGearScreenZoomedIN.TurnOnUNLK();

        _timeBefore = Time.unscaledTime;
        yield return new WaitUntil(() => (Time.unscaledTime - _timeBefore) > 2f);
        _landingGearScreen.TurnOnTriangles();
        _landingGearScreenZoomedIN.TurnOnTriangles();

        _timeBefore = Time.unscaledTime;
        yield return new WaitUntil(() => (Time.unscaledTime - _timeBefore) > 1f);
        _landingGearScreen.TurnOffUNLK();
        _landingGearScreenZoomedIN.TurnOffUNLK();

        _currentStage = Stage.DOWN;

        _alreadyWorking = false;

        yield return null;
    }

    public void ShowHideScreenZoomedIN(bool value) // Not best solution design. Refactor when possible
    {
        if (_procedureActive)
        {
            if (value)
            {
                _landingGearScreenZoomedIN.GetComponent<EnableDisableComponentAction>().EnableComponent(0f);
                _landingGearScreenZoomedIN.ShowTriangles(0f);
            }
            else
            {
                _landingGearScreenZoomedIN.GetComponent<EnableDisableComponentAction>().DisableComponent(6.5f);
                _landingGearScreenZoomedIN.HideTriangles(6.5f);
            }
        }
    }
}
