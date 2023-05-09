using UnityEngine;

namespace VIRGroupTestTask.Infrastructure.InputSystem
{
    public class MobileInputService : IInputService
    {
        private Camera _camera;

        public MobileInputService(Camera camera) => 
            _camera = camera;

        public Vector3 ClickPosition() =>
            _camera.ScreenToWorldPoint(Input.GetTouch(0).position);

        public bool Moved() =>
            Input.GetTouch(0).phase == TouchPhase.Moved;

        public bool Pressed() =>
            Input.GetTouch(0).phase == TouchPhase.Began;
    }
}
