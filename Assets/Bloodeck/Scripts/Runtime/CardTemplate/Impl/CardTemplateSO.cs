using Creatable;
using NaughtyAttributes;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Bloodeck
{
    [CreateAssetMenu(
        fileName = "Card",
        menuName = Constants.CreateAssetMenuPrefix + "Card",
        order = Constants.CreateAssetMenuOrder)]
    public class CardTemplateSO : ScriptableObject, ICardTemplate
    {
        [Expandable, Creatable, SerializeField]
        private EntityTemplateSO _selfEntityTemplate;

        [Expandable, Creatable, SerializeField]
        private CardRaritySO _rarity;

        [SerializeField]
        private CardEffectMap _effects = new CardEffectMap();

        [SerializeReference, SubclassSelector]
        private ICardComponentTemplates _componentTemplates;

        [SerializeField]
        private IntReference _cost = new IntReference(1);

        public ICardComponentTemplates ComponentTemplates => _componentTemplates;

        public int Cost => _cost.Value;

        public ICardEffectMap Effects => _effects;

        public EntityTemplateSO SelfEntityTemplateSO => _selfEntityTemplate;

        public IEntityTemplate SelfEntityTemplate => _selfEntityTemplate;
    }
}