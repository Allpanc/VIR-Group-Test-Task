namespace VIRGroupTestTask.Player.States
{
    public class PlayerStateMachine
    {
        private BaseState _currentState;

        private IdleState _idleState;
        private RunningState _runningState;

        public PlayerStateMachine(PlayerMove playerMove, PlayerAnimator playerAnimator)
        {
            _idleState = new IdleState(playerMove, playerAnimator);
            _runningState = new RunningState(playerMove, playerAnimator);
        }

        public void SetState(PlayerState state)
        {
            if (_currentState != null)
                _currentState.Exit();

            switch (state)
            {
                case PlayerState.Idle:
                    _currentState = _idleState;
                    break;
                case PlayerState.Running:
                    _currentState = _runningState;
                    break;
            }

            _currentState.Enter();
        }
    }
}