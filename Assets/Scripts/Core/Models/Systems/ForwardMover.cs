using UnityEngine;

namespace Core.Models.Systems
{
    public class ForwardMover : IMover
    {
        private readonly Transform _transform;
        private readonly float _speed;

        public ForwardMover(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void Move()
        {
            _transform.Translate(Vector3.up*_speed*Time.deltaTime);
        }
    }
}