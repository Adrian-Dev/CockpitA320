using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable: MonoBehaviour, IInteractable
{
    public bool Active { get { return _active; } }
    public bool Triggered { get { return _triggered; } }
    public bool Grabbed { get { return _grabbed; } }

    bool _active;
    bool _triggered;
    bool _grabbed;

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
        _grabbed = false;
    }

    public virtual void TriggerAction()
    {
        if (Active)
        {
            _triggered = true;
        }
    }

    public virtual void GrabbedAction()
    {
        if (Active)
        {
            _grabbed = true;
        }
    }
}
