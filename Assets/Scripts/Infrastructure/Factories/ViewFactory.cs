using Core.Behaviours;
using Infrastructure.AssetManagement;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Infrastructure.Factories
{
    public class ViewFactory
    {
        private const string DefaultPlayerPath = "Characters/Player";
        private readonly string[] DefaultMonsterPaths = new []
        {
            "Characters/Monster",
            "Characters/Monster1",
            "Characters/Monster2"
        };
        
        private const string DefaultWeaponPath = "Weapons/DefaultWeapon";
        private const string SlowWeaponPath = "Weapons/SlowWeapon";
        private const string DefaultBulletPath = "Weapons/DefaultBullet";
        
        private IAssetProvider _assetProvider;
        
        public ViewFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public UnitBehaviour Player(Vector3 position)
        {
            UnitBehaviour prefab = _assetProvider.Instantiate<UnitBehaviour>(DefaultPlayerPath);
            prefab.Transform.position = position;
            
            return prefab;
        }
        
        public UnitBehaviour RandomMonster(Vector3 position)
        {
            var randomIndex = Random.Range(0, DefaultMonsterPaths.Length);
            UnitBehaviour prefab = _assetProvider.Instantiate<UnitBehaviour>(DefaultMonsterPaths[randomIndex]);
            prefab.Transform.position = position;
            
            return prefab;
        }

        public WeaponBehaviour DefaultWeapon(Transform parent)
        {
            WeaponBehaviour prefab = _assetProvider.Instantiate<WeaponBehaviour>(DefaultWeaponPath);
            prefab.Transform.SetParent(parent);
            prefab.Transform.localPosition = Vector3.zero;
            prefab.Transform.localRotation = quaternion.identity;
            
            return prefab;
        }

        public BulletBehaviour DefaultBullet(Transform spawnPoint)
        {
            BulletBehaviour prefab = _assetProvider.Instantiate<BulletBehaviour>(DefaultBulletPath);
            prefab.Transform.position = spawnPoint.position;
            prefab.Transform.rotation = spawnPoint.rotation;
            
            return prefab;
        }

        public WeaponBehaviour SlowWeapon(Transform parent)
        {
            WeaponBehaviour prefab = _assetProvider.Instantiate<WeaponBehaviour>(SlowWeaponPath);
            prefab.Transform.SetParent(parent);
            prefab.Transform.localPosition = Vector3.zero;
            prefab.Transform.localRotation = quaternion.identity;
            
            return prefab;
        }
    }
}