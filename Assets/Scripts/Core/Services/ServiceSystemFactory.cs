using Infrastructure.Services.System;

namespace Infrastructure.Factories
{
    public class ServiceSystemFactory
    {
        private ViewFactory _viewFactory;
        private SystemService _systemService;

        public ServiceSystemFactory(
            ViewFactory viewFactory,
            SystemService systemService)
        {
            _systemService = systemService;
            _viewFactory = viewFactory;
        }
    }
}