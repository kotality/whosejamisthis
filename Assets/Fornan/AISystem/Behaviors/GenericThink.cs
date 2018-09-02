using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/AI/DefaultThink")]
public class GenericThink : State {

    //The think state figures out what the next state to do should be based off of stimuli
    public State AngryState;
    public State IdleState;
    public State PatrolState;

    public float visionProximityRadius = 5.0f;
    public float visionSightDistance = 20.0f;
    public float visionCone = 270.0f;

    protected AIManager aim;
    protected float timeLeftOnState = 0.0f;

    public override void OnStart()
    {
        base.OnStart();
        aim = owner.GetComponent<AIManager>();
    }

    public override void OnTick()
    {
        if (CanOwnerSee(Player.Self.CurrentPossession))
        {
            aim.creatureToBeAngryAt = Player.Self.CurrentPossession;
            timeLeftOnState = AngryState.usualDuration;
            aim.NextState = AngryState;
        }

        if (timeLeftOnState <= 0.0f)
        {
            aim.creatureToBeAngryAt = null;

            float rng = Random.value;
            if (rng <= 0.7f)
            {
                aim.NextState = PatrolState;
            }
            else
            {
                aim.NextState = IdleState;
            }
            timeLeftOnState = Random.Range(1.0f, aim.NextState.usualDuration);
        }
        else
        {
            timeLeftOnState -= Time.deltaTime;
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        if(aim)
        {
            aim.NextState = null;
        }
    }

    public virtual bool CanOwnerSee(GameObject other)
    {
        if(!other) { return false; }

        Vector3 vectorTowardsOther = other.transform.position - owner.transform.position;
        if (vectorTowardsOther.sqrMagnitude <= visionProximityRadius * visionProximityRadius)
        {
            return true;
        }
        if(vectorTowardsOther.sqrMagnitude > visionSightDistance * visionSightDistance)
        {
            return false;
        }
        if(Vector3.Angle(owner.transform.forward, vectorTowardsOther) > visionCone)
        {
            return false;
        }

        int hitCount = Physics.RaycastNonAlloc(owner.transform.position, vectorTowardsOther, new RaycastHit[3]);
        
        Debug.DrawRay(owner.transform.position, vectorTowardsOther, Color.red, 1.0f);
        if(hitCount <= 2)
        {
            return true;
        }

        return false;
    }
}
