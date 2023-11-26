using Core.Behaviours;
using Infrastructure.AssetManagement;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class ViewFactory
    {
        private const string DefaultPlayerPath = "Characters/Player";
        private const string DefaultMonsterPath = "Characters/Monster";
        
        private const string DefaultWeaponPath = "Weapons/DefaultWeapon";
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
        
        public UnitBehaviour Monster(Vector3 position)
        {
            UnitBehaviour prefab = _assetProvider.Instantiate<UnitBehaviour>(DefaultMonsterPath);
            prefab.Transform.position = position;
            
            return prefab;
        }

        public WeaponBehaviour DefaultWeapon(Transform parent)
        {
            WeaponBehaviour prefab = _assetProvider.Instantiate<WeaponBehaviour>(DefaultWeaponPath);
            prefab.Transform.SetParent(parent);
            prefab.Transform.localPosition = Vector3.zero;
            
            return prefab;
        }

        public BulletBehaviour DefaultBullet(Transform spawnPoint)
        {
            BulletBehaviour prefab = _assetProvider.Instantiate<BulletBehaviour>(DefaultBulletPath);
            prefab.Transform.position = spawnPoint.position;
            prefab.Transform.rotation = spawnPoint.rotation;
            
            return prefab;
        }
    }
}