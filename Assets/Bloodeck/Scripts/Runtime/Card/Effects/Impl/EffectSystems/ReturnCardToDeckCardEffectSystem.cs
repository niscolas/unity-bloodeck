using System;
using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    [Serializable]
    public class ReturnCardToDeckCardEffectSystem : ICardEffectSystem
    {
        public void Apply(IEntities targets, ICard instigator)
        {
            targets.ForEach(x => Apply(x, instigator));
        }

        public void Apply(IEntity target, ICard instigator)
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

            card.Owner.Deck.ReturnCard(card);
        }
    }
}