using Core.Models;
using Core.Models.Systems;
using Core.Services.Input;
using Infrastructure.Factories;
using Infrastructure.Services.Physics;
using UnityEngine;

namespace Core.Services
{
    public class ServiceSystemFactory
    {
        private readonly IInputService _inputService;
        private readonly IPhysicsService _physicsService;

        public ServiceSystemFactory(
            IInputService inputService, 
            IPhysicsService physicsService)
        {
            _inputService = inputService;
            _physicsService = physicsService;
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

        public ISystem DestroyerOnCollision(Collider2D collider, IDestroyable destroyable)
        {
            return new DestroyerOnCollision(collider, _physicsService, destroyable);
        }
    }
}