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
        currentState.OnTick();
	}
    void DoTransition(State state)
    {
        this.currentState.OnExit();
        this.currentState = state;
        state.OnStart();
    }
}
