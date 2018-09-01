using UnityEngine;
using UnityEngine.Events;
public class EventStateMachine : StateMachineBehaviour {
    public UnityEvent _onStateEnter;
    public UnityEvent _onStateExit;
    public UnityEvent _onStateStay;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        _onStateEnter.Invoke();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        _onStateStay.Invoke();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        _onStateExit.Invoke();
    }
}
