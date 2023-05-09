using VIRGroupTestTask.Infrastructure;

namespace VIRGroupTestTask.Player.States
{
    public abstract class BaseState : IState
    {
        public virtual void Enter() { }

        public virtual void Exit() { }
    }
}