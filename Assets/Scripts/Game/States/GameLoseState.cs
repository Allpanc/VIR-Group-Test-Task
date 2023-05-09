using UnityEngine;
using VIRGroupTestTask.Infrastructure;
using VIRGroupTestTask.Menu;

namespace VIRGroupTestTask.GameCore.States
{
    public class GameLoseState : IState
    {
        private MenuSwitcher _menuSwitcher;

        public GameLoseState(MenuSwitcher menuSwitcher) => 
            _menuSwitcher = menuSwitcher;

        public void Enter()
        {
            _menuSwitcher.ShowLossMenu();
            Time.timeScale = 0;
        }

        public void Exit() =>
            Time.timeScale = 1;
    }
}
