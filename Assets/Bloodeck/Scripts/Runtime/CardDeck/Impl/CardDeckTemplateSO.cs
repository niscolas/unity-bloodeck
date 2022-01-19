using UnityEngine;

namespace Bloodeck
{
    [CreateAssetMenu(
        fileName = "CardDeck",
        menuName = Constants.CreateAssetMenuPrefix + "Card Deck",
        order = Constants.CreateAssetMenuOrder)]
    public class CardDeckTemplateSO : ScriptableObject, ICardDeckTemplate
    {
        [SerializeField]
        private CardTemplateSOCollection _cards;

        public ICardTemplates CardTemplates => _cards;
    }
}