using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class MovementHook : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void LookAtMoveDir(Vector3 Dir,Transform owner,float speed)
    {
        owner.rotation = Quaternion.Slerp(owner.rotation, Quaternion.LookRotation(Dir), speed * Time.deltaTime);
    }
}
