using UnityEngine;
using UnityEngine.UI;

namespace VIRGroupTestTask.Menu
{
    public class RuntimeMenuInteractor : MenuInteractor
    {
        [SerializeField] 
        private Button _pauseButton;

        [SerializeField]
        private Button _restartButton;

        void Start()
        {
            _pauseButton.onClick.AddListener(OnPauseButtonClicked);
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void OnPauseButtonClicked() => 
            _game.Pause();

        private void OnRestartButtonClicked() =>
            _game.Reload();
    }
}
