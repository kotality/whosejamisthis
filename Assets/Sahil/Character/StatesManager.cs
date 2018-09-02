using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class StatesManager : MonoBehaviour {
    public State currentState;

    [SerializeField] public State[] statesKeep;
    //public Hashtable<State> stateVault;
    public Hashtable stateVault;

    protected virtual void Awake()
    {
      foreach(State s in statesKeep)
        {
            if(s != null)
                   stateVault.Add(s.Statename, s);
        }      
    }

    protected virtual void Start ()
    {
        //Debug.Log("start");
        currentState.owner = this.gameObject;
        currentState.OnStart();
	}
	
	protected virtual void Update ()
    {
        //Debug.Log("Update");
        if(currentState.owner != gameObject)
        {
            currentState.owner = gameObject;
        }
        currentState.OnTick();
	}

    public virtual void DoTransition(State state)
    {
        state.owner = this.gameObject;
        this.currentState.OnExit();
        this.currentState = state;
        state.OnStart();
    }
}
