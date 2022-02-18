using UnityEngine;

namespace Bloodeck
{
    public static class ObjectExtensions
    {
        public static TComponent GetComponent<TComponent>(this object self, bool includeChildren = false)
        {
            if (!(self is Component component))
            {
                return default;
            }

            if (!includeChildren)
            {
                return component.GetComponent<TComponent>();
            }
            else
            {
                return component.GetComponentInChildren<TComponent>();
            }
        }
    }
}