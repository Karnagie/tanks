using UnityEngine;

namespace Core.Behaviours
{
    public class InstantFollowObject : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private Vector3 _offset;

        private void Awake()
        {
            _offset = transform.localPosition;
            transform.SetParent(null);
        }

        private void Update()
        {
            if(_target.Equals(null))
            {
                Object.Destroy(gameObject);
                return;
            }
            
            transform.position = _target.position + _offset;
        }
    }
}