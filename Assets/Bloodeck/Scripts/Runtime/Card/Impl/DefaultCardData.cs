namespace Bloodeck
{
    public class DefaultCardData : ICardData
    {
        public ICardComponents Components { get; }

        public int Cost { get; set; }

        public IEntity SelfEntity { get; }

        public ICardTemplate Template { get; }

        public DefaultCardData(
            ICardComponents components,
            IEntity selfEntity,
            ICardTemplate template,
            int cost = 0)
        {
            Components = components;
            Cost = cost;
            SelfEntity = selfEntity;
            Template = template;
        }
    }
}