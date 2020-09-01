using Core.Scene;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SceneManager>()
                .FromComponentInNewPrefab( _sceneManagerPrefab )
                .UnderTransform( transform )
                .AsSingle()
                .NonLazy();

            Container.Bind<DiceRoller>().AsTransient();
        }

        [SerializeField]
        private SceneManager _sceneManagerPrefab;
    }
}
