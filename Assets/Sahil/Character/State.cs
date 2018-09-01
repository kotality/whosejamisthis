using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD

public class State : ScriptableObject {
    public float speed;
    
    public virtual void OnStart()
    {

    }
    public virtual void OnMove()
    {

=======
using System.Reflection;
public class State : ScriptableObject {
    public float speed;
    public virtual void OnStart()
    {  
    }
    public virtual void OnTick()
    {
>>>>>>> Sahil
    }
    public virtual void OnExit()
    {

    }
}
