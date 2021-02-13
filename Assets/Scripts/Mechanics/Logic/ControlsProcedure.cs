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
    [SerializeField] GameObject _maskButtonOutline;

    [SerializeField] Canvas _stickLeftMenu;
    [SerializeField] Canvas _throttleMenu;
    [SerializeField] Canvas _brakeMenu;
    [SerializeField] Canvas _FLAPSMenu;
    [SerializeField] Canvas _knobMenu;
    [SerializeField] Canvas _resetButtonMenu;
    [SerializeField] Canvas _landingGearMenu;
    [SerializeField] Canvas _lightSIGNSMenu;
    [SerializeField] Canvas _coverMenu;

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

    bool _procedureActive;
    bool _waitForInteraction;

    private void Awake()
    {
        InitInteractables();
    }

    void InitInteractables()
    {
        _procedureActive = false;
        _waitForInteraction = false;

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
        _maskButtonOutline.SetActive(false);

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
        if (!_procedureActive)
        {
            InitInteractables();
            StartCoroutine(ExecuteProcedureCoroutine());
        }
    }


    IEnumerator WaitForInteractionElementCoroutine(Interactable interactable, GameObject outlineObject, Canvas menuObject)
    {
        outlineObject.SetActive(true);
        interactable.Activate();
        menuObject.enabled = true;
        yield return new WaitUntil(() => interactable.Grabbed);
        outlineObject.SetActive(false);
        yield return new WaitUntil(() => interactable.Triggered);
        interactable.Deactivate();
        _waitForInteraction = false;
        yield return null;
    }

    IEnumerator ExecuteProcedureCoroutine()
    {
        _procedureActive = true;

        _waitForInteraction = true;
        StartCoroutine(WaitForInteractionElementCoroutine(_stickLeftInteractable, _stickLeftOutline, _stickLeftMenu));
        yield return new WaitUntil(() => !_waitForInteraction);

        _waitForInteraction = true;
        StartCoroutine(WaitForInteractionElementCoroutine(_throttleInteractable, _throttleOutline, _throttleMenu));
        yield return new WaitUntil(() => !_waitForInteraction);

        _waitForInteraction = true;
        StartCoroutine(WaitForInteractionElementCoroutine(_brakeInteractable, _brakeOutline, _brakeMenu));
        yield return new WaitUntil(() => !_waitForInteraction);

        _waitForInteraction = true;
        StartCoroutine(WaitForInteractionElementCoroutine(_FLAPSInteractable, _FLAPSOutline, _FLAPSMenu));
        yield return new WaitUntil(() => !_waitForInteraction);

        _waitForInteraction = true;
        StartCoroutine(WaitForInteractionElementCoroutine(_knobInteractable, _knobOutline, _knobMenu));
        yield return new WaitUntil(() => !_waitForInteraction);

        _waitForInteraction = true;
        StartCoroutine(WaitForInteractionElementCoroutine(_resetButtonInteractable, _resetButtonOutline, _resetButtonMenu));
        yield return new WaitUntil(() => !_waitForInteraction);

        _waitForInteraction = true;
        StartCoroutine(WaitForInteractionElementCoroutine(_landingGearInteractable, _landingGearOutline, _landingGearMenu));
        yield return new WaitUntil(() => !_waitForInteraction);

        _waitForInteraction = true;
        StartCoroutine(WaitForInteractionElementCoroutine(_lightSeatBeltsInteractable, _lightSeatBeltsOutline, _lightSIGNSMenu));
        yield return new WaitUntil(() => !_waitForInteraction);

        _waitForInteraction = true;
        StartCoroutine(WaitForInteractionElementCoroutine(_lightNoSmockingInteractable, _lightNoSmockingOutline, _lightSIGNSMenu));
        yield return new WaitUntil(() => !_waitForInteraction);

        _waitForInteraction = true;
        StartCoroutine(WaitForInteractionElementCoroutine(_lightEmergencyInteractable, _lightEmergencyOutline, _lightSIGNSMenu));
        yield return new WaitUntil(() => !_waitForInteraction);

        _waitForInteraction = true;
        StartCoroutine(WaitForInteractionElementCoroutine(_coverInteractable, _coverOutline, _coverMenu));
        yield return new WaitUntil(() => !_waitForInteraction);

        _waitForInteraction = true;
        StartCoroutine(WaitForInteractionElementCoroutine(_maskButtonInteractable, _maskButtonOutline, _coverMenu));
        yield return new WaitUntil(() => !_waitForInteraction);


        _enableDisableComponentActionGraphicRaycast.EnableComponent(1f);
        _enableDisableComponentActionMainMenu.EnableComponent(1f);

        yield return new WaitForSeconds(1f);

        _procedureActive = false;

        yield return null;
    }
}
