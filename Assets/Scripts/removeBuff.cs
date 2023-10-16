using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableSM/Actions/removeBuff")]
public class removeBuff : Action
{
    // Start is called before the first frame update

    public override void Act(StateController controller)
    {
        BuffStateController buffController = (BuffStateController)controller;
        buffController.resetRainbow();
        buffController.currentBuff = Buff.Default;

    } 
}
