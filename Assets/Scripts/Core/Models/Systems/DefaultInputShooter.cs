using Core.Services;
using Core.Services.Input;
using Infrastructure.Factories;

namespace Core.Models.Systems
{
    public class DefaultInputShooter : IShooter
    {
        private readonly IWeapon _weapon;
        private readonly ShootService _shootService;
        private readonly IInputService _inputService;

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
            if(_inputService.Attack)
                _shootService.Shoot(_weapon.BulletSpawnPoint, _weapon);
        }
    }
}