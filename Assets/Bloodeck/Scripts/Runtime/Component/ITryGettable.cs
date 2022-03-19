using System;

namespace Bloodeck
{
    public interface ITryGettable<TBase>
    {
        bool TryGet<T>(out T value) where T : TBase;
        bool TryGet(Type type, out TBase value);
    }
}