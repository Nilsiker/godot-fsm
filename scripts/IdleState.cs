using Godot;
public partial class IdleState : State
{
    public IdleState(StateMachine machine) : base(machine) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Tick(double delta)
    {
        base.Tick(delta);
        if (Input.GetVector("up", "down", "left", "right") != Vector2.Zero)
        {
            _machine.ChangeState(_machine.walkingState);
        }
    }

    public override void PhysicsTick(double delta)
    {
        base.PhysicsTick(delta);
    }

    public override void Exit()
    {
        base.Exit();
    }
}