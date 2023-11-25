using System;
using System.Collections.Generic;
using Infrastructure.States;

namespace Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states = new ();
        private IExitableState _activeState;
        
        public void AddStates(List<IExitableState> states)
        {
            foreach (var state in states)
            {
                _states.Add(state.GetType(), state);
            }
        }

        public void Enter<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadState<TPayLoad>
        {
            var state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
        
            var state = GetState<TState>();
            _activeState = state;
        
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
    }
}