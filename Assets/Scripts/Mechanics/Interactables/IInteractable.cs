using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    bool Active { get; }
    bool Triggered { get; }

    void Activate();
    void Deactivate();
    void Restore();
    void TriggerAction();

}
