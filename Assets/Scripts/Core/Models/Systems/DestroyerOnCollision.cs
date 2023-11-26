using Infrastructure.Services.Physics;
using UnityEngine;

namespace Core.Models.Systems
{
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

    public interface IDamager : ISystem
    {
        void TryDamage();
    }
}