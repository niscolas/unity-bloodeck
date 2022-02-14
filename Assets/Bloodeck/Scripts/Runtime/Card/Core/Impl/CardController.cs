using System;

namespace Bloodeck
{
    public class CardController : ICard
    {
        public event Action Destroyed;

        public int Cost
        {
            get => _humbleObject.Cost;
            set => _humbleObject.Cost = value;
        }

        public IEntity SelfEntity => _humbleObject.SelfEntity;

        public ICardSlot Slot => _humbleObject.Slot;

        public ICardEffectMap Effects => _humbleObject.Effects;

        public IDeployableCard Deployable => _humbleObject.Deployable;

        public ICardPlayer Owner
        {
            get => _humbleObject.Owner;
            set => _humbleObject.Owner = value;
        }

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

        public void Destroy()
        {
            Destroy(null);
        }

        public void Destroy(Action callback)
        {
            Destroyed?.Invoke();
        }

        private void SetTemplate(ICardTemplate template)
        {
            _humbleObject.SetHumbleObjectLoadedTemplate(template);
        }
    }
}