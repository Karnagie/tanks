using Infrastructure.Helpers;
using UnityEngine;

namespace Core.Models.Systems
{
    public class DefaultWeapon : IWeapon
    {
        public Transform BulletSpawnPoint { get; }
        public Fraction Fraction { get; }
        public Observable Destroyed { get; } = new();
        public int Damage { get; }

        public DefaultWeapon(Transform bulletSpawnPoint, Fraction fraction, int damage)
        {
            BulletSpawnPoint = bulletSpawnPoint;
            Fraction = fraction;
            Damage = damage;
        }

        public void Destroy()
        {
            Destroyed.Invoke();
        }
    }
}