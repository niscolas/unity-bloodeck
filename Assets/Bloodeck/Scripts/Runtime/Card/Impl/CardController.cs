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

        public ICardTemplate Template
        {
            get => _humbleObject.Template;
            set => _humbleObject.Template = value;
        }

        private readonly ICardData _humbleObject;

        public CardController(ICardData humbleObject)
        {
            _humbleObject = humbleObject;
        }

        public void LoadTemplate(ICardTemplate template)
        {
            Template = template;
            SelfEntity.LoadTemplate(template.SelfEntityTemplate);
        }
    }
}