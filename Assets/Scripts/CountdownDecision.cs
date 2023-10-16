using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Decisions/Countdown")]
public class CountdownDecision : Decision
{
    public float buffDuration;
    public override bool Decide(StateController controller)
    {
        if (controller.CheckIfCountDownElapsed(buffDuration))
        {
            Debug.Log("time ended");
        }

        return controller.CheckIfCountDownElapsed(buffDuration);
    }
}