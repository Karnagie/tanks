using UnityEngine;

namespace Core.Services.Input
{
    public interface IInputService
    {
        Vector2 Moving();
        bool Attack { get; }
        float Rotating();
    }
}