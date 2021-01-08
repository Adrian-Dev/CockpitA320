using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsProcedure : MonoBehaviour
{
    [SerializeField] EnableDisableComponentAction _enableDisableComponentActionMainMenu;
    [SerializeField] EnableDisableComponentAction _enableDisableComponentActionGraphicRaycast;

    [SerializeField] GameObject _stickLeftOutline;
    [SerializeField] GameObject _throttleOutline;
    [SerializeField] GameObject _brakeOutline;
    [SerializeField] GameObject _FLAPSOutline;
    [SerializeField] GameObject _knobOutline;
    [SerializeField] GameObject _resetButtonOutline;
    [SerializeField] GameObject _landingGearOutline;
    [SerializeField] GameObject _lightEmergencyOutline;
    [SerializeField] GameObject _lightNoSmockingOutline;
    [SerializeField] GameObject _lightSeatBeltsOutline;
    [SerializeField] GameObject _coverOutline;

    [SerializeField] Interactable _stickLeftInteractable;
    [SerializeField] Interactable _throttleInteractable;
    [SerializeField] Interactable _brakeInteractable;
    [SerializeField] Interactable _FLAPSInteractable;
    [SerializeField] Interactable _knobInteractable;
    [SerializeField] Interactable _resetButtonInteractable;
    [SerializeField] Interactable _landingGearInteractable;
    [SerializeField] Interactable _lightEmergencyInteractable;
    [SerializeField] Interactable _lightNoSmockingInteractable;
    [SerializeField] Interactable _lightSeatBeltsInteractable;
    [SerializeField] Interactable _coverInteractable;
    [SerializeField] Interactable _maskButtonInteractable;

    bool _procedureStarted;

    private void Awake()
    {
        _procedureStarted = false;

        _stickLeftOutline.SetActive(false);
        _throttleOutline.SetActive(false);
        _brakeOutline.SetActive(false);
        _FLAPSOutline.SetActive(false);
        _knobOutline.SetActive(false);
        _resetButtonOutline.SetActive(false);
        _landingGearOutline.SetActive(false);
        _lightEmergencyOutline.SetActive(false);
        _lightNoSmockingOutline.SetActive(false);
        _lightSeatBeltsOutline.SetActive(false);
        _coverOutline.SetActive(false);

        _stickLeftInteractable.Restore();
        _throttleInteractable.Restore();
        _brakeInteractable.Restore();
        _FLAPSInteractable.Restore();
        _knobInteractable.Restore();
        _resetButtonInteractable.Restore();
        _landingGearInteractable.Restore();
        _lightEmergencyInteractable.Restore();
        _lightNoSmockingInteractable.Restore();
        _lightSeatBeltsInteractable.Restore();
        _coverInteractable.Restore();
        _maskButtonInteractable.Restore();
    }

    public void ExecuteProcedure()
    {
        if (!_procedureStarted)
        {
            _procedureStarted = true;
            StartCoroutine(ExecuteProcedureCoroutine());
        }
    }

    IEnumerator ExecuteProcedureCoroutine()
    {
        _stickLeftOutline.SetActive(true);
        _stickLeftInteractable.Activate();
        yield return new WaitUntil(() => _stickLeftInteractable.Triggered);


        _enableDisableComponentActionGraphicRaycast.EnableComponent(1f);
        _enableDisableComponentActionMainMenu.EnableComponent(1f);

        yield return null;
    }
}
