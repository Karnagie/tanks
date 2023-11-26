using Infrastructure.Helpers;
using UnityEngine;

namespace Core.Models.Systems
{
    public class DefaultWeapon : IWeapon
    {
        public Transform BulletSpawnPoint { get; }
        public Fraction Fraction { get; }
        public Observable Destroyed { get; } = new();

        public DefaultWeapon(Transform bulletSpawnPoint, Fraction fraction)
        {
            BulletSpawnPoint = bulletSpawnPoint;
            Fraction = fraction;
        }

        public void Destroy()
        {
            Destroyed.Invoke();
        }
    }
}