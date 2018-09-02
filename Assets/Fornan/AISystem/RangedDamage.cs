using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedDamage : DamageEmitter {

    public float attackCoolDown = 2.0f;
    public GameObject projectile;

    public override void UseAttack(GameObject recipient)
    {
        Debug.Log("ATTACK");
        if(currentlyAttacking) { return; }

        _anim.SetTrigger("Attack");
        GameObject proj = Instantiate(projectile, transform.position, transform.rotation);
        proj.GetComponent<Projectile>().de = this;
        StartCoroutine(RunCoolDown());
    }

    protected virtual IEnumerator RunCoolDown()
    {
        currentlyAttacking = true;
        float timer = attackCoolDown;
        while(timer > 0)
        {
            yield return null;
            timer -= Time.deltaTime;
        }
        currentlyAttacking = false;
    }
}
