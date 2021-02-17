using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsProcedure : MonoBehaviour
{
    [SerializeField] EnableDisableComponentAction _enableDisableComponentActionMainMenu;
    [SerializeField] EnableDisableComponentAction _enableDisableComponentActionGraphicRaycast;

    [SerializeField] Canvas _panelListMenu;

    [SerializeField] List<Canvas> _canvasFirstLevelList;
    [SerializeField] List<Canvas> _canvasSecondLevelList;

    bool _procedureActive;

    private void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        _panelListMenu.enabled = true;
        // TODO enable all sub canvas and raycast
        foreach (var canvas in _canvasFirstLevelList)
        {
            canvas.enabled = true;
        }
        foreach (var raycaster in _canvasFirstLevelList)
        {
            raycaster.GetComponent<UnityEngine.UI.GraphicRaycaster>().enabled = true;
        }
    }

    public void ExecuteProcedure()
    {
        if (!_procedureActive)
        {
            Initialize();
           // StartCoroutine(ExecuteProcedureCoroutine());
        }
    }

    public void StopProcedure() // TODO call this method when pressing return button (main back arrow)
    {
        StopAllCoroutines();
        //Initialize();
        _enableDisableComponentActionGraphicRaycast.EnableComponent(0f);
        _enableDisableComponentActionMainMenu.EnableComponent(0f);

        // TODO disable all sub canvas and raycast
     //   _panelListMenu.enabled = false;
        foreach (var canvas in _panelListMenu.GetComponentsInChildren<Canvas>())
        {
            canvas.enabled = false;
        }
        foreach (var raycaster in _panelListMenu.GetComponentsInChildren<UnityEngine.UI.GraphicRaycaster>())
        {
        //    raycaster.enabled = false;
        }
    }


    IEnumerator ExecuteProcedureCoroutine()
    {
        _procedureActive = true;
      
        // Wait until not finished
        _enableDisableComponentActionGraphicRaycast.EnableComponent(1f);
        _enableDisableComponentActionMainMenu.EnableComponent(1f);

        yield return new WaitForSeconds(1f);

        _procedureActive = false;

        yield return null;
    }
}
