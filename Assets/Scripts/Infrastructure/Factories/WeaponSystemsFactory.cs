using Core.Models;
using Core.Models.Systems;
using Core.Services;
using Core.Services.Input;

namespace Infrastructure.Factories
{
    public class WeaponSystemsFactory
    {
        private readonly ShootService _shootService;
        private readonly IInputService _inputService;

        public WeaponSystemsFactory(
            ShootService shootService,
            IInputService inputService)
        {
            _shootService = shootService;
            _inputService = inputService;
        }

        public ISystem Shooter(IWeapon weapon)
        {
            return new DefaultInputShooter(weapon, _shootService, _inputService);
        }

        public ISystem SlowShooter(IWeapon weapon)
        {
            return new SlowInputShooter(weapon, _shootService, _inputService);
        }
    }

    public class PlayerWeaponSystemsFactory
    {
        private readonly IInputService _inputService;
        private readonly WeaponService _weaponService;
        private readonly WeaponFactory _weaponFactory;

        public PlayerWeaponSystemsFactory(
            IInputService inputService, 
            WeaponService weaponService, 
            WeaponFactory weaponFactory)
        {
            _inputService = inputService;
            _weaponService = weaponService;
            _weaponFactory = weaponFactory;
        }
        
        public ISystem WeaponChanger(Unit unit)
        {
            return new WeaponChanger(_weaponFactory, unit, _weaponService, _inputService);
        }
    }
}