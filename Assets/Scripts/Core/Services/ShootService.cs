using Core.Models.Systems;
using Infrastructure.Factories;
using UnityEngine;

namespace Core.Services
{
    public class ShootService
    {
        private BulletFactory _bulletFactory;

        public ShootService(BulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }

        public void Shoot(Transform bulletSpawnPoint, IWeapon weapon)
        {
            _bulletFactory.CreateDefaultBullet(bulletSpawnPoint, weapon);
        }
    }
}