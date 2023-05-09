using System;
using UnityEngine;
using UnityEngine.EventSystems;
using VIRGroupTestTask.Player;

namespace VIRGroupTestTask.WaySystem
{
    public class StartPoint : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public PlayerFacade player;

        public event Action DrawStarted;
        public event Action DrawEnded;

        public void OnPointerDown(PointerEventData eventData) =>
            DrawStarted?.Invoke();

        public void OnPointerUp(PointerEventData eventData) =>
            DrawEnded?.Invoke();
    }
}
