using Core.Services;
using Core.Services.Input;
using Infrastructure.Factories;
using UnityEngine;

namespace Core.Models.Systems
{
    public class InputRotator : IRotator
    {
        private readonly IInputService _inputService;
        private readonly Transform _transform;
        private readonly float _speed;

        public InputRotator(Transform transform, float speed, IInputService inputService)
        {
            _speed = speed;
            _transform = transform;
            _inputService = inputService;
        }

        public void Rotate()
        {
            var rotateSpeed = _inputService.Rotating();
            _transform.rotation *= Quaternion.AngleAxis(-rotateSpeed*_speed, Vector3.forward);
        }
    }

    public class WeaponChanger : IWeaponChanger
    {
        private readonly WeaponFactory _weaponFactory;
        private readonly Unit _owner;
        private readonly WeaponService _weaponService;
        private readonly IInputService _inputService;

        private int _index = 0;

        public WeaponChanger(
            WeaponFactory weaponFactory, 
            Unit owner, 
            WeaponService weaponService,
            IInputService inputService)
        {
            _inputService = inputService;
            _weaponService = weaponService;
            _owner = owner;
            _weaponFactory = weaponFactory;
        }

        public void TryChange()
        {
            if (_inputService.NextWeaponChoose)
                ChangeToNext();
            else if (_inputService.PreviousWeaponChoose)
                ChangeToPrevious();
        }
        
        private void ChangeToNext()
        {
            RemoveAllWeapons();
            _index++;
            switch (_index)
            {
                case 2:
                    _weaponFactory.CreateDefaultWeapon(_owner.WeaponPoint, _owner);
                    _index = 0;
                    break;
                case 1:
                    _weaponFactory.CreateSlowWeapon(_owner.WeaponPoint, _owner);
                    break;
            }
        }

        private void ChangeToPrevious()
        {
            RemoveAllWeapons();
            _index--;
            switch (_index)
            {
                case -1:
                    _weaponFactory.CreateSlowWeapon(_owner.WeaponPoint, _owner);
                    _index = 1;
                    break;
                case 0:
                    _weaponFactory.CreateDefaultWeapon(_owner.WeaponPoint, _owner);
                    break;
            }
        }
        
        private void RemoveAllWeapons()
        {
            _weaponService.DestroyAllWeapons(_owner);
            _weaponService.DestroyAllWeapons(_owner);
            _weaponService.DestroyAllWeapons(_owner);
        }
    }

    public interface IWeaponChanger : ISingleSystem
    {
        void TryChange();
    }
}