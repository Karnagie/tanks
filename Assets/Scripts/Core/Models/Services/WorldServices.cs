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
            var animators = _systemService.TryFindSystems<IMover>();
            foreach (var animator in animators)
            {
                animator.Move();
            }
        }

        public void FixedTick()
        {
            
        }
    }
}