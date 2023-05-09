using UnityEngine;
using UnityEngine.UI;
using VIRGroupTestTask.GameCore;
using Zenject;

namespace VIRGroupTestTask.Menu
{
    public class VictoryMenuInteractor : MenuInteractor
    {
        [SerializeField] 
        private Button _restartButton;

        [SerializeField]
        private Button _menuButton;

        [SerializeField]
        private Button _nextLevelButton;

        void Start()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
            _menuButton.onClick.AddListener(OnMenuButtonClicked);
            _nextLevelButton.onClick.AddListener(OnNextLevelButtonClicked);
        }

        private void OnRestartButtonClicked() => 
            _game.Reload();

        private void OnNextLevelButtonClicked() => 
            _game.PlayNextLevel();

        private void OnMenuButtonClicked() =>
            _game.GoToMenu();
    }
}
