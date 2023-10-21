using System.Collections.Generic;
using System.Linq;
using Godot;
using Project.Core;

namespace Project.FSM.Control
{
    [GlobalClass]
    public partial class StateMachine : Node, ILocator<IState>, ILocator
    {
        [Export] private Node _systems;
        private List<IState> _states;
        private IState DefaultState => (this as ILocator<IState>).Get<IdleState>();
        private IState _currentState;

        public override void _Ready()
        {
            _states = new List<IState> {
                new IdleState(this, this),
                new WalkingState(this, this)
            };

            ChangeState(DefaultState); // initial state
        }

        public override void _Process(double delta)
        {
            var newState = _currentState.Tick(delta);
            if(newState != null) {
                ChangeState(newState);
            }
        }

        public override void _PhysicsProcess(double delta)
        {
            var newState = _currentState.PhysicsTick(delta);
            if (newState != null)
            {
                ChangeState(newState);
            }
        }

        // Switches to a new state, if it is different from the current state.
        private void ChangeState(IState newState)
        {
            if (newState == _currentState) return;
            _currentState?.Exit();   // perform exit logic on current state
            _currentState = newState;   // switch to new state
            _currentState.Enter();   // perform enter logic on new state!
        }

        T ILocator<IState>.Get<T>()
        {
            return _states.OfType<T>().FirstOrDefault();
        }

        T ILocator.Get<T>()
        {
            return _systems.GetChildren().OfType<T>().FirstOrDefault();
        }
    }
}
