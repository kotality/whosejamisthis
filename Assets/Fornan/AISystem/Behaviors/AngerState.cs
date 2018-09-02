using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "States/AI/DefaultAnger")]
public class AngerState : AIState
{
    public float targetPositionRecalculateRange = 0.3f;

    public override void OnStart()
    {
        base.OnStart();
    }

    public override void OnTick()
    {
        if(!myAIManager.myDamageEmitter) { return; }

        if(myAIManager.myDamageEmitter.WithinRangeOf(myAIManager.creatureToBeAngryAt.transform.position) || Vector3.Distance(owner.transform.position, myAIManager.creatureToBeAngryAt.transform.position) < targetPositionRecalculateRange)
        {
            myAIManager.MyAgent.isStopped = true;
            myAIManager.myDamageEmitter.UseAttack(myAIManager.creatureToBeAngryAt);
        }
        else
        {
            myAIManager.MyAgent.isStopped = false;
            if (Vector3.Distance(owner.transform.position, myAIManager.MyAgent.destination) >= targetPositionRecalculateRange)
            {
                myAIManager.MyAgent.SetDestination(myAIManager.creatureToBeAngryAt.transform.position);
            }
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        if (myAIManager)
        {
            if (myAIManager.MyAgent)
            {
                if (myAIManager.MyAgent.isOnNavMesh)
                {
                    myAIManager.MyAgent.SetDestination(owner.transform.position);
                    myAIManager.MyAgent.isStopped = false;
                }
            }
        }
    }
}
