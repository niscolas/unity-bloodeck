using System;
using System.Collections.Generic;
using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    [Serializable]
    public class ReturnCardToHandCardEffectSystem : ICardEffectSystem
    {
        public void Apply(IEnumerable<IEntity> targets, ICard instigator = null)
        {
            targets.ForEach(x => Apply(x, instigator));
        }

        public void Apply(IEntity target, ICard instigator = null)
        {
            if (!target.Components.TryGet(out ILinkEntityComponent<ICard> cardLink))
            {
                return;
            }

            ICard card = cardLink.Link;

            if (!card.Deployable.TryUndeploy())
            {
                return;
            }

            card.Ownable.Owner.Hand.Add(card);
        }
    }
}