using System.Collections.Generic;
using Infrastructure.Helpers;
using Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private GameStateMachine _gameStateMachine;
        private List<IExitableState> _states;
        private IInitializable _initializable;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine, List<IExitableState> states, IInitializable initializable)
        {
            _initializable = initializable;
            _states = states;
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            _initializable.Initialize();
            
            _gameStateMachine.AddStates(_states);
            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}