using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableSM/Actions/renderBig")]
public class renderBig : Action
{
    // Start is called before the first frame update

    public override void Act(StateController controller)
    {
        controller.GetComponent<PlayerController>().renderBig();
    }
}
