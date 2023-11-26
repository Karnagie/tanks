using Core.Models.Systems;
using Core.Services.Input;
using Infrastructure.Factories;
using Infrastructure.Services.System;
using UnityEngine;
using Zenject;

namespace Core.Models.Services
{
    public class WorldServiceTicker : ITickable, IFixedTickable
    {
        private readonly SystemService _systemService;
        private readonly IInputService _inputService;

        public WorldServiceTicker(SystemService systemService, IInputService inputService)
        {
            _inputService = inputService;
            _systemService = systemService;
        }

        public void Tick()
        {
            _inputService.Tick();
            
            var movers = _systemService.TryFindSystems<IMover>();
            foreach (var mover in movers)
            {
                mover.Move();
            }
            
            var rotators = _systemService.TryFindSystems<IRotator>();
            foreach (var rotator in rotators)
            {
                rotator.Rotate();
            }

            var shooters = _systemService.TryFindSystems<IShooter>();
            foreach (var shooter in shooters)
            {
                shooter.TryShoot();
            }
                
            var weaponChangers = _systemService.TryFindSystems<IWeaponChanger>();
            foreach (var weaponChanger in weaponChangers)
            {
                weaponChanger.TryChange();
            }
            
            var damagers = _systemService.TryFindSystems<IDamager>();
            foreach (var damager in damagers)
            {
                damager.TryDamage();
            }
            
            var destroyers = _systemService.TryFindSystems<IDestroyer>();
            foreach (var destroyer in destroyers)
            {
                destroyer.TryDestroy();
            }
        }

        public void FixedTick()
        {
            var damagers = _systemService.TryFindSystems<IDamager>();
            foreach (var damager in damagers)
            {
                damager.TryDamage();
            }
            
            var destroyers = _systemService.TryFindSystems<IDestroyer>();
            foreach (var destroyer in destroyers)
            {
                destroyer.TryDestroy();
            }
        }
    }
}