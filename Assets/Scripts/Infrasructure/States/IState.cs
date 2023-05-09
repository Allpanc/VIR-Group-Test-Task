using VIRGroupTestTask.Infrastructure.States;

namespace VIRGroupTestTask.Infrastructure
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}