using Creatable;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [CreateAssetMenu(
        fileName = "Card",
        menuName = Constants.CreateAssetMenuPrefix + "Card",
        order = Constants.CreateAssetMenuOrder)]
    public class CardTemplateSO : ScriptableObject, ICardTemplate
    {
        [Inject, SerializeReference, SubclassSelector]
        private IEntityTemplate _selfEntityTemplate;

        [Creatable, SerializeField]
        private CardRaritySO _rarity;

        [SerializeField]
        private IntReference _cost = new IntReference(1);

        [Inject, SerializeReference, SubclassSelector]
        private ICardEffectMap _effects;

        [Inject, SerializeReference, SubclassSelector]
        private ICardComponentTemplates _componentTemplates = new SerializableCardComponentTemplates();

        public ICardComponentTemplates ComponentTemplates => _componentTemplates;

        public int Cost => _cost.Value;

        public ICardEffectMap Effects => _effects;

        public IEntityTemplate SelfEntityTemplate => _selfEntityTemplate;
    }
}