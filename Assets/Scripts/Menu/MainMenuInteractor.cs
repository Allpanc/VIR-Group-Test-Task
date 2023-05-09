using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VIRGroupTestTask
{
    public class MainMenuInteractor : MonoBehaviour
    {
        [SerializeField]
        private Button _playButton;

        void Start() => 
            _playButton.onClick.AddListener(OnPlayButtonClick);

        // «аглушка, чтобы не писать систему сохранений
        private void OnPlayButtonClick() => 
            SceneManager.LoadSceneAsync(1);
    }
}
