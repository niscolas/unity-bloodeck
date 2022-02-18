using niscolas.UnityUtils.Core;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Bloodeck.View.VisualScripting
{
    public class CardVSEventsMB : CachedMB
    {
        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private CardOwnerStateListenerMB _cardOwnerStateListener;

        [Inject, SerializeField]
        private CardInDeckMB _cardInDeck;

        [Inject, SerializeField]
        private CardInHandMB _cardInHand;

        [Inject, SerializeField]
        private DeployableCardViewMB _deployableCard;

        public const string CardOwnerStateChangedCustomEventName = nameof(ICardPlayerStateNotifier.StateChanged);
        public const string DeployedCustomEventName = nameof(DeployableCardViewMB.Deployed);
        public const string CardInDeck_LinkedCustomEventName = nameof(CardInDeck_LinkedCustomEventName);
        public const string CardInDeck_UnlinkedCustomEventName = nameof(CardInDeck_UnlinkedCustomEventName);
        public const string CardInHand_LinkedCustomEventName = nameof(CardInHand_LinkedCustomEventName);
        public const string CardInHand_UnlinkedCustomEventName = nameof(CardInHand_UnlinkedCustomEventName);

        private void OnEnable()
        {
            _cardOwnerStateListener.OwnerStateChanged += CardOwnerStateListener_OnStateChanged;
            _cardInDeck.Linked += CardInDeck_OnLinked;
            _cardInDeck.Unlinked += CardInDeck_OnUnlinked;
            _cardInHand.Linked += CardInHand_OnLinked;
            _cardInHand.Unlinked += CardInHand_OnUnlinked;
            _deployableCard.Deployed += OnDeployed;
        }

        private void OnDisable()
        {
            _cardOwnerStateListener.OwnerStateChanged -= CardOwnerStateListener_OnStateChanged;
            _cardInDeck.Linked -= CardInDeck_OnLinked;
            _cardInDeck.Unlinked -= CardInDeck_OnUnlinked;
            _cardInHand.Linked -= CardInHand_OnLinked;
            _cardInHand.Unlinked -= CardInHand_OnUnlinked;
            _deployableCard.Deployed -= OnDeployed;
        }


        private void CardOwnerStateListener_OnStateChanged(ICardPlayerStateTag stateTag)
        {
            CustomEvent.Trigger(_gameObject, CardOwnerStateChangedCustomEventName, (CardPlayerStateTagSO) stateTag);
        }

        private void CardInDeck_OnLinked(DeckMB deck)
        {
            CustomEvent.Trigger(_gameObject, CardInDeck_LinkedCustomEventName);
        }

        private void CardInDeck_OnUnlinked()
        {
            CustomEvent.Trigger(_gameObject, CardInDeck_UnlinkedCustomEventName);
        }

        private void CardInHand_OnLinked(CardHandMB hand)
        {
            CustomEvent.Trigger(_gameObject, CardInHand_LinkedCustomEventName);
        }

        private void CardInHand_OnUnlinked()
        {
            CustomEvent.Trigger(_gameObject, CardInHand_UnlinkedCustomEventName);
        }

        private void OnDeployed()
        {
            CustomEvent.Trigger(_gameObject, DeployedCustomEventName);
        }
    }
}