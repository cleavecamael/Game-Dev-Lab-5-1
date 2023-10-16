using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// later on, teach interface
public class RestartButtonController : MonoBehaviour, IInteractiveButton
{
    public SimpleGameEvent onRestart;
    // implements the interface
    public void ButtonClick()
    {
        onRestart.Raise(this);
    }
}