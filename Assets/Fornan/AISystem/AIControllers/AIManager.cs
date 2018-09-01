using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour {

    protected NavMeshAgent _myAgent;
    protected StatesManager _sm;
    protected bool _isThinking;

    public bool isControllingCreature = true;

    public GameObject creatureToBeAngryAt = null;

    public State ThinkState;
    public State AngryState;
    public State IdleState;
    public State PatrolState;
    public State AttackState;

    public State NextState = null;

    protected virtual void Start()
    {
        _myAgent = gameObject.GetComponent<NavMeshAgent>();
        _sm = gameObject.GetComponent<StatesManager>();
    }

    protected virtual void Update()
    {
        if(!isControllingCreature) { return; }

        if(ThinkState)
        {
            if(!_isThinking)
            {
                ThinkState.OnStart();
            }
        }

        if(_sm.currentState != NextState && NextState)
        {
            _sm.DoTransition(NextState);
        }
    }
}
