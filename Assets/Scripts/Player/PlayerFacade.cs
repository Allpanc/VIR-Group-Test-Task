using UnityEngine;
using VIRGroupTestTask.Player.States;

namespace VIRGroupTestTask.Player
{
    [RequireComponent(typeof(PlayerMove))]
    [RequireComponent(typeof(PlayerAnimator))]
    [RequireComponent(typeof(PlayerTrigger))]
    public class PlayerFacade : MonoBehaviour
    {
        public PlayerType Type;

        public PlayerMove Movement { get; private set; }
        public PlayerAnimator Animator { get; private set; }
        public PlayerTrigger TriggerZone { get; private set; }

        private PlayerStateMachine _stateMachine;

        private void Awake()
        {
            Movement = GetComponent<PlayerMove>();
            Animator = GetComponent<PlayerAnimator>();
            TriggerZone = GetComponent<PlayerTrigger>();
        }

        private void Start()
        {
            _stateMachine = new PlayerStateMachine(Movement, Animator);

            Idle();
        }

        public void Idle() =>
            _stateMachine.SetState(PlayerState.Idle);

        public void Run() =>
            _stateMachine.SetState(PlayerState.Running);

        public void SetWay() =>
            Movement.SetWay();
    }
}
