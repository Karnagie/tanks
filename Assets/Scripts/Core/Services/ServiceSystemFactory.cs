using Core.Models;
using Core.Models.Systems;
using Core.Services.Input;
using UnityEngine;

namespace Core.Services
{
    public class ServiceSystemFactory
    {
        private readonly IInputService _inputService;

        public ServiceSystemFactory(
            IInputService inputService)
        {
            _inputService = inputService;
        }

        public ISystem InputMover(Transform transform, float speed)
        {
            return new InputMover(transform, speed, _inputService);
        }

        public ISystem InputRotator(Transform transform, float speed)
        {
            return new InputRotator(transform, speed, _inputService);
        }

        public ISystem ForwardMover(Transform transform, float speed)
        {
            return new ForwardMover(transform, speed);
        }
    }
}