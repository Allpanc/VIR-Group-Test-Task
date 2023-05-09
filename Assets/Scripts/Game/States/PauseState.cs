using UnityEngine;
using VIRGroupTestTask.Infrastructure;
using VIRGroupTestTask.Menu;

namespace VIRGroupTestTask.GameCore.States
{
    public class PauseState : IState
    {
        private MenuSwitcher _menuSwitcher;

        public PauseState(MenuSwitcher menuSwitcher) => 
            _menuSwitcher = menuSwitcher;

        public void Enter()
        {
            Time.timeScale = 0;
            _menuSwitcher.ShowPauseMenu();
        }

        public void Exit() =>
            Time.timeScale = 1;
    }
}
