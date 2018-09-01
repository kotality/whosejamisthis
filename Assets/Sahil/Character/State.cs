using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

[CreateAssetMenu(fileName = "New State", menuName = "AI/State")]
public class State : ScriptableObject {
    public float speed;
    public State[] nextStates;

    public virtual bool StateCriteriaMet()
    {
        return true;
    }

    public virtual void OnStart()
    {
        
    }
    public virtual void OnTick()
    {
        
    }
    public virtual void OnExit()
    {
        
    }
}
