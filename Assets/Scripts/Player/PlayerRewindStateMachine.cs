public class PlayerRewindStateMachine : StateMachine
{
    public MovementState movementState;
    public SuspendedState suspendedState;

    private void Awake()
    {
        movementState = new MovementState(this);
        suspendedState = new SuspendedState(this);
        initialState = movementState;
    }

    public void MoveToRewindState()
    {

    }
}