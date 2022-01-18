using System;

namespace Bloodeck
{
    public static class TypeExtensions
    {
        public static bool IsSameOfSubclassOf(this Type self, Type other)
        {
            return self == other || self.IsSubclassOf(other);
        }
    }
}