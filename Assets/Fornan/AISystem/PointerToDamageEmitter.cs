using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerToDamageEmitter : MonoBehaviour {

    public DamageEmitter myDamageEmitter;

    public void ApplyDamageEmitter()
    {
        if(myDamageEmitter)
        {
            myDamageEmitter.ApplyDamage();
        }
    }
}
