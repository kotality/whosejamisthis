using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReciever : MonoBehaviour {

    //If you want something to be able to take damage, but never die, set it's maxHealth to 0 or lower.
    public int maxHealth = 10;
    //If you want currentHealth to start at maxHealth, have it be -1.
    public int currentHealth = -1;
    //If you want this reciever to entirely ignore damage, set ignoreDamage to true.
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
        if(currentHealth <= 0 && maxHealth > 0)
        {
            Die(attacker);
        }
    }

    protected virtual void Die(DamageEmitter killer)
    {
        if(killer.owner == Player.Self.CurrentPossession)
        {
            //The player killed this creature. The player now becomes this creature.
            Player.Self.SetPossessionAs(gameObject);
            currentHealth = maxHealth * 3;
        }
        else
        {
            if(gameObject == Player.Self.CurrentPossession)
            {
                if(Player.Self.CrownPrefab)
                {
                    GameObject crown = Instantiate(Player.Self.CrownPrefab, transform.position, transform.rotation);
                    crown.AddComponent<Rigidbody>();
                    MeshCollider mc = crown.AddComponent<MeshCollider>();
                    mc.convex = true;

                    Player.Self.GameOver();
                }
            }
            gameObject.SetActive(false);
            ignoreDamage = true;
        }
    }

    
}
