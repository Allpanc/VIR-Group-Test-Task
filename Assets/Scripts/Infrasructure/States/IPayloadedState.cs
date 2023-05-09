using VIRGroupTestTask.Infrastructure.States;

namespace VIRGroupTestTask.Infrastructure
{
    public interface IPayloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}