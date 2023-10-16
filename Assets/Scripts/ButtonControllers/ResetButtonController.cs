using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResetButtonController : MonoBehaviour
{
    public SimpleGameEvent gameRestart;

    public void ButtonClick()
    {
        gameRestart.Raise(this);
    }
}
