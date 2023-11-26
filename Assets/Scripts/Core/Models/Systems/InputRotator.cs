using Core.Services.Input;
using UnityEngine;

namespace Core.Models.Systems
{
    public class InputRotator : IRotator
    {
        private readonly IInputService _inputService;
        private readonly Unit _model;
        private readonly float _speed;

        public InputRotator(Unit model, float speed, IInputService inputService)
        {
            _speed = speed;
            _model = model;
            _inputService = inputService;
        }

        public void Rotate()
        {
            var rotateSpeed = _inputService.Rotating();
            _model.Transform.rotation *= Quaternion.AngleAxis(-rotateSpeed*_speed, Vector3.forward);
        }
    }
}