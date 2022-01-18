using UnityEngine;
using Zenject;

namespace Bloodeck
{
    public class CardMBFromTemplateFactory : PlaceholderFactory<GameObject, CardMB>, ICardFromTemplateFactory
    {
        private readonly GameObject _prefab;

        public CardMBFromTemplateFactory(GameObject prefab)
        {
            _prefab = prefab;
        }

        public ICard Create(ICardTemplate template)
        {
            if (!(template is CardTemplateSO cardTemplateSO))
            {
                return default;
            }

            return Create(cardTemplateSO);
        }

        public CardMB Create(CardTemplateSO template)
        {
            CardMB instance = Create(_prefab);
            instance.LoadTemplate(template);

            return instance;
        }
    }
}