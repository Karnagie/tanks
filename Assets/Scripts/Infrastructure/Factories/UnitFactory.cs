using Core.Behaviours;
using Core.Models;
using Core.Services;
using Infrastructure.Services.Binding;
using Infrastructure.Services.System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Factories
{
    public class UnitFactory
    {
        private const float UnitSpeed = 1f;
        private const int PlayerHealth = 100;
        private const int UnitArmor = 10;

        private readonly ViewFactory _viewFactory;
        private readonly ServiceSystemFactory _serviceSystemFactory;
        private readonly SystemService _systemService;
        private readonly BinderFactory _binderFactory;
        private readonly WeaponFactory _weaponFactory;

        private int _monsterSpawnedCounter;

        public UnitFactory(ViewFactory viewFactory,
            ServiceSystemFactory serviceSystemFactory,
            SystemService systemService,
            BinderFactory binderFactory,
            WeaponFactory weaponFactory)
        {
            _weaponFactory = weaponFactory;
            _binderFactory = binderFactory;
            _systemService = systemService;
            _serviceSystemFactory = serviceSystemFactory;
            _viewFactory = viewFactory;
        }

        public void CreatePlayer(Vector3 position)
        {
            var behaviour = _viewFactory.Player(position);
            var player = new Unit(
                "Player", 
                behaviour.Transform,
                Fraction.Player,
                PlayerHealth,
                UnitArmor,
                UnitSpeed,
                behaviour.WeapontPoint);
            var binder = _binderFactory.Create();
            var linker = new SystemLinker();
            
            _weaponFactory.CreateDefaultWeapon(player.WeaponPoint, player);
            
            //components
            var mover = _serviceSystemFactory.InputMover(player.Transform, UnitSpeed);
            var rotator = _serviceSystemFactory.InputRotator(player.Transform, UnitSpeed);
            
            linker.Add(player);
            linker.Add(mover);
            linker.Add(rotator);
            
            binder.BindProperty(player.Name, newName => behaviour.Name.text = $"{newName}");
            binder.BindProperty(player.Health, newHealth => behaviour.Health.text = $"hp: {newHealth}");
            binder.BindProperty(player.Armor, newArmor => behaviour.Armor.text = $"armor: {newArmor}");
            binder.BindProperty(player.Speed, newSpeed => behaviour.Speed.text = $"speed: {newSpeed}");
            
            LinkDisposing(binder, linker, player, behaviour);
        }
        
        public void CreateMonster(Vector3 position)
        {
            var behaviour = _viewFactory.Monster(position);
            var bot = new Unit(
                $"Monster_{_monsterSpawnedCounter}",
                behaviour.Transform, 
                Fraction.Monster,
                10,
                2,
                0.5f,
                behaviour.WeapontPoint);
            var binder = _binderFactory.Create();
            var linker = new SystemLinker();
            
            //components
            // var mover = _serviceSystemFactory.MonsterMover(bot);
            
            linker.Add(bot);
            // linker.Add(mover);
            
            LinkDisposing(binder, linker, bot, behaviour);
        }

        private void LinkDisposing(Binder binder, SystemLinker linker, Unit bot, UnitBehaviour behaviour)
        {
            binder.LinkHolder(_systemService, linker);
            binder.LinkEvent(bot.Killed, binder.Dispose);
            binder.LinkEvent(bot.Killed, (() => Object.Destroy(behaviour.gameObject)));
        }
    }
}