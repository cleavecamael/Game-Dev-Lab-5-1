using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableSM/Actions/rainbowEnd")]
public class rainbowEnd : Action
{

    public override void Act(StateController controller)
    {
        GameObject camera = GameManagers.getCamera();
        camera.GetComponent<BGMAudioManager>().resumeAudio();
        controller.GetComponent<PlayerController>().stopAudio();
        controller.GetComponent<PlayerController>().playPowerDown();

    }
}
