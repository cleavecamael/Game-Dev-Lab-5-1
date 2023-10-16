using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableSM/Actions/turnFire")]
public class turnFire : Action
{
    // Start is called before the first frame update
    public AnimatorSwitcher switcher;
    public string prevState;
    public override void Act(StateController controller)
    {
        Animator currentAnimator = controller.transform.GetComponent<Animator>();
        prevState = currentAnimator.runtimeAnimatorController.name;
        switcher.switchController(currentAnimator, AnimatorSwitcher.marioAnimators.fireController);
        Debug.Log("animator is " + prevState);
        if (prevState.Equals("Mario"))
        {
            currentAnimator.SetTrigger("smallToFire");
        }
        else
        {
            currentAnimator.SetTrigger("bigToFire");
        }


    }
}
