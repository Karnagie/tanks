using Infrastructure.Services.Physics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace Core.Models.Systems
{
    public class ForwardMover : IMover
    {
        private readonly Transform _transform;
        private readonly float _speed;

        public ForwardMover(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void Move()
        {
            _transform.Translate(Vector3.up*_speed*Time.deltaTime);
        }
    }
    
    public class DestroyerOnCollision : IDestroyer
    {
        private readonly Collider2D _collider;
        private readonly IPhysicsService _physicsService;
        private readonly IDestroyable _destroyable;
        
        public DestroyerOnCollision(Collider2D collider, IPhysicsService physicsService, IDestroyable destroyable)
        {
            _destroyable = destroyable;
            _collider = collider;
            _physicsService = physicsService;
        }

        public void TryDestroy()
        {
            if (_physicsService.HasAnyCollision(_collider))
            {
                _destroyable.Destroy();
            }
        }
    }

    public interface IDestroyer : ISystem
    {
        void TryDestroy();
    }

    public interface IDestroyable : ISingleSystem
    {
        void Destroy();
    }
}