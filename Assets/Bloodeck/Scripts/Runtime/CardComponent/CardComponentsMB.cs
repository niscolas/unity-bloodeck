using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Components")]
    public class CardComponentsMB :
        InjectableParentCollectionMB<ICardComponent, CardComponentMB>, ICardComponents
    {
        public bool TryGet<T>(out T value) where T : ICardComponent
        {
            return _content.TryGetFirstOfType(out value);
        }
    }
}