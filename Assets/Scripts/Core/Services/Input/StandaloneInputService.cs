using UnityEngine;
using Zenject;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.Services.Input
{
    public class StandaloneInputService : IInputService, ITickable
    {
        private const int DefaultSpeedMultiplier = 3;
        
        public bool Attack { get; private set; }
        
        public float Rotating()
        {
            var rotating = UnityEngine.Input.GetAxis("Horizontal");
            
            return rotating;
        }
        
        public Vector2 Moving()
        {
            var horizontal = 0;
            var vertical = UnityEngine.Input.GetAxis("Vertical");

            var direction = new Vector2(horizontal, vertical);
            return direction*Time.deltaTime*DefaultSpeedMultiplier;
        }

        public void Tick()
        {
            Attack = false;
            
            if (UnityEngine.Input.GetAxis("Fire1") == 1)
                Attack = true;
        }
    }
}