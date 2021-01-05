using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RudderValue : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshPro _textMeshOrientation;
    [SerializeField] TMPro.TextMeshPro _textMeshValue;

    float _currentValue;
    bool _isChanging;
    bool _isLeftIncreased;
    bool _isRightIncreased;
    private void Awake()
    {
        _currentValue = 0f;
        _isChanging = false;
        _isLeftIncreased = false;
        _isRightIncreased = false;
    }

    public void IncreaseRudderLeft()
    {
        if (!_isChanging && !_isRightIncreased)
        {
            _isLeftIncreased = true;
            StartCoroutine(IncreaseRudderLeftCoroutine());
        }
    }

    public void IncreaseRudderRight()
    {
        if (!_isChanging && !_isLeftIncreased)
        {
            _isRightIncreased = true;
            StartCoroutine(IncreaseRudderRightCoroutine());
        }
    }

    public void DecreaseRudder()
    {
        if (!_isChanging)
        {
            StartCoroutine(DecreaseRudderCoroutine());
        }
    }

    IEnumerator IncreaseRudderLeftCoroutine()
    {
        _isChanging = true;
        _textMeshOrientation.text = "L";

        if (_currentValue < 20.0f)
        {
            _currentValue = _currentValue + 0.1f;
            _textMeshValue.text = _currentValue.ToString("0.0");

            yield return new WaitForSeconds(0.1f);
        }

        _isChanging = false;

        yield return null;
    }
    IEnumerator IncreaseRudderRightCoroutine()
    {
        _isChanging = true;
        _textMeshOrientation.text = "R";

        if (_currentValue < 20.0f)
        {
            _currentValue = _currentValue + 0.1f;
            _textMeshValue.text = _currentValue.ToString("0.0");

            yield return new WaitForSeconds(0.1f);
        }

        _isChanging = false;

        yield return null;
    }

    IEnumerator DecreaseRudderCoroutine()
    {
        _isChanging = true;
        _textMeshOrientation.text = "";
        while (_currentValue > 0f)
        {
            _textMeshValue.text = _currentValue.ToString("0.0");
            _currentValue = _currentValue - 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        _currentValue = 0f;
        _textMeshValue.text = "";

        _isChanging = false;
        _isLeftIncreased = false;
        _isRightIncreased = false;

        yield return null;
    }
}
