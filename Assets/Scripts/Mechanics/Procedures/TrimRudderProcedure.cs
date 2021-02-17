using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrimRudderProcedure : MonoBehaviour
{
    [SerializeField] EnableDisableComponentAction _enableDisableComponentActionMainMenu;
    [SerializeField] EnableDisableComponentAction _enableDisableComponentActionGraphicRaycast;

    [SerializeField] RudderValue _rudderValue;
    [SerializeField] Canvas _toolTipCanvas;
    [SerializeField] List<TMPro.TextMeshProUGUI> _stagesText;

    bool _procedureActive;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _procedureActive = false;
        for (int i = 0; i < _stagesText.Count; ++i)
        {
            _stagesText[i].enabled = false;
        }

        _toolTipCanvas.enabled = false;
    }

    public void StopProcedure()
    {
        StopAllCoroutines();
        Initialize();
        _enableDisableComponentActionGraphicRaycast.EnableComponent(0f);
        _enableDisableComponentActionMainMenu.EnableComponent(0f);
    }

    public void ExecuteProcedure()
    {
        if (!_procedureActive)
        {
            Initialize();
            StartCoroutine(ExecuteProcedureCoroutine());
        }
    }

    IEnumerator ExecuteProcedureCoroutine()
    {
        _procedureActive = true;

        yield return new WaitForSeconds(0.5f);
        _rudderValue.ForceTrimValue(11.2f, "R");

        _toolTipCanvas.enabled = true;
        _stagesText[0].enabled = true;
        yield return new WaitUntil(() => (_rudderValue.Value) < 0.01f); // Reset Rudder
        _stagesText[0].enabled = false;
        _toolTipCanvas.enabled = false;
        yield return new WaitForSeconds(1f);

        _toolTipCanvas.enabled = true;
        _stagesText[1].enabled = true;
        yield return new WaitUntil(() => (_rudderValue.Orientation) == "L"); // Set left trim
        yield return new WaitUntil(() => (_rudderValue.Value) > 10f);
        _stagesText[1].enabled = false;
        _toolTipCanvas.enabled = false;
        yield return new WaitForSeconds(1f);

        _toolTipCanvas.enabled = true;
        _stagesText[0].enabled = true;
        yield return new WaitUntil(() => (_rudderValue.Value) < 0.01f); // Reset Rudder
        _stagesText[0].enabled = false;
        _toolTipCanvas.enabled = false;
        yield return new WaitForSeconds(1f);

        _toolTipCanvas.enabled = true;
        _stagesText[2].enabled = true;
        yield return new WaitUntil(() => (_rudderValue.Orientation) == "R"); // Set right trim
        yield return new WaitUntil(() => (_rudderValue.Value) > 10f);
        _stagesText[2].enabled = false;
        _toolTipCanvas.enabled = false;
        yield return new WaitForSeconds(1f);

        _toolTipCanvas.enabled = true;
        _stagesText[0].enabled = true;
        yield return new WaitUntil(() => (_rudderValue.Value) < 0.01f); // Reset Rudder
        _stagesText[0].enabled = false;
        _toolTipCanvas.enabled = false;
        yield return new WaitForSeconds(1f);


        _toolTipCanvas.enabled = true;
        _stagesText[3].enabled = true;
        yield return new WaitForSeconds(3f); // Ending message
        _stagesText[3].enabled = false;
        _toolTipCanvas.enabled = false;
        yield return new WaitForSeconds(1f);

        _enableDisableComponentActionGraphicRaycast.EnableComponent(1f); // TODO refactor. This shouln't be done here I think
        _enableDisableComponentActionMainMenu.EnableComponent(1f);

        _procedureActive = false;

        yield return null;
    }
}
