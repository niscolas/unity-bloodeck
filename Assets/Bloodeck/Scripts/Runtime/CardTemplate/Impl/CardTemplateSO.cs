using Creatable;
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
        [SerializeReference, SubclassSelector]
        private IEntityTemplate _selfEntityTemplate;

        [Creatable, SerializeField]
        private CardRaritySO _rarity;

        [SerializeField]
        private IntReference _cost = new IntReference(1);

        [SerializeField]
        private CardEffectMap _effects = new CardEffectMap();

        [SerializeReference, SubclassSelector]
        private ICardComponentTemplates _componentTemplates;

        public ICardComponentTemplates ComponentTemplates => _componentTemplates;

        public int Cost => _cost.Value;

        public ICardEffectMap Effects => _effects;

        public IEntityTemplate SelfEntityTemplate => _selfEntityTemplate;
    }
}