namespace Core.Models.Systems
{
    public interface IDestroyable : ISingleSystem
    {
        void Destroy();
    }
}