using System.Reflection.PortableExecutable;
using Godot;
using Project.Core;
using Project.Systems;

namespace Project.FSM.Control {
    public abstract class State : IState
    {
        private string _name;
        protected ILocator<IState> states;

        public State(ILocator<IState> states)
        {
            _name = GetType().Name;
            this.states = states;
        }

        public virtual void Enter()
        {
            GD.Print($"Entered {_name}");
        }

        public virtual IState Tick(double delta)
        {
            GD.Print($"Ticking {_name}");
            return null;
        }

        public virtual IState PhysicsTick(double delta)
        {
            GD.Print($"Physics ticking {_name}");
            return null;
        }

        public virtual void Exit()
        {
            GD.Print($"Exiting {_name}");
        }
    }
}
