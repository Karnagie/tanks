using System;
using System.Linq;
using Core.Models;
using Infrastructure.Factories;
using Infrastructure.Services.Binding;
using Infrastructure.Services.System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Core.Behaviours
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private float _minDistance = 5;
        
        private SystemService _systemService;
        private UnitFactory _unitFactory;

        [Inject]
        private void Construct(SystemService systemService, UnitFactory unitFactory)
        {
            _unitFactory = unitFactory;
            _systemService = systemService;
        }

        private void Update()
        {
            var playerFilter = new Filter<Unit>((unit => unit.Fraction == Fraction.Player));
            var playerSystems = _systemService.TryFindSystems<Unit>(playerFilter);
            if (playerSystems.Length > 0)
                TrySpawnRandomEnemy(playerSystems[0].Transform);
        }

        private void TrySpawnRandomEnemy(Transform player)
        {
            var validSpawnPoints =
                _spawnPoints.Where(
                    (transform1 => Vector3.Distance(player.position, transform1.position) >= _minDistance))
                    .ToArray();
            var randomIndex = Random.Range(0, validSpawnPoints.Length);
            
            var enemyFilter = new Filter<Unit>((unit => unit.Fraction != Fraction.Player));
            var playerSystems = _systemService.TryFindSystems<Unit>(enemyFilter);
            
            if(playerSystems.Length < 10)
                _unitFactory.CreateRandomMonster(validSpawnPoints[randomIndex].position);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            foreach (var spawnPoint in _spawnPoints)
            {
                Gizmos.DrawWireSphere(spawnPoint.position, _minDistance);
            }
        }
    }
}