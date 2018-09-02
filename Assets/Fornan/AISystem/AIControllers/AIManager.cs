using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour {

    public NavMeshAgent MyAgent;
    public DamageEmitter myDamageEmitter;
    public Animator myAnimator;
    protected AIStatesManager _sm;
    protected Rigidbody _rb;

    public bool isControllingCreature = true;
    protected bool _isThinking = false;

    public GameObject creatureToBeAngryAt = null;

    public AIState ThinkState;

    public State NextState = null;

    protected virtual void Start()
    {
        if(!MyAgent)
        {
            Debug.LogError("NavMeshAgent is not hooked up to the AIManager!");
        }
        _sm = gameObject.GetComponent<AIStatesManager>();
        _sm.myAIManager = this;
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        if(myAnimator)
        {
            if (isControllingCreature)
            {
                myAnimator.SetFloat("MovementSpeed", MyAgent.velocity.sqrMagnitude);
            }
            else
            {
                myAnimator.SetFloat("MovementSpeed", _rb.velocity.sqrMagnitude);
            }
        }

        if(!isControllingCreature)
        {
            if(ThinkState)
            {
                if(_isThinking)
                {
                    ThinkState.OnExit();
                    _isThinking = false;
                }
            }

            return;
        }
        if(ThinkState)
        {
            if(!_isThinking)
            {
                ThinkState.owner = gameObject;
                ThinkState.OnStart();
                _isThinking = true;
            }
            ThinkState.owner = gameObject;
            ThinkState.myAIManager = this;
            ThinkState.OnTick();
        }

        if((_sm.currentState != NextState) && NextState)
        {
            _sm.DoTransition(NextState);
        }
    }
}
