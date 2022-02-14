using UnityEngine;

namespace Bloodeck
{
    [CreateAssetMenu(
        fileName = "Deck",
        menuName = Constants.CreateAssetMenuPrefix + "Deck",
        order = Constants.CreateAssetMenuOrder)]
    public class DeckTemplateSO : ScriptableObject, IDeckTemplate
    {
        [SerializeField]
        private CardTemplateSOCollection _cards;

        public ICardTemplates CardTemplates => _cards;
    }
}