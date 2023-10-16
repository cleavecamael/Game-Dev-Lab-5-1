using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableSM/Actions/turnBigFire")]
public class turnBigFire : Action
{
    // Start is called before the first frame update
    public AnimatorSwitcher switcher;
    public string transitionTrigger;
    public override void Act(StateController controller)
    {
        Animator currentAnimator = controller.transform.GetComponent<Animator>();
        switcher.switchController(currentAnimator, AnimatorSwitcher.marioAnimators.fireController);
        if (transitionTrigger != null)
        {
            currentAnimator.SetTrigger(transitionTrigger);
        }
    }
}
