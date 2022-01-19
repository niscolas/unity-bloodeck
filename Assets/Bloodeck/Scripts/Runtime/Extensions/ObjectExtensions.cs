using System;

namespace Bloodeck
{
    public static class ObjectExtensions
    {
        public static bool TryDoAsCasted<TCurrent, TCasted>(this TCurrent self, Action<TCasted> callback)
        {
            if (self is TCasted casted)
            {
                callback(casted);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}