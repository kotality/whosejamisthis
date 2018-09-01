using System.Collections.Generic;
using UnityEngine;

public class StatesManager : MonoBehaviour {
    public State currentState;

    [SerializeField] public State[] statesKeep;
    [SerializeField] public Dictionary<string, State> stateVault;

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

    void DoTransition(State state)
    {
        state.owner = this.gameObject;
        this.currentState.OnExit();
        this.currentState = state;
        state.OnStart();
    }
}
