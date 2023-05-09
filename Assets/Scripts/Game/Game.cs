using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VIRGroupTestTask.Drawing;
using VIRGroupTestTask.GameCore.States;
using VIRGroupTestTask.Menu;
using VIRGroupTestTask.Player;
using Zenject;

namespace VIRGroupTestTask.GameCore
{
    public class Game : MonoBehaviour
    {
        [SerializeField]
        private List<PlayerFacade> _players;

        private MenuSwitcher _menuSwitcher;
        private LineDrawer _lineDrawer;
        private GameStateMachine _stateMachine;

        [Inject]
        private void Construct(MenuSwitcher menuSwitcher, LineDrawer lineDrawer)
        {
            _menuSwitcher = menuSwitcher;
            _lineDrawer = lineDrawer;
        }

        private void Start()
        {
            _stateMachine = new GameStateMachine(_players, _menuSwitcher, _lineDrawer);
            Play();
        }

        public void Pause() => 
            _stateMachine.Enter<GamePauseState>();

        public void Play() => 
            _stateMachine.Enter<GamePlayState>();

        public void Win() => 
            _stateMachine.Enter<GameWinState>();

        public void Lose() => 
            _stateMachine.Enter<GameLoseState>();

        public void Reload() => 
            _stateMachine.Enter<GameLoadLevelState, int>(SceneManager.GetActiveScene().buildIndex);

        public void PlayNextLevel() => 
            _stateMachine.Enter<GameLoadLevelState, int>(SceneManager.GetActiveScene().buildIndex + 1);

        public void GoToMenu() => 
            _stateMachine.Enter<GameLoadLevelState, int>(0);
    }
}
