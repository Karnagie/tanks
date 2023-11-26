using Core.Models.Services;
using Core.Services.Input;
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
}