using Core.Services.Input;
using UnityEngine;

namespace Core.Models.Systems
{
    public class InputRotator : IRotator
    {
        private readonly IInputService _inputService;
        private readonly Transform _transform;
        private readonly float _speed;

        public InputRotator(Transform transform, float speed, IInputService inputService)
        {
            _speed = speed;
            _transform = transform;
            _inputService = inputService;
        }

        public void Rotate()
        {
            var rotateSpeed = _inputService.Rotating();
            _transform.rotation *= Quaternion.AngleAxis(-rotateSpeed*_speed, Vector3.forward);
        }
    }
}