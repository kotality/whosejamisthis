using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="States/PlayerMove")]
public class playerMoveState : State {
    public float speed;

    public override void OnStart()
    {
        base.OnStart();
        rb = owner.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        
    }
    public override void OnTick()
    {
        base.OnTick();
        if(ih.inputVector.magnitude > 0)
        {
            rb.velocity = ih.inputVector * speed;
            lookAtDir(rb.velocity.normalized);
        }
    }
    public void lookAtDir(Vector3 dir)
    {
        owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, Quaternion.LookRotation(dir), .7f);
    }
}
