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
        private const string DisplayName = "Card";

        [Expandable, Creatable, SerializeField]
        private EntityTemplateSO _entityTemplate;
        
        [SerializeField]
        private IntReference _attackValue = new IntReference(1);

        [SerializeField]
        private IntReference _cost = new IntReference(1);
    }
}