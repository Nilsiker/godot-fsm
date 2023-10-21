using Godot;
using Project.Core;
using Project.Systems;

namespace Project.FSM.Control
{
    public partial class IdleState : State
    {
        private IAppearanceChanger _appearance;

        public IdleState(ILocator<IState> states, ILocator systems) : base(states)
        {
            _appearance = systems.Get<IAppearanceChanger>();
        }

        public override void Enter()
        {
            base.Enter();
            _appearance.ChangeColor(new Color(0, 0, 1));
        }

        public override IState Tick(double delta)
        {
            var stateFromBase = base.Tick(delta);

            return Input.GetVector("up", "down", "left", "right") != Vector2.Zero
                ? states.Get<WalkingState>()
                : stateFromBase;
        }

        public override IState PhysicsTick(double delta)
        {
            return base.PhysicsTick(delta);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
