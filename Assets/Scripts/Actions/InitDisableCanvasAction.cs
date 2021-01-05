using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitDisableCanvasAction : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Canvas>().enabled = false;
    }
}
