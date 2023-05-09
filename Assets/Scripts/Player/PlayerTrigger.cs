using System;
using UnityEngine;

namespace VIRGroupTestTask.Player
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerTrigger : MonoBehaviour
    {
        public PlayerType Type { get; set; }

        public event Action<Collider2D> Collided;

        private void OnTriggerEnter2D(Collider2D collision) =>
            Collided?.Invoke(collision);
    }
}
