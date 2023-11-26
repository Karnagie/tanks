using UnityEngine;
using Zenject;

namespace Core.Services.Input
{
    public class StandaloneInputService : IInputService
    {
        private const int DefaultSpeedMultiplier = 3;
        
        public bool Attack { get; private set; }
        public bool NextWeaponChoose { get; private set; }
        public bool PreviousWeaponChoose { get; private set; }

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
            NextWeaponChoose = false;
            PreviousWeaponChoose = false;
            
            if (UnityEngine.Input.GetKey("x"))
                Attack = true;
            
            if (UnityEngine.Input.GetKeyDown("e"))
                NextWeaponChoose = true;
            
            if (UnityEngine.Input.GetKeyDown("q"))
                PreviousWeaponChoose = true;
        }
    }
}