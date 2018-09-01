using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericThink : State {

    //The think state figures out what the next state to do should be based off of stimuli
    public State AngryState;
    public State IdleState;
    public State PatrolState;

    public float maxStateTimer = 10.0f;

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
        if (timeLeftOnState <= 0.0f)
        {
            aim.creatureToBeAngryAt = null;
            float rng = Random.value;
            if (rng <= 0.5f)
            {
                aim.NextState = PatrolState;
            }
            else
            {
                aim.NextState = IdleState;
            }
            timeLeftOnState = Random.Range(1.0f, maxStateTimer);
        }
        else if(aim.creatureToBeAngryAt != null)
        {
            aim.NextState = AngryState;
            if(CanOwnerSee(aim.creatureToBeAngryAt))
            {
                timeLeftOnState = maxStateTimer;
            }
            else
            {
                timeLeftOnState -= Time.deltaTime;
            }
        }
        else
        {
            timeLeftOnState -= Time.deltaTime;
        }
    }

    public override void OnExit()
    {
        aim.NextState = null;
    }

    public virtual bool CanOwnerSee(GameObject other)
    {
        Vector3 vectorTowardsOther = owner.transform.position - other.transform.position;
        if (vectorTowardsOther.sqrMagnitude <= visionProximityRadius * visionProximityRadius)
        {
            return true;
        }
        if(Vector3.Angle(owner.transform.forward, vectorTowardsOther) > visionCone)
        {
            return false;
        }
        int hitCount = Physics.RaycastNonAlloc(owner.transform.position, vectorTowardsOther, new RaycastHit[3], visionSightDistance);
        Debug.Log("Things found in raycast: " + hitCount);
        if(hitCount <= 2)
        {
            return true;
        }

        return false;
    }
}
