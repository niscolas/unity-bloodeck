namespace Bloodeck
{
    public interface IEntityComponents : IComponents<IEntityComponent>
    {
        void LoadComponents();
    }
}