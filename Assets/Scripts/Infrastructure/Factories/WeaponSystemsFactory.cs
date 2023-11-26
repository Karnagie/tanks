using Core.Models.Systems;
using Core.Services;
using Core.Services.Input;

namespace Infrastructure.Factories
{
    public class WeaponSystemsFactory
    {
        private readonly ShootService _shootService;
        private readonly IInputService _inputService;

        public WeaponSystemsFactory(ShootService shootService, IInputService inputService)
        {
            _shootService = shootService;
            _inputService = inputService;
        }

        public ISystem Shooter(IWeapon weapon)
        {
            return new DefaultInputShooter(weapon, _shootService, _inputService);
        }
    }
}