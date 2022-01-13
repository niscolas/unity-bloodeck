using Creatable;
using NaughtyAttributes;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Bloodeck
{
    [CreateAssetMenu(
        fileName = DisplayName,
        menuName = Constants.CreateAssetMenuPrefix + DisplayName,
        order = Constants.CreateAssetMenuOrder)]
    public class CardTemplateSO : ScriptableObject
    {
        [Expandable, Creatable, SerializeField]
        private EntityTemplateSO _entityTemplate;

        [Expandable, Creatable, SerializeField]
        private CardRaritySO _rarity;

        [SerializeField]
        private IntReference _attackValue = new IntReference(1);

        [SerializeField]
        private IntReference _cost = new IntReference(1);

        public int AttackValue
        {
            get => _attackValue.Value;
            set => _attackValue.Value = value;
        }

        public int Cost => _cost.Value;

        public EntityTemplateSO EntityTemplate => _entityTemplate;

        private const string DisplayName = "Card";
    }
}