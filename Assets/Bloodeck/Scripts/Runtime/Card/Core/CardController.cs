namespace Bloodeck
{
    public class CardController : ICard
    {
        public ICardComponents Components => _humbleObject.Components;

        public int Cost
        {
            get => _humbleObject.Cost;
            set => _humbleObject.Cost = value;
        }

        public IEntity SelfEntity => _humbleObject.SelfEntity;

        private readonly ICard _humbleObject;

        public CardController(ICard humbleObject)
        {
            _humbleObject = humbleObject;
        }
    }
}