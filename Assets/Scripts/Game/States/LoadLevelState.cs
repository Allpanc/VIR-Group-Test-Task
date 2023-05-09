using UnityEngine.SceneManagement;
using VIRGroupTestTask.Infrastructure;

namespace VIRGroupTestTask.GameCore.States
{
    public class LoadLevelState : IPayloadedState<int>
    {
        public void Enter(int buildIndex)
        {
            if (buildIndex == SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadSceneAsync(buildIndex - 1);
            else
                SceneManager.LoadSceneAsync(buildIndex);
        }

        public void Exit() { }
    }
}
