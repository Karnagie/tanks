using Infrastructure.Services.System;
using UnityEngine;

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
    }

    public interface IPhysicsService
    {
        bool HasCollision(Collider2D first, Collider2D second);
    }
}