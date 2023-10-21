
namespace Project.FSM {
    public interface IState
    {
        void Enter();
        IState Tick(double delta);
        IState PhysicsTick(double delta);
        void Exit();
    }
}
