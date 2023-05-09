using UnityEngine;

namespace VIRGroupTestTask.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private const string Running = "isRunning";

        private Animator _animator;

        private void Awake() =>
            _animator = GetComponent<Animator>();

        public void PlayIdle() =>
            _animator.SetBool(Running, false);

        public void PlayRun() =>
            _animator.SetBool(Running, true);
    }
}
