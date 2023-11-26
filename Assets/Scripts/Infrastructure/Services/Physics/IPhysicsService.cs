using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Infrastructure.Services.System;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.Services.Physics
{
    public class PhysicsService : IPhysicsService
    {
        private SystemService _systemService;

        public PhysicsService(SystemService systemService)
        {
            _systemService = systemService;
        }
        
        public bool HasCollision(Collider2D first, Collider2D second)
        {
            return first.IsTouching(second);
        }

        public bool HasAnyCollision(Collider2D collider)
        {
            var collided = new List<Collider2D>();
            ContactFilter2D filter = new ContactFilter2D().NoFilter();
            filter.layerMask = LayerMask.NameToLayer("Default");
            var hasAnyCollision = collider.OverlapCollider(filter, collided) > 0;
            return collided.Any((collider2D => HasCollision(collider,collider2D)));
        }

        public Unit[] AllUnitsThatCollidedWith(Collider2D collider)
        {
            var units = _systemService.TryFindSystems<Unit>();
            var collidedUnits = new List<Unit>();
            
            foreach (var unit in units)
            {
                if(HasCollision(unit.Collider, collider))
                    collidedUnits.Add(unit);
            }

            return collidedUnits.ToArray();
        }
    }

    public interface IPhysicsService
    {
        bool HasCollision(Collider2D first, Collider2D second);
        bool HasAnyCollision(Collider2D collider);
        Unit[] AllUnitsThatCollidedWith(Collider2D collider);
    }
}