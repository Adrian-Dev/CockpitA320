using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable: MonoBehaviour, IInteractable
{
    public bool Active { get { return _active; } }
    public bool Triggered { get { return _triggered; } }

    bool _active;
    bool _triggered;

    public virtual void Activate()
    {
        _active = true;
    }

    public virtual void Deactivate()
    {
        _active = false;
    }

    public virtual void Restore()
    {
        Deactivate();
        _triggered = false;
    }

    public virtual void TriggerAction()
    {
        if (Active)
        {
            _triggered = true;
        }
    }
}
