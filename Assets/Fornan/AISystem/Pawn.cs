using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pawn recieves messages from a controller, and the pawn decides which behaviors are executed.
//If there is no controller, then the pawn becomes possesed by AI
public class Pawn : MonoBehaviour {
    #region Variables
    public Animator AIStateMachine;
    protected Controller _controller;
    public Controller MyController { get { return _controller; } }

    public BaseAbility MovementAbility;
    public BaseAbility CombatAbility1;
    public BaseAbility CombatAbility2;

    #endregion

    protected virtual void Start()
    {
        if(AIStateMachine && !_controller)
        {
            AIStateMachine.SetBool("IsActive", true);
        }
    }

    #region Possession
    public virtual bool BecomePossessed(Controller possessionRequester)
    {
        //If already possessed, cannot possess this pawn.
        if (_controller)
        {
            if (AIStateMachine)
            {
                AIStateMachine.SetBool("IsActive", true);
            }
            return false;
        }

        _controller = possessionRequester;
        if (AIStateMachine)
        {
            AIStateMachine.SetBool("IsActive", false);
        }
        return true;
    }

    //The controller of this pawn should be the only one calling this method
    public virtual void BecomeUnpossessed()
    {
        _controller = null;
        if (AIStateMachine)
        {
            AIStateMachine.SetBool("IsActive", true);
        }
    }
    #endregion

    #region Action Methods
    //Typical data supplied: The direction the AI should aim in
    public virtual void Movement(Vector2 data)
    {
        //Pass data along to move script
    }

    //Typical data supplied: the direction the AI should aim in
    public virtual void Aiming(Vector2 data)
    {
        //Pass data along to aiming script
    }

    public virtual void UseMovementAbility(bool value)
    {
        if(MovementAbility)
        {
            MovementAbility.UseAbility(this);
        }
    }

    public virtual void UseCombatAbility1(bool value)
    {
        if(CombatAbility1)
        {
            CombatAbility1.UseAbility(this);
        }
    }

    public virtual void UseCombatAbility2(bool value)
    {
        if(CombatAbility2)
        {
            CombatAbility2.UseAbility(this);
        }
    }
    #endregion
}
