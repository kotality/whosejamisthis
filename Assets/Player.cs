using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    protected static Player _self;
    public static Player Self { get { return _self; } }

    protected GameObject _currentPossession;
    public GameObject StartingPossession;
    public GameObject CurrentPossession { get { return _currentPossession; } }
    public State moveState;
    protected StatesManager _sm;
    protected CameraController _cc;

    // Use this for initialization
    void Start () {
		if(_self)
        {
            Debug.LogError("More than one \"Player\" in scene - this should not be the case.");
        }
        else
        {
            _self = this;
            _cc = gameObject.GetComponent<CameraController>();
            if (StartingPossession)
            {
                SetPossessionAs(StartingPossession);
            }
        }
	}

    public virtual void SetPossessionAs(GameObject newCreature)
    {
        if(_currentPossession)
        {
            //Kill _currentPossession;
        }

        _currentPossession = newCreature;
        if(_cc)
        {
            _cc.target = newCreature.transform;
        }

        AIManager aim = newCreature.GetComponent<AIManager>();
        if(aim)
        {
            aim.isControllingCreature = false;
        }
        _sm = newCreature.GetComponent<StatesManager>();
        if(_sm)
        {
            _sm.DoTransition(moveState);
            playerMoveState pms = moveState as playerMoveState;
            if(pms && aim)
            {
                pms.speed = aim.MyAgent.speed * 2;
            }
        }
    }
}
