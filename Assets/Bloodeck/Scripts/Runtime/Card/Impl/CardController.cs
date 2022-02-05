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

        public ICardTemplate LoadedTemplate => _humbleObject.LoadedTemplate;

        private readonly ICardHumbleObject _humbleObject;

        public CardController(ICardHumbleObject humbleObject)
        {
            _humbleObject = humbleObject;
        }

        public void LoadTemplate(ICardTemplate template)
        {
            SelfEntity.LoadTemplate(template.SelfEntityTemplate);
            SetTemplate(template);
        }

        private void SetTemplate(ICardTemplate template)
        {
            _humbleObject.SetHumbleObjectLoadedTemplate(template);
        }
    }
}