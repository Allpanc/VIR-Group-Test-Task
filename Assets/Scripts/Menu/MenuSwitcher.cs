using System.Collections.Generic;
using UnityEngine;

namespace VIRGroupTestTask.Menu
{
    public class MenuSwitcher : MonoBehaviour
    {
        [SerializeField]
        private List<MenuDisplay> _menus;

        public void ShowPauseMenu() => 
            ShowMenu(MenuType.Pause);

        public void ShowVictoryMenu() => 
            ShowMenu(MenuType.Victory);

        public void ShowLossMenu() => 
            ShowMenu(MenuType.Loss);

        public void ShowRuntimeMenu() => 
            ShowMenu(MenuType.Runtime);

        public void ShowMenu(MenuType menuType)
        {
            _menus.ForEach(x => x.HideContent());
            MenuDisplay menu = _menus.Find(x => x.MenuType == menuType);
            menu.ShowContent();
        }
    }
}
