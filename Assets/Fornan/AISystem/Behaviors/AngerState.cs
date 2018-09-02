using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "States/AI/DefaultAnger")]
public class AngerState : State {

    protected AIManager _aim;
    protected Transform _targetTransform;
    public float targetPositionRecalculateRange = 0.3f;

    public override void OnStart()
    {
        base.OnStart();
        if (!_aim)
        {
            _aim = owner.GetComponent<AIManager>();
        }
        _targetTransform = _aim.creatureToBeAngryAt.transform;
    }

    public override void OnTick()
    {
        if(!_aim.myDamageEmitter) { return; }

        if(_aim.myDamageEmitter.WithinRangeOf(_targetTransform.position) || Vector3.Distance(owner.transform.position, _targetTransform.position) < targetPositionRecalculateRange)
        {
            _aim.MyAgent.isStopped = true;
            _aim.myDamageEmitter.UseAttack(_aim.creatureToBeAngryAt);
        }
        else
        {
            _aim.MyAgent.isStopped = false;
            if (Vector3.Distance(owner.transform.position, _aim.MyAgent.destination) >= targetPositionRecalculateRange)
            {
                _aim.MyAgent.SetDestination(_targetTransform.position);
            }
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        if (_aim)
        {
            if (_aim.MyAgent)
            {
                if (_aim.MyAgent.isOnNavMesh)
                {
                    _aim.MyAgent.SetDestination(owner.transform.position);
                    _aim.MyAgent.isStopped = false;
                }
            }
        }
    }
}
