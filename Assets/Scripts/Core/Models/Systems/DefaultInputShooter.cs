using Core.Services;
using Core.Services.Input;
using Infrastructure.Factories;
using UnityEngine;

namespace Core.Models.Systems
{
    public class DefaultInputShooter : IShooter
    {
        private const float Cooldown = 0.1f;
        
        private readonly IWeapon _weapon;
        private readonly ShootService _shootService;
        private readonly IInputService _inputService;
        
        private float _nextShotTime;

        public DefaultInputShooter(
            IWeapon weapon, 
            ShootService shootService,
            IInputService inputService)
        {
            _inputService = inputService;
            _shootService = shootService;
            _weapon = weapon;
        }
        
        public void TryShoot()
        {
            if(Time.time < _nextShotTime)
                return;
            
            if(_inputService.Attack)
            {
                _shootService.Shoot(_weapon.BulletSpawnPoint, _weapon);
                _nextShotTime = Time.time + Cooldown;
            }
        }
    }
}