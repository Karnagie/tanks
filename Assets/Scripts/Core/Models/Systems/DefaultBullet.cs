using UnityEngine;

namespace Core.Models.Systems
{
    public class DefaultBullet : ISingleSystem
    {
        private readonly Fraction _fraction;
        
        public Transform Transform { get; }

        public DefaultBullet(Transform transform, Fraction fraction)
        {
            Transform = transform;
            _fraction = fraction;
        }
    }
}