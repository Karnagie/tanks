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
        private readonly UnitService _unitService;

        public ServiceSystemFactory(
            IInputService inputService, 
            IPhysicsService physicsService,
            UnitService unitService)
        {
            _inputService = inputService;
            _physicsService = physicsService;
            _unitService = unitService;
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

        public ISystem MonsterMover(Transform transform, float speed)
        {
            return new MonsterMover(transform, speed, _unitService);
        }

        public ISystem DamagerOnCollision(Fraction fraction, Collider2D collider, int damage)
        {
            return new DamagerOnCollision(fraction, collider, _physicsService, damage);
        }
    }
}