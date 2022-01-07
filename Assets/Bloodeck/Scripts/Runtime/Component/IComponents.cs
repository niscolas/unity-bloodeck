namespace Bloodeck
{
    public interface IComponents<in TComponent>
    {
        void Add<T>(T componentInstance) where T : class, TComponent;

        bool TryGet<T>(out T value) where T : class, TComponent;
    }
}