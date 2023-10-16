using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableSM/Actions/removeDamage")]
public class removeDamage : Action
{
    // Start is called before the first frame update

    public override void Act(StateController controller)
    {
        controller.GetComponent<MarioStateController>().SetPowerup(PowerupType.Default);
    }
}
