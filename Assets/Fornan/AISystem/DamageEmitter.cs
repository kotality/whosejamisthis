using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEmitter : MonoBehaviour {

    public int damage = 1;
    public enum DamageType
    {
        NORMAL,
        FIRE,
        ICE
    }
    public DamageType myDamageType = DamageType.NORMAL;

    public bool doFreezeColliderOnAttack = false;
    public GameObject owner;

    protected Animator _anim;

    protected List<Collider> _intersectingColliders = new List<Collider>();
    protected Vector3 initialLocalPosition;
    protected Quaternion initialLocalRotation;
    protected Vector3 frozenPosition;
    protected Quaternion frozenRotation;
    protected bool freezePosition = false;
    protected float attackCoolDownRemaining = 0.0f;
    protected bool currentlyAttacking = false;

    protected GameObject _damageRecipient = null;

    protected virtual void Update()
    {
        if(freezePosition)
        {
            transform.position = frozenPosition;
            transform.rotation = frozenRotation;
        }
        if(attackCoolDownRemaining > 0.0f && !currentlyAttacking)
        {
            attackCoolDownRemaining -= Time.deltaTime;
        }
    }

    //UseAttack triggers an animation. The animation has an Animation Event that calls ApplyDamage on this object at the right time to actually apply damage.
    public virtual void UseAttack(GameObject recipient)
    {
        if(attackCoolDownRemaining > 0.0f) { return; }
        if(doFreezeColliderOnAttack)
        {
            SetFreezePosition(true);
        }
        //trigger attack anim
        currentlyAttacking = true;
        Debug.Log("Attacking!");
        _damageRecipient = recipient;
    }

    public virtual bool WithinRangeOf(Vector3 targetLocation)
    {
        foreach(Collider c in _intersectingColliders)
        {
            if(c.bounds.Contains(targetLocation))
            {
                return true;
            }
        }
        return false;
    }

    public virtual void ApplyDamage()
    {
        //if (_damageRecipient)
        //{
        //    //Damage anything
        //}
        //else
        //{
        //    //Damage only recipient
        //}

        foreach(Collider c in _intersectingColliders)
        {
            DamageReciever dr = c.GetComponent<DamageReciever>();
            if(dr)
            {
              dr.TakeDamageFrom(this);
            }
        }
        SetFreezePosition(false);
        currentlyAttacking = false;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other)
        {
            if(!_intersectingColliders.Contains(other))
            {
                _intersectingColliders.Add(other);
            }
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if(other)
        {
            _intersectingColliders.Remove(other);
        }
    }

    protected virtual void SetFreezePosition(bool value)
    {
        if(value != freezePosition)
        {
            if(value)
            {
                initialLocalPosition = transform.localPosition;
                initialLocalRotation = transform.localRotation;
                freezePosition = true;
            }
            else
            {
                freezePosition = false;
                transform.localPosition = initialLocalPosition;
                transform.localRotation = initialLocalRotation;
            }
        }
    }
}
