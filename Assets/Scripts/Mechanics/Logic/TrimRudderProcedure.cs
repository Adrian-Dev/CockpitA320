using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrimRudderProcedure : MonoBehaviour
{
    [SerializeField] RudderValue _rudderValue;
    [SerializeField] Canvas _toolTipCanvas;
    [SerializeField] List<TMPro.TextMeshProUGUI> _stagesText;

    bool _alreadyWorking;
    int _stage;

    public enum Stage
    {

    }

    private void Awake()
    {
        _alreadyWorking = false;
        _stage = 0;

        for(int i = 0; i < _stagesText.Count; ++i)
        {
            _stagesText[i].enabled = false;
        }

        _toolTipCanvas.enabled = false;
    }

    private void Start()
    {
        _rudderValue.ForceTrimValue(11.2f, "R");
        ExecAndGoNext(); // To be removed when adding menu option
    }

    public void ExecAndGoNext()
    {
        if(_stage == 0)
        {
            ResetRudder(1);
        }
        else if (_stage == 1)
        {
            SetAndWaitLeftTrim(2);
        }
        else if (_stage == 2)
        {
            ResetRudder(3);
        }
        else if (_stage == 3)
        {
            SetAndWaitRightTrim(4);
        }
        else if (_stage == 4)
        {
            ResetRudder(5);
        }
    }

    void ResetRudder(int nextStage)
    {
        if (!_alreadyWorking)
        {
            StartCoroutine(ResetRudderCoroutine(nextStage));
        }
    }

    IEnumerator ResetRudderCoroutine(int nextStage)
    {
        _alreadyWorking = true;

        _toolTipCanvas.enabled = true;
        _stagesText[0].enabled = true;

        yield return new WaitUntil(() => (_rudderValue.Value) < 0.01f);
        _stage = nextStage;

        _stagesText[0].enabled = false;
        _toolTipCanvas.enabled = false;

        yield return new WaitForSeconds(2f);

        _alreadyWorking = false;
        ExecAndGoNext();

        yield return null;
    }

    void SetAndWaitLeftTrim(int nextStage)
    {
        if (!_alreadyWorking)
        {
            StartCoroutine(SetAndWaitLeftTrimCoroutine(nextStage));
        }
    }

    IEnumerator SetAndWaitLeftTrimCoroutine(int nextStage)
    {
        _alreadyWorking = true;

        _toolTipCanvas.enabled = true;
        _stagesText[1].enabled = true;

        yield return new WaitUntil(() => (_rudderValue.Orientation) == "L");
        yield return new WaitUntil(() => (_rudderValue.Value) > 10f);
        _stage = nextStage;

        _stagesText[1].enabled = false;
        _toolTipCanvas.enabled = false;

        yield return new WaitForSeconds(2f);

        _alreadyWorking = false;
        ExecAndGoNext();

        yield return null;
    }


    void SetAndWaitRightTrim(int nextStage)
    {
        if (!_alreadyWorking)
        {
            StartCoroutine(SetAndWaitRightTrimCoroutine(nextStage));
        }
    }

    IEnumerator SetAndWaitRightTrimCoroutine(int nextStage)
    {
        _alreadyWorking = true;

        _toolTipCanvas.enabled = true;
        _stagesText[2].enabled = true;

        yield return new WaitUntil(() => (_rudderValue.Orientation) == "R");
        yield return new WaitUntil(() => (_rudderValue.Value) > 10f);
        _stage = nextStage;

        _stagesText[2].enabled = false;
        _toolTipCanvas.enabled = false;

        _alreadyWorking = false;

        yield return null;
    }
}
