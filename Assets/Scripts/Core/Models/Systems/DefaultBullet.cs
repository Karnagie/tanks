using Infrastructure.Helpers;
using UnityEngine;

namespace Core.Models.Systems
{
    public class DefaultBullet : IDestroyable
    {
        public Fraction Fraction { get; }
        public Transform Transform { get; }
        public Observable Destroyed { get; } = new();
        public Collider2D Collider { get; }

        public DefaultBullet(Transform transform, Fraction fraction, Collider2D collider)
        {
            Transform = transform;
            Fraction = fraction;
            Collider = collider;
        }

        public void Destroy()
        {
            Destroyed.Invoke();
        }
    }
}