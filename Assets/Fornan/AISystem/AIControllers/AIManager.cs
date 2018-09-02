using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour {

    public NavMeshAgent MyAgent;
    public DamageEmitter myDamageEmitter;
    protected StatesManager _sm;

    public bool isControllingCreature = true;

    public GameObject creatureToBeAngryAt = null;

    public State ThinkState;

    public State NextState = null;

    protected virtual void Start()
    {
        if(!MyAgent)
        {
            Debug.LogError("NavMeshAgent is not hooked up to the AIManager!");
        }
        _sm = gameObject.GetComponent<StatesManager>();
        if(ThinkState)
        {
            ThinkState.OnExit();
        }
    }

    protected virtual void Update()
    {
        if(!isControllingCreature)
        {
            if(ThinkState)
            {
                if(ThinkState.IsStateActive)
                {
                    ThinkState.OnExit();
                }
            }

            return;
        }
        if(ThinkState)
        {
            if(!ThinkState.IsStateActive)
            {
                ThinkState.owner = gameObject;
                ThinkState.OnStart();
            }
            ThinkState.OnTick();
        }

        if((_sm.currentState != NextState) && NextState)
        {
            _sm.DoTransition(NextState);
        }
    }
}
