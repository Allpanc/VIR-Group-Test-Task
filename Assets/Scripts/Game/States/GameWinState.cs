using UnityEngine;
using VIRGroupTestTask.Infrastructure;
using VIRGroupTestTask.Menu;

namespace VIRGroupTestTask.GameCore.States
{
    public class GameWinState : IState
    {
        private MenuSwitcher _menuSwitcher;

        public GameWinState(MenuSwitcher menuSwitcher) => 
            _menuSwitcher = menuSwitcher;

        public void Enter()
        {
            _menuSwitcher.ShowVictoryMenu();
            Time.timeScale = 0;
        }

        public void Exit() =>
            Time.timeScale = 1;
    }
}
