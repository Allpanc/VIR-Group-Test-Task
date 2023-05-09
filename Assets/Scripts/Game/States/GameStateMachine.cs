using System;
using System.Collections.Generic;
using VIRGroupTestTask.Drawing;
using VIRGroupTestTask.Infrastructure;
using VIRGroupTestTask.Infrastructure.States;
using VIRGroupTestTask.Menu;
using VIRGroupTestTask.Player;
using VIRGroupTestTask.WaySystem;

namespace VIRGroupTestTask.GameCore.States
{
    public class GameStateMachine
    {
        private IExitableState _currentState;

        private readonly Dictionary<Type, IExitableState> _states;

        public GameStateMachine(List<PlayerFacade> players, MenuSwitcher menuSwitcher, LineDrawer lineDrawer)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(PlayState)] = new PlayState(this, players, new FinishChecker(players), menuSwitcher, lineDrawer, new MoveStarter(lineDrawer, players)),
                [typeof(WinState)] = new WinState(menuSwitcher),
                [typeof(LoseState)] = new LoseState(menuSwitcher),
                [typeof(PauseState)] = new PauseState(menuSwitcher),
                [typeof(LoadLevelState)] = new LoadLevelState(),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();

            TState state = GetState<TState>();
            _currentState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}
