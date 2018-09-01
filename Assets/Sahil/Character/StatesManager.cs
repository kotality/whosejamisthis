using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesManager : MonoBehaviour {
    public State currentState;
   
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if(!currentState) { return; }

        currentState.OnTick();

        if(currentState.nextStates.Length >= 1)
        {
            State nextState = null;
            for(int i = 0; currentState.nextStates[i] && !nextState; i++)
            {
                if(currentState.nextStates[i].StateCriteriaMet())
                {
                    nextState = currentState.nextStates[i];
                }
            }
            if(nextState)
            {
                DoTransition(nextState);
            }
        }
	}
    void DoTransition(State state)
    {
        this.currentState.OnExit();
        this.currentState = state;
        state.OnStart();
    }
}
