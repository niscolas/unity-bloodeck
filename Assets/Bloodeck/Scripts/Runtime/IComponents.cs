namespace Bloodeck
{
    public interface IComponents<in TComponent>
    {
        void Add<T>(T componentInstance) where T : TComponent;

        bool TryGet<T>(out T value) where T : class, TComponent;
    }
}