using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppController : MonoBehaviour
{
    [SerializeField] BNG.InputBridge _inputBridge;
    [SerializeField] Canvas _menu;

    [SerializeField] PanelsProcedure _panelsProcedure;
    [SerializeField] ControlsProcedure _controlsProcedure;
    [SerializeField] TrimRudderProcedure _trimRudderProcedure;
    [SerializeField] LandingGearProcedure _landingGearProcedure;

    public void ShowHideMenu(bool value)
    {
        if (value)
        {
            _menu.enabled = true;
        }
        else
        {
            _menu.enabled = false;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void Update()
    {
        bool endSequence = _inputBridge.BackButtonDown;
        if (endSequence)
        {
            _menu.enabled = true;
            // TODO Better stop only current active procedure
            _panelsProcedure.StopProcedure();
            _controlsProcedure.StopProcedure();
            _trimRudderProcedure.StopProcedure();
            _landingGearProcedure.StopProcedure();
        }
    }
}
