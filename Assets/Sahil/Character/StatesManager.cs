using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class StatesManager : MonoBehaviour {
    public State currentState;

    [SerializeField] public State[] statesKeep;
    //public Hashtable<State> stateVault;
    public Hashtable stateVault;

    void Awake()
    {
      foreach(State s in statesKeep)
        {
            stateVault.Add(s.Statename, s);
        }      
    }

    void Start ()
    {
        Debug.Log("start");
        currentState.owner = this.gameObject;
        currentState.OnStart();
	}
	
	void Update ()
    {
        Debug.Log("Update");
        currentState.OnTick();
	}

    public void DoTransition(State state)
    {
        state.owner = this.gameObject;
        this.currentState.OnExit();
        this.currentState = state;
        state.OnStart();
    }
}
