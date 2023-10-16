using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableSM/Actions/rainbowStart")]
public class rainbowStart : Action
{
   
    public override void Act(StateController controller)
    {
        GameObject camera = GameManagers.getCamera();
        camera.GetComponent<BGMAudioManager>().pauseAudio();
        controller.GetComponent<PlayerController>().playRainbow();
    }
}
