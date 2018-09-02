using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReciever : MonoBehaviour {

    public int maxHealth = 10;
    public int currentHealth = -1;
    public bool ignoreDamage = false;

    protected virtual void Start()
    {
        if(currentHealth == -1)
        {
            currentHealth = maxHealth;
        }
    }

    public virtual void TakeDamageFrom(DamageEmitter attacker)
    {
        if(ignoreDamage) { return; }
        currentHealth -= attacker.damage;
        if(currentHealth <= 0)
        {
            Die(attacker);
        }
    }

    protected virtual void Die(DamageEmitter killer)
    {
        if(killer.owner == Player.Self.CurrentPossession)
        {
            //The player killed this creature. The player now becomes this creature.
            Player.Self.SetPossessionAs(killer.owner);
            currentHealth = maxHealth;
        }
        else
        {
            //The player is the one dying.
        }
    }

    
}
