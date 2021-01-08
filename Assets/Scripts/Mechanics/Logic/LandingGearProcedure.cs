using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingGearProcedure : MonoBehaviour
{
    [SerializeField] EnableDisableComponentAction _enableDisableComponentActionMainMenu;
    [SerializeField] EnableDisableComponentAction _enableDisableComponentActionGraphicRaycast;

    [SerializeField] LandingGearMechanic _landingGearMechanic;
    [SerializeField] Canvas _toolTipCanvas;
    [SerializeField] List<TMPro.TextMeshProUGUI> _stagesText;

    bool _procedureFinished;

    private void Awake()
    {
        _procedureFinished = false;

        for (int i = 0; i < _stagesText.Count; ++i)
        {
            _stagesText[i].enabled = false;
        }

        _toolTipCanvas.enabled = false;
    }

    public void ExecuteProcedure()
    {
        if (!_procedureFinished)
        {
            _procedureFinished = true;
            StartCoroutine(ExecuteProcedureCoroutine());
        }
    }

    IEnumerator ExecuteProcedureCoroutine()
    {
        //_toolTipCanvas.enabled = true;
        _stagesText[0].enabled = true;
        yield return new WaitUntil(() => _landingGearMechanic.CurrentStage == LandingGearMechanic.Stage.UPFAIL);
        _stagesText[0].enabled = false;
        //_toolTipCanvas.enabled = false;
        yield return new WaitForSeconds(2f);

        _toolTipCanvas.enabled = true;
        _stagesText[1].enabled = true;
        yield return new WaitUntil(() => _landingGearMechanic.CurrentStage == LandingGearMechanic.Stage.DOWN);
        _stagesText[1].enabled = false;
        //_toolTipCanvas.enabled = false;
        yield return new WaitForSeconds(2f);

        _toolTipCanvas.enabled = true;
        _stagesText[2].enabled = true;
        yield return new WaitUntil(() => _landingGearMechanic.CurrentStage == LandingGearMechanic.Stage.UPOK);
        _stagesText[2].enabled = false;
        //_toolTipCanvas.enabled = false;
        yield return new WaitForSeconds(2f);

        _toolTipCanvas.enabled = true;
        _stagesText[3].enabled = true;
        yield return new WaitForSeconds(2f);
        _stagesText[3].enabled = false;
        //_toolTipCanvas.enabled = false;

        _toolTipCanvas.enabled = false;

        _enableDisableComponentActionGraphicRaycast.EnableComponent(1f);
        _enableDisableComponentActionMainMenu.EnableComponent(1f);

        yield return null;
    }
}
