using Infrastructure.States;
using UI;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.Ui
{
    public class WindowsService
    {
        private DiContainer _container;
        private MainMenuBinder _mainMenuBinder;
        private LoadingCurtain _loadingCurtain;

        public WindowsService(DiContainer container, MainMenuBinder mainMenuBinder)
        {
            _mainMenuBinder = mainMenuBinder;
            _container = container;
        }
        
        public void OpenMainMenu()
        {
            var mainMenuWindow = _container.InstantiatePrefabResourceForComponent<MainMenuBehaviour>("UI/MainMenu");
            _mainMenuBinder.Bind(mainMenuWindow);
        }

        public void CloseMainMenu()
        {
            _mainMenuBinder.DestroyView();
        }

        public void OpenLoadingCurtain()
        {
            _loadingCurtain ??= _container.InstantiatePrefabResourceForComponent<LoadingCurtain>("UI/Canvas_Loading");
            _loadingCurtain.Show();
        }
        
        public void CloseLoadingCurtain()
        {
            _loadingCurtain.Hide();
        }
    }

    public class MainMenuBinder
    {
        private MainMenuBehaviour _behaviour;
        private GameStateMachine _gameStateMachine;

        public MainMenuBinder(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Bind(MainMenuBehaviour mainMenuWindow)
        {
            _behaviour = mainMenuWindow;
            _behaviour.Start.onClick.AddListener(
                (() => _gameStateMachine.Enter<LoadLevelState, string>("Battle")));
            _behaviour.StartText.text = "Start battle";
        }

        public void DestroyView()
        {
            Object.Destroy(_behaviour);
        }
    }
}