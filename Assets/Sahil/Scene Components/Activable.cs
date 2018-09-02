using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Activable : MonoBehaviour {
    public float timeBeforeActivation = 0f;
    public virtual void Activate() => Invoke("OnActivate", timeBeforeActivation);
    public virtual void OnActivate(){}
    public virtual void DeActivate() => Invoke("OnDeActivate",timeBeforeActivation);
    public virtual void OnDeActivate(){}
}
