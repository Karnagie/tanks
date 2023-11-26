using Core.Models.Services;
using Infrastructure.Services.Input;

namespace Core.Models.Systems
{
    public class InputMover : IMover
    {
        private readonly IInputService _inputService;
        private readonly Unit _model;

        public InputMover(Unit model, IInputService inputService)
        {
            _model = model;
            _inputService = inputService;
        }

        public void Move()
        {
            var translation = _inputService.Moving();
            _model.Transform.Translate(translation);
        }
    }
}