using Core.Behaviours;
using Infrastructure.AssetManagement;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class ViewFactory
    {
        private const string DefaultPlayerPath = "Characters/Player";
        private const string DefaultMonsterPath = "Characters/Monster";
        
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
    }
}