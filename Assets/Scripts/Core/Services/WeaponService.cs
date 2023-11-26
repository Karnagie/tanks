using Core.Models;
using Core.Models.Systems;
using Infrastructure.Factories;
using Infrastructure.Services.Binding;
using Infrastructure.Services.System;
using UnityEngine;

namespace Core.Services
{
    public class WeaponService
    {
        private readonly SystemService _systemService;

        public WeaponService(SystemService systemService)
        {
            _systemService = systemService;
        }

        public void DestroyAllWeapons(Unit unit)
        {
            var unitFilter = new Filter<Unit>((unit1 => unit1 == unit));
            var weapons = _systemService.TryFindSystems<IWeapon>(unitFilter);
            foreach (var weapon in weapons)
            {
                weapon.Destroy();
            }
        }
    }
}