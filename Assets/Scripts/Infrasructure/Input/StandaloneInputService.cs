using UnityEngine;

namespace VIRGroupTestTask.Infrastructure.InputSystem
{
    public class StandaloneInputService : IInputService
    {
        private Camera _camera;

        public StandaloneInputService(Camera camera) => 
            _camera = camera;

        public Vector3 ClickPosition() =>
            _camera.ScreenToWorldPoint(Input.mousePosition);

        public bool Moved() =>
            Input.GetMouseButton(0);

        public bool Pressed() =>
            Input.GetMouseButtonDown(0);
    }
}
