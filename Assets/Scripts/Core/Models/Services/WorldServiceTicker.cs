using Core.Models.Systems;
using Infrastructure.Factories;
using Infrastructure.Services.System;
using UnityEngine;
using Zenject;

namespace Core.Models.Services
{
    public class WorldServiceTicker : ITickable, IFixedTickable
    {
        private SystemService _systemService;

        public WorldServiceTicker(SystemService systemService)
        {
            _systemService = systemService;
        }

        public void Tick()
        {
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
            
            var destroyers = _systemService.TryFindSystems<IDestroyer>();
            foreach (var destroyer in destroyers)
            {
                destroyer.TryDestroy();
            }
            
            var weaponChangers = _systemService.TryFindSystems<IWeaponChanger>();
            foreach (var weaponChanger in weaponChangers)
            {
                weaponChanger.TryChange();
            }
        }

        public void FixedTick()
        {
            
        }
    }
}