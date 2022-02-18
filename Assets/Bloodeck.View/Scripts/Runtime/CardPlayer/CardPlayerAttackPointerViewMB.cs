using System;
using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Bloodeck.View
{
    public class CardPlayerAttackPointerViewMB : CachedMB
    {
        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent<CardMB> _onCardSelected;

        [field: Header(HeaderTitles.Debug)]
        [field: SerializeField]
        public CardMB SelectedCard { get; private set; }

        [field: SerializeField]
        public CardMB TargetCard { get; private set; }

        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private MatchMB _match;

        [Inject, SerializeField]
        private CardPlayerMB _cardPlayer;

        public event Action<CardMB> CardSelected;

        [Inject]
        private IPointerInputService _pointerInputService;

        public bool SelectPointedCard()
        {
            if (!TryGetCardViaRaycast(out CardMB selectedCard))
            {
                return false;
            }

            SelectedCard = selectedCard;
            NotifyCardSelected();

            return true;
        }

        public void DeselectCard()
        {
            SelectedCard = default;
        }

        public bool TryAttackPointedCard()
        {
            if (!TrySelectPointedTarget())
            {
                return false;
            }

            SelectedCard.SelfEntity.Components.TryGet(out EntityAttackComponentMB entityAttackComponent);
            entityAttackComponent.Attack(TargetCard.SelfEntity);

            return true;
        }

        public bool TrySelectPointedTarget()
        {
            if (!TryGetCardViaRaycast(out CardMB targetCard) ||
                !CheckCanAttack(targetCard))
            {
                return false;
            }

            TargetCard = targetCard;

            return true;
        }

        private bool TryGetCardViaRaycast(out CardMB card)
        {
            card = default;
            return TryFindCardViaRaycast(out RaycastHit[] raycastHits) &&
                   TryGetCardComponent(raycastHits, out card);
        }

        private bool CheckCanAttack(CardMB targetCard)
        {
            return _match.CheckAreOppositeTeams(
                _cardPlayer.SelfEntity.Team, targetCard.SelfEntity.Team);
        }

        private static bool TryGetCardComponent(RaycastHit[] raycastHits, out CardMB targetCard)
        {
            targetCard = raycastHits.GetNearestRaycastHit().collider.GetComponentInChildren<CardMB>();
            return targetCard;
        }

        private bool TryFindCardViaRaycast(out RaycastHit[] raycastHits)
        {
            raycastHits = _pointerInputService.ShootRaycastFromPointerPosition();
            if (raycastHits.CheckIsEmpty())
            {
                return false;
            }

            return true;
        }

        private void NotifyCardSelected()
        {
            CardSelected?.Invoke(SelectedCard);
            _onCardSelected?.Invoke(SelectedCard);
        }
    }
}