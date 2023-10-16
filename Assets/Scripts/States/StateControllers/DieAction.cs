using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Actions/Die")]
public class DieAction : Action
{
    public SimpleGameEvent gameOver;
    // Start is called before the first frame update
    public override void Act(StateController controller)
    {
        Debug.Log("die");
        gameOver.Raise(this);
    }
}
