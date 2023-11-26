using Core.Models.Services;
using Core.Services.Input;
using Infrastructure.Services.Binding;
using Infrastructure.Services.System;
using UnityEngine;

namespace Core.Models.Systems
{
    public class InputMover : IMover
    {
        private readonly IInputService _inputService;
        private readonly Transform _transform;
        private readonly float _speed;

        public InputMover(Transform transform, float speed, IInputService inputService)
        {
            _speed = speed;
            _transform = transform;
            _inputService = inputService;
        }

        public void Move()
        {
            var translation = _inputService.Moving();
            _transform.Translate(translation * _speed);
        }
    }
    
    public class MonsterMover : IMover
    {
        private readonly IInputService _inputService;
        private readonly Transform _transform;
        private readonly float _speed;
        private readonly UnitService _unitService;

        public MonsterMover(Transform transform, float speed, UnitService unitService)
        {
            _unitService = unitService;
            _speed = speed;
            _transform = transform;
        }

        public void Move()
        {
            if(_unitService.TryFindPlayer(out var player))
                _transform
                    .Translate((player.Transform.position - _transform.position) * _speed * Time.deltaTime);
        }
    }

    public class UnitService
    {
        private SystemService _systemService;

        public UnitService(SystemService systemService)
        {
            _systemService = systemService;
        }

        public bool TryFindPlayer(out Unit player)
        {
            player = null;

            var playerFilter = new Filter<Unit>((unit => unit.Fraction == Fraction.Player));
            var players = _systemService.TryFindSystems<Unit>(playerFilter);
            if (players.Length > 0)
            {
                player = players[0];
                return true;
            }

            return false;
        }
    }
}