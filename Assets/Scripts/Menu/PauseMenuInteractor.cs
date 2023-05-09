using UnityEngine;
using UnityEngine.UI;

namespace VIRGroupTestTask.Menu
{
    public class PauseMenuInteractor : MenuInteractor
    {
        [SerializeField] 
        private Button _restartButton;

        [SerializeField]
        private Button _continueButton;

        void Start()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
            _continueButton.onClick.AddListener(OnContinueButtonClicked);
        }

        private void OnRestartButtonClicked() => 
            _game.Reload();

        private void OnContinueButtonClicked() => 
            _game.Play();
    }
}
