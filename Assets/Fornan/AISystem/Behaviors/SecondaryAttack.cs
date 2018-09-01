using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryAttack : StateMachineBehaviour {

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        Pawn _controlledPawn = animator.GetComponent<Pawn>();
        if(_controlledPawn)
        {
            _controlledPawn.UseCombatAbility2(true);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Pawn _controlledPawn = animator.GetComponent<Pawn>();
        if (_controlledPawn)
        {
            _controlledPawn.UseCombatAbility2(false);
        }
    }
}
