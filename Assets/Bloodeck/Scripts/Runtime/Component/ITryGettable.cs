namespace Bloodeck
{
    public interface ITryGettable<in TBase>
    {
        bool TryGet<T>(out T value) where T : TBase;
    }
}