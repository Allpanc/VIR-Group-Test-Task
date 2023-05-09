using UnityEngine;

namespace VIRGroupTestTask.Infrastructure.InputSystem
{
    public interface IInputService
    {
        Vector3 ClickPosition();

        bool Pressed();

        bool Moved();
    }
}
