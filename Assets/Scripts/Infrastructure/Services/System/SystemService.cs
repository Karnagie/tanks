using System.Collections.Generic;
using Core.Models.Systems;
using Infrastructure.Services.Binding;
using UnityEngine;

namespace Infrastructure.Services.System
{
    public class SystemService : IItemHolder<SystemLinker>
    {
        private List<SystemLinker> _linkedSystems = new();
        
        public TReturn[] TryFindSystems<TReturn>(params IFilter[] filters)
        {
            List<TReturn> targets = new();
            
            foreach (var linker in _linkedSystems)
            {
                if (!Met(linker, filters))
                    continue;
                
                if (linker.TryGetSystems(out TReturn[] systems))
                {
                    targets.AddRange(systems);
                }
            }

            return targets.ToArray();
        }

        public SystemLinker[] LinkersThatHas(ISystem system)
        {
            List<SystemLinker> linkers = new();
            foreach (var linkedSystem in _linkedSystems)
            {
                if (linkedSystem.Has(system))
                {
                    linkers.Add(linkedSystem);
                }
            }

            return linkers.ToArray();
        }

        public void Add(SystemLinker item)
        {
            _linkedSystems.Add(item);
        }

        public void Remove(SystemLinker item)
        {
            _linkedSystems.Remove(item);
        }

        private bool Met(SystemLinker linker, IFilter[] filters)
        {
            foreach (var filter in filters)
            {
                if (!filter.Met(linker))
                    return false;
            }

            return true;
        }
        
        public bool TryFindSingleSystem<T>(out T system, params IFilter[] filters) where T : ISingleSystem
        {
            system = default;
            var systems = TryFindSystems<T>(filters);
            
            if(systems.Length > 1)
                Debug.LogError($"There is more than one linker that has {typeof(T)}. Count: {systems.Length}");
            
            if(systems.Length == 0)
            {
                Debug.LogError($"There is no linker that has {typeof(T)}");
                return false;
            }

            system = systems[0];
            return true;
        }
    }
}