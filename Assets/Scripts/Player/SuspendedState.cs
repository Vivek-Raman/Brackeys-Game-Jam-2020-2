using UnityEngine;

public class SuspendedState : State
{
    private float suspendDuration = 1f;
    private float suspendStartTime = 0f;

    public SuspendedState(StateMachine source) : base(source)
    {
    }

    public override void OnStateEnter()
    {
        suspendStartTime = Time.time;
    }

    public override void OnStateTick()
    {
        if (Time.time >= suspendStartTime + suspendDuration)
        {
            (source as PlayerRewindStateMachine).MoveToRewindState();
        }
    }
}