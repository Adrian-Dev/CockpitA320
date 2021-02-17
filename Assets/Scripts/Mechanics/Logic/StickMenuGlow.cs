using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickMenuGlow : MonoBehaviour
{
    [SerializeField] Material _materialFullAlpha;
    [SerializeField] Material _materialLowAlpha;

    [SerializeField] Image _imageUP;
    [SerializeField] Image _imageDOWN;
    [SerializeField] Image _imageLEFT;
    [SerializeField] Image _imageRIGHT;

    BNG.JoystickControl _joystickControl;



    bool _alreadyChecking;

    private void Awake()
    {
        _joystickControl = GetComponent<BNG.JoystickControl>();
        _alreadyChecking = false;
    }

    public void CheckAndUpdateMenuStick()
    {
        
        if (_joystickControl.angleX > 10f) // ROLL LEFT
        {
            _imageLEFT.material = _materialFullAlpha;
        }
        else
        {
            _imageLEFT.material = _materialLowAlpha;
        }

        if (_joystickControl.angleX < -10f) // ROLL RIGHT
        {
            _imageRIGHT.material = _materialFullAlpha;
        }
        else
        {
            _imageRIGHT.material = _materialLowAlpha;
        }

        if (_joystickControl.angleY > 10f) // PITCH UP
        {
            _imageUP.material = _materialFullAlpha;
        }
        else
        {
            _imageUP.material = _materialLowAlpha;
        }

        if (_joystickControl.angleY < -10f) // PITCH DOWN
        {
            _imageDOWN.material = _materialFullAlpha;
        }
        else
        {
            _imageDOWN.material = _materialLowAlpha;
        }
    }

    public void CheckAndUpdateMenuStick(float time)
    {
        if (!_alreadyChecking)
        {
            StartCoroutine(CheckAndUpdateMenuStickCoroutine(time));
        }
    }

    IEnumerator CheckAndUpdateMenuStickCoroutine(float time)
    {

        _alreadyChecking = true;

        float timeBefore = Time.unscaledTime;

        while ((Time.unscaledTime - timeBefore) < time)
        {
            CheckAndUpdateMenuStick();
            yield return new WaitForEndOfFrame();
        }

        _alreadyChecking = false;

        yield return null;
    }
}
