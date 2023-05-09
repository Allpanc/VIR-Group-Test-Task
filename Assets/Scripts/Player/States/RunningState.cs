namespace VIRGroupTestTask.Player.States
{
    public class RunningState : BaseState
    {
        private PlayerAnimator _animator;
        private PlayerMove _playerMove;

        public RunningState(PlayerMove playerMove, PlayerAnimator animator)
        {
            _playerMove = playerMove;
            _animator = animator;
        }

        public override void Enter()
        {
            base.Enter();

            _animator.PlayRun();
            _playerMove.Allow();
        }
    }
}