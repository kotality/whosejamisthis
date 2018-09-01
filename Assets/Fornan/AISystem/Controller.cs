using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    #region Variables
    protected Pawn _possessedPawn;
    public Pawn PossessedPawn { get { return _possessedPawn; } }
    #endregion

    #region Possession
    public virtual void PossessPawn(Pawn newPawn)
    {
        UnpossessPawn();
        if(newPawn.BecomePossessed(this))
        {
            _possessedPawn = newPawn;
        }
    }
    #endregion

    public virtual void UnpossessPawn()
    {
        if(!_possessedPawn) { return; }

        _possessedPawn.BecomeUnpossessed();
        _possessedPawn = null;
    }

    private void OnValidate()
    {
        
    }

    #region Tell pawn actions
    public virtual void Movement(Vector2 data)
    {
        if(_possessedPawn)
        {
            _possessedPawn.Movement(data);
        }
    }

    public virtual void Aiming(Vector2 data)
    {
        if (_possessedPawn)
        {
            _possessedPawn.Aiming(data);
        }
    }

    public virtual void MovementAbility(bool value)
    {
        if (_possessedPawn)
        {
            _possessedPawn.UseMovementAbility(value);
        }
    }

    public virtual void CombatAbility1(bool value)
    {
        if (_possessedPawn)
        {
            _possessedPawn.UseCombatAbility1(value);
        }
    }

    public virtual void CombatAbility2(bool value)
    {
        if (_possessedPawn)
        {
            _possessedPawn.UseCombatAbility2(value);
        }
    }
    #endregion
}
