using Core.Models.Systems;
using Infrastructure.Services.System;
using Zenject;

namespace Core.Models.Services
{
    public class WorldServices : ITickable, IFixedTickable
    {
        private SystemService _systemService;

        public WorldServices(SystemService systemService)
        {
            _systemService = systemService;
        }

        public void Tick()
        {
            var movers = _systemService.TryFindSystems<IMover>();
            foreach (var mover in movers)
            {
                mover.Move();
            }
            
            var rotators = _systemService.TryFindSystems<IRotator>();
            foreach (var rotator in rotators)
            {
                rotator.Rotate();
            }
        }

        public void FixedTick()
        {
            
        }
    }
}