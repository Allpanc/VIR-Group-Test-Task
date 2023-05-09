using System.Collections.Generic;
using UnityEngine;
using VIRGroupTestTask.Drawing;
using VIRGroupTestTask.Infrastructure;
using VIRGroupTestTask.Menu;
using VIRGroupTestTask.Player;
using VIRGroupTestTask.WaySystem;

namespace VIRGroupTestTask.GameCore.States
{
    public class PlayState : IState
    {
        private GameStateMachine _stateMachine;

        private List<PlayerFacade> _players;

        private FinishChecker _finishChecker;
        private MenuSwitcher _menuSwitcher;
        private LineDrawer _lineDrawer;
        private MoveStarter _moveStarter;

        public PlayState(GameStateMachine stateMachine, List<PlayerFacade> players, FinishChecker finishCkecker, MenuSwitcher menuSwitcher, LineDrawer lineDrawer, MoveStarter moveStarter)
        {
            _stateMachine = stateMachine;
            _players = players;
            _finishChecker = finishCkecker;
            _menuSwitcher = menuSwitcher;
            _lineDrawer = lineDrawer;
            _moveStarter = moveStarter;
        }

        public void Enter()
        {
            _menuSwitcher.ShowRuntimeMenu();

            _lineDrawer.enabled = true;
            _moveStarter.SubscribeToDrawEvents();

            foreach (PlayerFacade player in _players)
                player.TriggerZone.Collided += CheckForLoss;

            _finishChecker.Finished += Victory;
        }

        public void Exit()
        {
            _lineDrawer.enabled = false;
            _moveStarter.UnsubscribeFromDrawEvents();

            foreach (PlayerFacade player in _players)
                player.TriggerZone.Collided -= CheckForLoss;
        }

        private void CheckForLoss(Collider2D collision)
        {
            if (collision.GetComponent<PlayerFacade>() != null
                || collision.GetComponent<Obstacle>() != null)
                Loss();
        }

        private void Victory() =>
            _stateMachine.Enter<WinState>();

        private void Loss() =>
            _stateMachine.Enter<LoseState>();
    }
}
