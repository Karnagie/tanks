using UnityEngine;
using Zenject;

namespace Battle
{
    public class Bootstrap : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AttackService>().AsSingle();
        }
    }
}