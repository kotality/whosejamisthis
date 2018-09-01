using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugConnectControllerAndPawn : MonoBehaviour {

    public Controller Controller;
    public Pawn Pawn;
	
	// Update is called once per frame
	void OnValidate () {
		if(Controller && Pawn)
        {
            Controller.PossessPawn(Pawn);
        }
	}
}
