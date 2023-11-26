using System.Collections.Generic;
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
            return collider.OverlapCollider(filter, collided) > 0;
        }
    }

    public interface IPhysicsService
    {
        bool HasCollision(Collider2D first, Collider2D second);
        bool HasAnyCollision(Collider2D collider);
    }
}