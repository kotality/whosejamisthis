using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [Range(0,1)]  public float speed;

    public Transform target;
    public Vector3 offSet = Vector3.zero;

    //Do Not Modify 
    Vector3 currentVel;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offSet, ref currentVel, speed);
	}
}
