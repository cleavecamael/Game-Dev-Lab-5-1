using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableSM/Actions/turnSmall")]
public class turnSmall : Action
{
    // Start is called before the first frame update
    public AnimatorSwitcher switcher;
    public string prevState;
    public override void Act(StateController controller)
    {
        Animator currentAnimator = controller.transform.GetComponent<Animator>();
        prevState = currentAnimator.runtimeAnimatorController.name;
        switcher.switchController(currentAnimator, AnimatorSwitcher.marioAnimators.smallController);
        
     
        Debug.Log("animator is " + prevState);
        if (prevState.Equals("Big Mario"))
        {
            currentAnimator.SetTrigger("turnSmall");
        }
        else
        {
            currentAnimator.SetTrigger("fireSmall");
        }
    }
}
