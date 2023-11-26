using Infrastructure.Services.Physics;
using UnityEngine;

namespace Core.Models.Systems
{
    public class DamagerOnCollision : IDamager
    {
        private readonly Collider2D _collider;
        private readonly IPhysicsService _physicsService;
        private readonly int _damage;
        private readonly Fraction _fraction;

        public DamagerOnCollision(
            Fraction fraction, 
            Collider2D collider,
            IPhysicsService physicsService,
            int damage)
        {
            _fraction = fraction;
            _collider = collider;
            _physicsService = physicsService;
            _damage = damage;
        }

        public void TryDamage()
        {
            var collidedUnits = _physicsService.AllUnitsThatCollidedWith(_collider);
            foreach (var unit in collidedUnits)
            {
                if (unit.Fraction != _fraction)
                {
                    unit.Damage(_damage);
                }
            }
        }
    }
}