namespace VIRGroupTestTask.Player.States
{
    public class IdleState : BaseState
    {
        private PlayerMove _playerMove;
        private PlayerAnimator _animator;

        public IdleState(PlayerMove playerMove, PlayerAnimator animator)
        {
            _playerMove = playerMove;
            _animator = animator;
        }

        public override void Enter()
        {
            base.Enter();

            _playerMove.Stop();
            _animator.PlayIdle();
        }
    }
}