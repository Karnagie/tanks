using Core.Models;
using Core.Models.Systems;
using Core.Services.Input;

namespace Core.Services
{
    public class ServiceSystemFactory
    {
        private IInputService _inputService;

        public ServiceSystemFactory(
            IInputService inputService)
        {
            _inputService = inputService;
        }

        public ISystem InputMover(Unit unit, float speed)
        {
            return new InputMover(unit, speed, _inputService);
        }

        public ISystem InputRotator(Unit unit, float speed)
        {
            return new InputRotator(unit, speed, _inputService);
        }
    }
}