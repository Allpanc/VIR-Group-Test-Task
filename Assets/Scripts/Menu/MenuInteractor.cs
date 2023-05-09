using UnityEngine;
using VIRGroupTestTask.GameCore;
using Zenject;

namespace VIRGroupTestTask.Menu
{
    public class MenuInteractor : MonoBehaviour
    {
        protected Game _game;
        protected MenuSwitcher _menuSwitcher;

        [Inject]
        private void Construct(Game game, MenuSwitcher menuSwitcher)
        {
            _game = game;
            _menuSwitcher = menuSwitcher;
        }
    }
}
