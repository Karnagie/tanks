using System;
using Core.Models;
using Infrastructure.Services.Binding;
using Infrastructure.Services.System;
using UnityEngine;
using Zenject;

namespace Core.Behaviours
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private int _speed = 100;
        
        private SystemService _systemService;

        [Inject]
        private void Construct(SystemService systemService)
        {
            _systemService = systemService;
        }
        
        private void Update()
        {
            var playerFilter = new Filter<Unit>((unit => unit.Fraction == Fraction.Player));
            var playerSystems = _systemService.TryFindSystems<Unit>(playerFilter);
            if (playerSystems.Length > 0)
            {
                transform.position = 
                    Vector3.Slerp(transform.position, 
                        new Vector3(
                            playerSystems[0].Transform.position.x, 
                            playerSystems[0].Transform.position.y, 
                            transform.position.z), 
                        _speed * Time.deltaTime);
            }
        }
    }
}