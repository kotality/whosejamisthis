using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour {

    public NavMeshAgent MyAgent;
    protected StatesManager _sm;
    protected bool _isThinking;

    public bool isControllingCreature = true;

    public GameObject creatureToBeAngryAt = null;

    public State ThinkState;

    public State NextState = null;

    protected virtual void Start()
    {
        MyAgent = gameObject.GetComponent<NavMeshAgent>();
        _sm = gameObject.GetComponent<StatesManager>();

    }

    protected virtual void Update()
    {
        if(!isControllingCreature)
        {
            if(_isThinking && ThinkState)
            {
                ThinkState.OnExit();
                _isThinking = false;
            }
        }

        if(ThinkState)
        {
            if(!_isThinking)
            {
                ThinkState.owner = gameObject;
                ThinkState.OnStart();
                _isThinking = true;
            }
            ThinkState.OnTick();
        }

        if((_sm.currentState != NextState) && NextState)
        {
            _sm.DoTransition(NextState);
        }
    }
}
