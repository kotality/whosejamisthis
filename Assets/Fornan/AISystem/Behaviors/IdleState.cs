using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/AI/DefaultIdle")]
public class IdleState : State {

    protected AIManager _aim;

    public override void OnStart()
    {
        base.OnStart();
        if(!_aim)
        {
            _aim = owner.GetComponent<AIManager>();
        }
        _aim.MyAgent.isStopped = true;
    }

    public override void OnTick()
    {
        
    }

    public override void OnExit()
    {
        base.OnExit();
        //Animator stop idle animation
        if(_aim.MyAgent.isOnNavMesh)
        {
            _aim.MyAgent.isStopped = false;
        }
    }
}
