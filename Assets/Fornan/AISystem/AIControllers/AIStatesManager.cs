using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStatesManager : StatesManager {

    public AIManager myAIManager;

    protected override void Update()
    {
        AIState ais = currentState as AIState;
        if(ais && myAIManager)
        {
            if(ais.myAIManager != myAIManager)
            {
                ais.myAIManager = myAIManager;
            }
        }
        base.Update();
    }

    public override void DoTransition(State state)
    {
        AIState aisCurrent = currentState as AIState;
        AIState aisNew = state as AIState;
        if (aisCurrent && myAIManager)
        {
            if (aisCurrent.myAIManager != myAIManager)
            {
                aisCurrent.myAIManager = myAIManager;
            }
        }
        else if(aisNew && myAIManager)
        {
            if (aisNew.myAIManager != myAIManager)
            {
                aisNew.myAIManager = myAIManager;
            }
        }
        base.DoTransition(state);
    }
}
