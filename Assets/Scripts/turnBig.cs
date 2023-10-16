using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableSM/Actions/turnBig")]
public class turnBig : Action
{
    // Start is called before the first frame update
    public AnimatorSwitcher switcher;
    public string transitionTrigger;
    public override void Act(StateController controller)
    {
        Animator currentAnimator = controller.transform.GetComponent<Animator>();
        switcher.switchController(currentAnimator, AnimatorSwitcher.marioAnimators.bigController);
        if (transitionTrigger != null)
        {
            currentAnimator.SetTrigger(transitionTrigger);
        }
    }
}
