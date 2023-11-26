using UnityEngine;

namespace Core.Services.Input
{
    public interface IInputService
    {
        Vector2 Moving();
        bool Attack { get; }
        bool NextWeaponChoose { get; }
        bool PreviousWeaponChoose { get; }
        float Rotating();
    }
}