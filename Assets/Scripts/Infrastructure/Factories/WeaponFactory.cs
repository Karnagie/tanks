﻿using Core.Models;
using Core.Models.Systems;
using Infrastructure.Services.Binding;
using Infrastructure.Services.System;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class WeaponFactory
    {
        private ViewFactory _viewFactory;
        private BinderFactory _binderFactory;
        private WeaponSystemsFactory _weaponSystemsFactory;
        private SystemService _systemService;

        public WeaponFactory(
            ViewFactory viewFactory, 
            BinderFactory binderFactory, 
            WeaponSystemsFactory weaponSystemsFactory, 
            SystemService systemService)
        {
            _viewFactory = viewFactory;
            _binderFactory = binderFactory;
            _weaponSystemsFactory = weaponSystemsFactory;
            _systemService = systemService;
        }

        public void CreateDefaultWeapon(Transform parent, Unit owner)
        {
            var behaviour = _viewFactory.DefaultWeapon(parent);
            var weapon = new DefaultWeapon(
                behaviour.BulletSpawnPoint,
                owner.Fraction);
            var binder = _binderFactory.Create();
            var linker = new SystemLinker();
            
            //components
            var shooter = _weaponSystemsFactory.Shooter(weapon);
            
            linker.Add(owner);
            linker.Add(weapon);
            linker.Add(shooter);
            
            LinkDisposing(binder, linker, owner, behaviour);
        }
        
        private void LinkDisposing(Binder binder, SystemLinker linker, Unit owner, MonoBehaviour behaviour)
        {
            binder.LinkHolder(_systemService, linker);
            binder.LinkEvent(owner.Killed, binder.Dispose);
            binder.LinkEvent(owner.Killed, (() => Object.Destroy(behaviour.gameObject)));
        }
    }
}