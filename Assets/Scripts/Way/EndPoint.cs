using UnityEngine;
using UnityEngine.EventSystems;
using VIRGroupTestTask.Player;

namespace VIRGroupTestTask.WaySystem
{
    public class EndPoint : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public PlayerType Type;

        public bool IsActive { get; private set; }
        public bool IsOccupied { get; set; }

        public void OnPointerEnter(PointerEventData eventData) =>
            SetIsActiveTo(true);

        public void OnPointerExit(PointerEventData eventData) =>
            SetIsActiveTo(false);

        private void SetIsActiveTo(bool state)
        {
            if (IsActive == state)
                return;

            IsActive = state;
        }
    }
}
