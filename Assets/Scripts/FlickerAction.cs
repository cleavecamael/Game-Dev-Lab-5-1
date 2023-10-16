using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableSM/Actions/flicker")]
public class flickerAction: Action
{
    // Start is called before the first frame update
    public AnimatorSwitcher switcher;
    public string prevState;
    public override void Act(StateController controller)
    {
        MarioStateController marioController = (MarioStateController)controller;
        marioController.SetRendererToFlicker();
    }
}
