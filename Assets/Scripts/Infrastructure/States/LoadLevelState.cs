using Core.Services;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using UnityEngine;

namespace Infrastructure.States
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly UnitFactory _unitFactory;
        private WindowsService _windowsService;

        public LoadLevelState(
            GameStateMachine gameStateMachine, 
            SceneLoader sceneLoader,
            WindowsService windowsService,
            UnitFactory unitFactory)
        {
            _windowsService = windowsService;
            _sceneLoader = sceneLoader;
            _gameStateMachine = gameStateMachine;
            _unitFactory = unitFactory;
        }

        public void Enter(string sceneName)
        {
            _windowsService.OpenLoadingCurtain();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _windowsService.CloseLoadingCurtain();
        }

        private void OnLoaded()
        {
            _unitFactory.CreatePlayer(new Vector3(0,0,0));
            _unitFactory.CreateRandomMonster(new Vector3(10,10,0));
            
            _gameStateMachine.Enter<GameLoopState>();
        }
    }
}