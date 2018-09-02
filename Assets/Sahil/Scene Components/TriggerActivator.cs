using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TriggerActivator : MonoBehaviour {
    UnityEvent onEnter;
    UnityEvent onExit;
    public AIManager.CreatureType creatureType;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<AIManager>() != null) { 
        if (!other.GetComponent<AIManager>().isControllingCreature)
        {
                if (other.GetComponent<AIManager>().myDamageType == creatureType)
                {
                    onEnter.Invoke();
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<AIManager>() != null) {
            if (!other.GetComponent<AIManager>().isControllingCreature)
            {
                if (other.GetComponent<AIManager>().myDamageType == creatureType)
                {
                    onExit.Invoke();
                }
            }
        }
    }
}
