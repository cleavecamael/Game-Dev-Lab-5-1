using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableSM/Actions/rainbowAction")]
public class rainbowAction : Action
{

    public override void Act(StateController controller)
    {
        BuffStateController buffController = (BuffStateController)controller;
        buffController.SetRenderertoRainbow();
    }
}
