using Core.Models.Services;
using Core.Services;
using Core.Services.Input;
using Infrastructure.AssetManagement;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Services.Binding;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Physics;
using Infrastructure.Services.System;
using Infrastructure.Services.Ticking;
using Infrastructure.States;
using Zenject;

namespace Infrastructure.DI
{
    public class GameInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            //Infrastructure
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<SceneLoader>().To<SceneLoader>().AsSingle();

            Container.Bind<GameStateMachine>().AsSingle();
            Container.BindInterfacesTo<BootstrapState>().AsSingle();
            Container.BindInterfacesTo<GameLoopState>().AsSingle();
            Container.BindInterfacesTo<LoadLevelState>().AsSingle();
            Container.BindInterfacesTo<MenuState>().AsSingle();

            Container.Bind<MainMenuBinder>().AsSingle();

            //Services
            Container.BindInterfacesAndSelfTo<TickService>().AsSingle();
            Container.BindInterfacesTo<StandaloneInputService>().AsSingle();
            Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
            Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
            Container.Bind<SystemService>().AsSingle();
            Container.Bind<BinderService>().AsSingle();
            Container.Bind<WindowsService>().AsSingle();
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
            Container.BindInterfacesAndSelfTo<WorldServices>().AsSingle();
            Container.Bind<ShootService>().AsSingle();

            //Factories
            Container.Bind<UnitFactory>().AsSingle();
            Container.Bind<ViewFactory>().AsSingle();
            Container.Bind<ServiceSystemFactory>().AsSingle();
            Container.Bind<BinderFactory>().AsSingle();
            Container.Bind<WeaponFactory>().AsSingle();
            Container.Bind<BulletFactory>().AsSingle();
            Container.Bind<WeaponSystemsFactory>().AsSingle();
        }
    }
}