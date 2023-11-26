using Infrastructure.Helpers;
using UnityEngine;

namespace Core.Models.Systems
{
    public interface IWeapon : ISingleSystem
    {
        Transform BulletSpawnPoint { get; }
        Fraction Fraction { get; }
        Observable Destroyed { get; }
        int Damage { get; }
        void Destroy();
    }
}