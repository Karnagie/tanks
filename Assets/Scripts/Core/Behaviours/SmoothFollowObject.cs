using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Behaviours
{
    public class SmoothFollowObject : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private int _followTime = 100;

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
            
            transform.position =
                Vector3.Slerp(transform.position, _target.position + _offset, _followTime * Time.deltaTime);
        }
    }
}