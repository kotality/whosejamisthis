using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Activable {
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    public override void OnActivate()
    {
        base.OnActivate();
        anim.SetBool("Open", true);
    }
    public override void DeActivate()
    {
        base.DeActivate();
        anim.SetBool("Open", false);
    }
}
