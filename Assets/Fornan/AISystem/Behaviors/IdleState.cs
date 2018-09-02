using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/AI/DefaultIdle")]
public class IdleState : AIState {

    public override void OnStart()
    {
        base.OnStart();
        myAIManager.MyAgent.isStopped = true;
    }

    public override void OnTick()
    {
        
    }

    public override void OnExit()
    {
        base.OnExit();
        //Animator stop idle animation
        if(myAIManager)
        {
            if(myAIManager.MyAgent)
            {
                if (myAIManager.MyAgent.isOnNavMesh)
                {
                    myAIManager.MyAgent.isStopped = false;
                }
            }
        }
    }
}
