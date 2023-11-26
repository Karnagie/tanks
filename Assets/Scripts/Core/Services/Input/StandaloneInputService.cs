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
            var rotating = 0f;

            if (UnityEngine.Input.GetKey("q"))
                rotating -= 1;
            
            if (UnityEngine.Input.GetKey("e"))
                rotating += 1;
            
            return rotating;
        }
        
        public Vector2 Moving()
        {
            var horizontal = UnityEngine.Input.GetAxis("Horizontal");
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