using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableSM/Actions/turnSmallSilent")]
public class turnSmallSilent : Action
{
    // Start is called before the first frame update
    public AnimatorSwitcher switcher;

    public override void Act(StateController controller)
    {
        Animator currentAnimator = controller.transform.GetComponent<Animator>();
        switcher.switchController(currentAnimator, AnimatorSwitcher.marioAnimators.smallController);
     
    }
}
