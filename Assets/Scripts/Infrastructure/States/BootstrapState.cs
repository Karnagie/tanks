using Infrastructure.Helpers;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Bootstrap = "Bootstrap";
    
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(
            GameStateMachine gameStateMachine, 
            SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            InitializeServices();
            _sceneLoader.Load(Bootstrap, EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            _gameStateMachine.Enter<LoadLevelState, string>("Menu");
        }

        private void InitializeServices()
        {
            
        }
    
        public void Exit()
        {
        
        }
    }
}