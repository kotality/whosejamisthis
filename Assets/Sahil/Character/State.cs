using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
public class State : ScriptableObject {
    public GameObject owner;
    public StatesManager states;
    public Rigidbody rb;
    public UserInput ih;
    public virtual void OnStart()
    {
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
