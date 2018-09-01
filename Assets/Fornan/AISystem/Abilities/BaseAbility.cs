using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility : ScriptableObject {

    //If you feel the need to change these parameters, that's fine but just let Fornan know.
    public abstract bool UseAbility(Pawn user);
}
