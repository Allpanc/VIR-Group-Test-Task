using UnityEngine;
using UnityEngine.UI;

namespace VIRGroupTestTask.Menu
{
    public class LossMenuInteractor : MenuInteractor
    {
        [SerializeField] 
        private Button _restartButton;

        [SerializeField]
        private Button _menuButton;

        void Start()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
            _menuButton.onClick.AddListener(OnMenuButtonClicked);
        }

        private void OnMenuButtonClicked() => 
            _game.GoToMenu();

        private void OnRestartButtonClicked() => 
            _game.Reload();
    }
}
