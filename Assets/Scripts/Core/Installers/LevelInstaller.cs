using Route;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<RouteManager>()
                .FromInstance(_routeManager)
                .AsSingle();
        }

        [SerializeField]
        private RouteManager _routeManager;
    }
}