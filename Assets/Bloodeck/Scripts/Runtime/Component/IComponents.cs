using System.Collections.Generic;

namespace Bloodeck
{
    public interface IComponents<T> : ITryGettable<T>, ICollection<T> { }
}