using Infrastructure.Helpers;
using Infrastructure.Services.Ui;

namespace Infrastructure.States
{
    public class MenuState : IPayLoadState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly WindowsService _windowsService;

        public MenuState(
            SceneLoader sceneLoader,
            WindowsService windowsService)
        {
            _windowsService = windowsService;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName)
        {
            _windowsService.OpenLoadingCurtain();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _windowsService.CloseMainMenu();
        }

        private void OnLoaded()
        {
            _windowsService.OpenMainMenu();
            
            _windowsService.CloseLoadingCurtain();
        }
    }
}