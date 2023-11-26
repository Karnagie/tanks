namespace Core.Models.Systems
{
    public interface IDestroyer : ISystem
    {
        void TryDestroy();
    }
}