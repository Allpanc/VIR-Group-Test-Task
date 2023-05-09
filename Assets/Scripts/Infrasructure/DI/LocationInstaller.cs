using UnityEngine;
using VIRGroupTestTask.Drawing;
using VIRGroupTestTask.GameCore;
using VIRGroupTestTask.Infrastructure.InputSystem;
using VIRGroupTestTask.Menu;
using Zenject;

namespace VIRGroupTestTask.Infrastructure.DI
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField]
        private LineDrawer LineDrawer;

        [SerializeField]
        private Game Game;
        
        [SerializeField]
        private MenuSwitcher MenuSwitcher;

        private AssetProvider _assetProvider =  new AssetProvider();
        
        public override void InstallBindings()
        {
            BindServices();
            BindLineDrawer();
            BindGame();
            BindMenuSwitcher();
        }

        private void BindMenuSwitcher()
        {
            Container
                .Bind<MenuSwitcher>()
                .FromInstance(MenuSwitcher)
                .AsSingle();
        }

        private void BindGame()
        {
            Container
                .Bind<Game>()
                .FromInstance(Game)
                .AsSingle();
        }

        private void BindLineDrawer()
        {
            Container
                .Bind<LineDrawer>()
                .FromInstance(LineDrawer)
                .AsSingle();
        }

        private void BindServices()
        {
            BindFactory();
            BindInput();
        }

        private void BindFactory()
        {
            Container
                .Bind<GameFactory>()
                .To<GameFactory>()
                .AsSingle();
        }

        private void BindInput()
        {
            Container
                .Bind<IInputService>()
                .FromInstance(InputService())
                .AsSingle();
        }

        private IInputService InputService() =>
            Application.isEditor
                ? new StandaloneInputService(Camera.main)
                : new MobileInputService(Camera.main);
    }
}
