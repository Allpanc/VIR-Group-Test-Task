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

        // ��������, ����� �� ������ ������� ����������
        private void OnPlayButtonClick() => 
            SceneManager.LoadSceneAsync(1);
    }
}
