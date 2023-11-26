using Core.Models.Services;
using Core.Services.Input;

namespace Core.Models.Systems
{
    public class InputMover : IMover
    {
        private readonly IInputService _inputService;
        private readonly Unit _model;
        private readonly float _speed;

        public InputMover(Unit model, float speed, IInputService inputService)
        {
            _speed = speed;
            _model = model;
            _inputService = inputService;
        }

        public void Move()
        {
            var translation = _inputService.Moving();
            _model.Transform.Translate(translation * _speed);
        }
    }
}