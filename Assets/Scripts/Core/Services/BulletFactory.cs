using Core.Models.Systems;
using Infrastructure.Factories;
using Infrastructure.Services.Binding;
using Infrastructure.Services.System;
using UnityEngine;

namespace Core.Services
{
    public class BulletFactory
    {
        private const float BulletSpeed = 100f;
        
        private readonly ViewFactory _viewFactory;
        private BinderFactory _binderFactory;
        private SystemService _systemService;
        private ServiceSystemFactory _serviceSystemFactory;

        public BulletFactory(
            ViewFactory viewFactory, 
            BinderFactory binderFactory, 
            SystemService systemService, 
            ServiceSystemFactory serviceSystemFactory)
        {
            _viewFactory = viewFactory;
            _binderFactory = binderFactory;
            _systemService = systemService;
            _serviceSystemFactory = serviceSystemFactory;
        }

        public void CreateDefaultBullet(Transform spawnPoint, IWeapon weapon)
        {
            var behaviour = _viewFactory.DefaultBullet(spawnPoint);
            var bullet = new DefaultBullet(
                behaviour.Transform,
                weapon.Fraction);
            var binder = _binderFactory.Create();
            var linker = new SystemLinker();
            
            //components
            var mover = _serviceSystemFactory.ForwardMover(bullet.Transform, BulletSpeed);
            
            linker.Add(bullet);
            linker.Add(weapon);
            linker.Add(mover);
            
            LinkDisposing(binder, linker, weapon, behaviour);
        }
        
        private void LinkDisposing(Binder binder, SystemLinker linker, IWeapon weapon, MonoBehaviour behaviour)
        {
            binder.LinkHolder(_systemService, linker);
            binder.LinkEvent(weapon.Destroyed, binder.Dispose);
            binder.LinkEvent(weapon.Destroyed, (() => Object.Destroy(behaviour.gameObject)));
        }
    }
}