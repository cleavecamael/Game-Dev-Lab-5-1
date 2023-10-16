using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/AnimatorSwitcher")]
public class AnimatorSwitcher : ScriptableObject
{
    public RuntimeAnimatorController bigController;
    public RuntimeAnimatorController smallController;
    public RuntimeAnimatorController fireController;

    public enum marioAnimators
    {
        bigController,
        smallController,
        fireController
    }
    public void switchController(Animator currAnimator, marioAnimators controller)
    {
        {
            RuntimeAnimatorController nextController = null;
            if (controller.Equals(marioAnimators.bigController))
            {
                nextController = bigController;
            }
            if (controller.Equals(marioAnimators.smallController))
            {
                nextController = smallController;
            }
            if (controller.Equals(marioAnimators.fireController))
            {
                nextController = fireController;
            }

            currAnimator.runtimeAnimatorController = nextController;
        }
    }
}

