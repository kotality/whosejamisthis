using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "States/AI/DefaultPatrol")]
public class PatrolState : AIState
{

    public float maximumPatrolPointDistance = 10.0f;

    public override void OnStart()
    {
        base.OnStart();
    }

    public override void OnTick()
    {
        if(myAIManager.MyAgent.remainingDistance < 1.0f)
        {
            myAIManager.MyAgent.SetDestination(GetRandomPointOnNavMesh());
            myAIManager.MyAgent.isStopped = false;
        }
    }

    protected virtual Vector3 GetRandomPointOnNavMesh()
    {
        Vector2 randomPoint = Random.insideUnitCircle * maximumPatrolPointDistance;
        Vector3 position = owner.transform.position + new Vector3(randomPoint.x, 0.0f, randomPoint.y);
        NavMeshHit hit;
        if(NavMesh.SamplePosition(position, out hit, maximumPatrolPointDistance, NavMesh.AllAreas))
        {
            return hit.position;
        }
        else
        {
            return owner.transform.position;
        }
    }
}
