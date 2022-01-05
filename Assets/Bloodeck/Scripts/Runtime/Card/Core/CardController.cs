namespace Bloodeck
{
    public class CardController : ICard
    {
        public ICardComponents Components => _humbleObject.Components;

        public int Cost => _humbleObject.Cost;

        public IEntity SelfEntity => _humbleObject.SelfEntity;

        private readonly ICard _humbleObject;

        public CardController(ICard humbleObject)
        {
            _humbleObject = humbleObject;
        }
    }
}