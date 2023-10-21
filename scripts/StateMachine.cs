using Godot;

[GlobalClass]
public partial class StateMachine : Node
{
    public IdleState idleState;
    public WalkingState walkingState;

    [Export] public Mover mover;

    private State _currentState;

    public override void _Ready()
    {
        idleState = new IdleState(this);
        walkingState = new WalkingState(this);

        ChangeState(idleState); // initial state
    }

    public override void _Process(double delta)
    {
        _currentState.Tick(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        _currentState.PhysicsTick(delta);
    }

    // Switches to a new state, if it is different from the current state.
    public void ChangeState(State newState)
    {
        if (newState == _currentState) return;
        _currentState?.Exit();   // perform exit logic on current state
        _currentState = newState;   // switch to new state
        _currentState.Enter();   // perform enter logic on new state!
    }
}