namespace Bloodeck
{
    public class CardProxy : ICard
    {
        public ICardComponents Components { get; }

        public int Cost { get; set; }

        public IEntity SelfEntity { get; }

        private readonly CardController _controller;

        public CardProxy(
            ICardComponents components, IEntity selfEntity, int cost = default)
        {
            _controller = new CardController(this);
            
            Components = components;
            Cost = cost;
            SelfEntity = selfEntity;
        }
    }
}