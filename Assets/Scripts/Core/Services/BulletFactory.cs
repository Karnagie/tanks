using Core.Models.Systems;
using Infrastructure.Factories;
using Infrastructure.Services.Binding;
using Infrastructure.Services.System;
using UnityEngine;

namespace Core.Services
{
    public class BulletFactory
    {
        private const float BulletSpeed = 20f;
        
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
                weapon.Fraction,
                behaviour.Collider);
            var binder = _binderFactory.Create();
            var linker = new SystemLinker();
            
            //components
            var mover = _serviceSystemFactory.ForwardMover(bullet.Transform, BulletSpeed);
            var damager = _serviceSystemFactory.DamagerOnCollision(bullet.Fraction, bullet.Collider, weapon.Damage);
            var destroyed = _serviceSystemFactory.DestroyerOnCollision(bullet.Collider, bullet);
            
            linker.Add(bullet);
            linker.Add(weapon);
            linker.Add(mover);
            linker.Add(destroyed);
            linker.Add(damager);
            
            LinkDisposing(binder, linker);
            binder.LinkEvent(bullet.Destroyed, binder.Dispose);
            binder.LinkEvent(bullet.Destroyed, (() => Object.Destroy(behaviour.gameObject)));
        }
        
        private void LinkDisposing(Binder binder, SystemLinker linker)
        {
            binder.LinkHolder(_systemService, linker);
        }
    }
}