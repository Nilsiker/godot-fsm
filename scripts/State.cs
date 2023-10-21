using System.Reflection.PortableExecutable;
using Godot;

public abstract class State
{
    private string _name;
    protected StateMachine _machine;

    public State(StateMachine machine)
    {
        _name = GetType().Name;
        _machine = machine;
    }

    public virtual void Enter()
    {
        GD.Print($"Entered {_name}");
    }

    public virtual void Tick(double delta)
    {
        GD.Print($"Ticking {_name}");
    }

    public virtual void PhysicsTick(double delta)
    {
        GD.Print($"Physics ticking {_name}");
    }

    public virtual void Exit()
    {
        GD.Print($"Exiting {_name}");
    }
}