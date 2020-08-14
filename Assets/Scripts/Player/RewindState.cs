public class RewindState : State
{
    private RewindTracker rewinder = null;

    public RewindState(StateMachine source) : base(source)
    {

    }

    public override void OnStateEnter()
    {
        rewinder.Rewind();
    }

    public override void OnStateTick()
    {
        base.OnStateTick();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}