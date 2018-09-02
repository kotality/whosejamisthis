using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : ScriptableObject {
    [SerializeField]
    public string Statename;
    public GameObject owner;
    public StatesManager states;
    public Rigidbody rb;
    public UserInput ih;
    public float usualDuration = 10.0f;


    public virtual void OnStart()
    {
        Debug.Log("StartBase");
        states = owner.GetComponent<StatesManager>();
        rb = owner.GetComponent<Rigidbody>();
        ih = owner.GetComponent<UserInput>();
    }
    public virtual void OnTick()
    {
    }
    public virtual void OnExit()
    {

    }
}
