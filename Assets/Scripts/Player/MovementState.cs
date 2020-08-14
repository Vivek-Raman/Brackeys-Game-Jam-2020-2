public class MovementState : State
{
    private Movement movement = null;

    public MovementState(StateMachine source) : base(source)
    {
        movement = source.GetComponent<Movement>();
    }

    public override void OnStateEnter()
    {
        movement.enabled = true;
    }

    public override void OnStateExit()
    {
        movement.enabled = false;
    }
}