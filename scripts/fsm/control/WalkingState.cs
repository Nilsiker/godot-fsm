using Godot;
using Project.Core;

using Project.Motion;

namespace Project.FSM.Control {
    public partial class WalkingState : State
    {
        IMover mover;
        IAppearanceChanger appearance;

        public WalkingState(ILocator<IState> states, ILocator systems) 
        : base(states) 
        {
            mover = systems.Get<IMover>();
            appearance = systems.Get<IAppearanceChanger>();
        }

        public override void Enter()
        {
            base.Enter();
            appearance.ChangeColor(new Color(1,0,0));
        }

        public override IState Tick(double delta)
        {
            IState stateFromBase = base.Tick(delta);

            return Input.GetVector("left", "right", "up", "down") == Vector2.Zero
                ? states.Get<IdleState>()
                : stateFromBase;
        }

        public override IState PhysicsTick(double delta)
        {
            Vector2 direction = Input.GetVector("left", "right", "up", "down");
            mover.Move(direction);

            return base.PhysicsTick(delta); ;
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
