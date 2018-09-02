using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float LifeTime = 4.0f;
    public float Velocity = 3.0f;
    public DamageEmitter de;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb.velocity = transform.forward * Velocity;
        Destroy(gameObject, LifeTime);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == de.owner) { return; }

        DamageReciever dr = collision.gameObject.GetComponent<DamageReciever>();
        if(dr)
        {
            dr.TakeDamageFrom(de);
        }

        Destroy(gameObject);
    }
}
