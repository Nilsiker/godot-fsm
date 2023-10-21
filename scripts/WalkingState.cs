using Godot;
public partial class WalkingState : State
{
    public WalkingState(StateMachine machine) : base(machine) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Tick(double delta)
    {
        base.Tick(delta);
        if (Input.GetVector("left", "right", "up", "down") == Vector2.Zero)
        {
            _machine.ChangeState(_machine.idleState);
        }
    }

    public override void PhysicsTick(double delta)
    {
        base.PhysicsTick(delta);
        Vector2 direction = Input.GetVector("left", "right", "up", "down");
        _machine.mover.Move(direction);
    }

    public override void Exit()
    {
        base.Exit();
    }
}