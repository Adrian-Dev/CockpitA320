// https://answers.unity.com/questions/820599/simulate-button-presses-through-code-unity-46-gui.html
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExecuteEventsOnButton : MonoBehaviour
{
    [SerializeField] Button _button;

    public void SimulatePointerUp()
    {
        ExecuteEvents.Execute(_button.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler);
    }
}
