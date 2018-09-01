using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour {

    protected NavMeshAgent _myAgent;
    protected StatesManager _sm;

    public bool isControllingCreature = true;

    public GameObject creatureToBeAngryAt = null;

    public State ThinkState;
    public State AngryState;
    public State IdleState;
    public State PatrolState;
    public State AttackState;

    protected virtual void Start()
    {
        _myAgent = gameObject.GetComponent<NavMeshAgent>();
        _sm = gameObject.GetComponent<StatesManager>();

        if(isControllingCreature)
        {
            _sm.DoTransition(ThinkState);
        }
    }

    protected virtual void Update()
    {
        
    }
}
