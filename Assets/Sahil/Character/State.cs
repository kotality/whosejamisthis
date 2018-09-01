using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
public class State : ScriptableObject {
    public float speed;
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
