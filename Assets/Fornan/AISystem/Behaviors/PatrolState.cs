using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "States/AI/DefaultPatrol")]
public class PatrolState : State {

    public float maximumPatrolPointDistance = 10.0f;
    protected AIManager _aim;
    protected Vector3 currentDestination;

    public override void OnStart()
    {
        base.OnStart();
        if (!_aim)
        {
            _aim = owner.GetComponent<AIManager>();
        }
    }

    public override void OnTick()
    {
        if(currentDestination != _aim.MyAgent.destination || _aim.MyAgent.remainingDistance < 1.0f)
        {
            currentDestination = GetRandomPointOnNavMesh();
            _aim.MyAgent.SetDestination(currentDestination);
            _aim.MyAgent.isStopped = false;
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
