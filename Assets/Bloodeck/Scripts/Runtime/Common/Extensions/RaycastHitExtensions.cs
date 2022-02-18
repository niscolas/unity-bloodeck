using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bloodeck
{
    public static class RaycastHitExtensions
    {
        public static RaycastHit GetNearestRaycastHit(this IEnumerable<RaycastHit> self)
        {
            return self.OrderBy(x => x.distance).FirstOrDefault();
        }
    }
}