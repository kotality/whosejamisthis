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
    protected bool _isActive = false;
    public bool IsStateActive { get { return _isActive;  } }


    public virtual void OnStart()
    {
        //Debug.Log("StartBase");
        _isActive = true;
        states = owner.GetComponent<StatesManager>();
        rb = owner.GetComponent<Rigidbody>();
        ih = FindObjectOfType<UserInput>();
    }
    public virtual void OnTick()
    {
    }
    public virtual void OnExit()
    {
        _isActive = false;
    }
}
