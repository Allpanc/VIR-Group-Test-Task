using UnityEngine;

namespace VIRGroupTestTask.Menu
{
    [RequireComponent(typeof(Canvas))]
    public class MenuDisplay : MonoBehaviour
    {
        [SerializeField] 
        private MenuType _menuType;

        [SerializeField]
        private Canvas _canvas;

        public MenuType MenuType { get => _menuType; }

        public virtual void ShowContent() => 
            _canvas.enabled = true;

        public virtual void HideContent() => 
            _canvas.enabled = false;
    }
}
