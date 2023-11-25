using Core.Behaviours;
using Core.Models;
using Infrastructure.Services.Binding;
using Infrastructure.Services.System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Factories
{
    public class UnitFactory
    {
        private readonly ViewFactory _viewFactory;
        private readonly ServiceSystemFactory _serviceSystemFactory;
        private readonly SystemService _systemService;
        private BinderFactory _binderFactory;

        private int _monsterSpawnedCounter;

        public UnitFactory(ViewFactory viewFactory,
            ServiceSystemFactory serviceSystemFactory,
            SystemService systemService,
            BinderFactory binderFactory)
        {
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
                Fraction.Player);
            var binder = _binderFactory.Create();
            var linker = new SystemLinker();
            
            //components
            // var mover = _serviceSystemFactory.PlayerMover(player);
            
            linker.Add(player);
            
            LinkDisposing(binder, linker, player, behaviour);
        }
        
        public void CreateMonster(Vector3 position)
        {
            var behaviour = _viewFactory.Monster(position);
            var bot = new Unit(
                $"Monster_{_monsterSpawnedCounter}",
                behaviour.Transform, 
                Fraction.Monster);
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