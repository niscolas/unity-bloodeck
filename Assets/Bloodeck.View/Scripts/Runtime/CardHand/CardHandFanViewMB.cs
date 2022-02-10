using System;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck.View
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + DisplayName)]
    public class CardHandFanViewMB : CachedMB
    {
        [Header(HeaderTitles.Settings)]
        [SerializeField]
        private FloatReference _hiddenPositionOffset = new FloatReference(100f);

        [SerializeField]
        private FloatReference _speed = new FloatReference(13f);

        [SerializeField]
        private FloatReference _spread = new FloatReference(4f);

        [SerializeField]
        private FloatReference _tilt = new FloatReference(10f);

        [SerializeField]
        private FloatReference _yFactor = new FloatReference(10f);

        [SerializeField]
        private FloatReference _hoverHeight = new FloatReference(4f);

        [SerializeField]
        private Vector3Reference _initialPosition = new Vector3Reference(Vector3.zero);

        [SerializeField]
        private Color _selectedColor;

        [SerializeField]
        private Color _notSelectedColor;

        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private CardHandMB _cardHand;

        [Inject, SerializeField]
        private MatchMB _match;

        [Inject, SerializeField]
        private CardPlayerMB _player;

        [Inject, SerializeField]
        private CardViewerMB _cardViewer;

        [Inject, SerializeField]
        private CardDraggerMB _cardDragger;

        private Vector3 InitialPosition => _initialPosition.Value;

        public const string DisplayName = "Card Hand (Fan) View";

        private readonly CardHandFanDataMap _dataMap = new CardHandFanDataMap();

        [Inject]
        private IUnityTimeService _timeService;

        private Vector3 _hiddenPosition;
        private int _selectedIndex;

        [Inject]
        private void Init(CardHandMB cardHand)
        {
            _cardHand = cardHand;
            _cardHand.Added += CardHand_OnAdded;
            _cardHand.Removed += CardHand_OnRemoved;
        }

        private void Start()
        {
            _initialPosition.Value = _transform.position;
            _hiddenPosition = _transform.TransformPoint(Vector3.down * _hiddenPositionOffset.Value);
        }

        private void Update()
        {
            Legacy_Update();
        }

        private void Legacy_Update()
        {
            for (int i = 0; i < _cardHand.Count; i++)
            {
                DeployableCardMB deployableCard = _dataMap[_cardHand[i]].DeployableCard;
                if (deployableCard.IsDeployed || deployableCard.IsDeploying)
                {
                    _cardHand.Remove(_cardHand[i]);
                }
            }

            // Limit the selection:
            _selectedIndex = Mathf.Clamp(_selectedIndex, 0, _cardHand.Count - 1);

            if (_cardHand.Count > 0)
            {
                // Calcutate the spread and the Y for card's positioning:
                float curIndPos = _spread / _cardHand.Count;
                float initY = -1f * (_yFactor / 2f);
                float curY = _yFactor / (_cardHand.Count - 1);
                // Calculate the rotation of the cards:
                float initTilt = -1f * (_tilt / 2f);
                float curTilt = _tilt / (_cardHand.Count - 1);

                for (int i = 0; i < _cardHand.Count; i++)
                {
                    CardMB currentCard = _dataMap[_cardHand[i]].CardMB;
                    DraggableCardMB draggableCard = _dataMap[_cardHand[i]].DraggableCard;
                    if (draggableCard.IsBeingDragged)
                    {
                        continue;
                    }

                    HoverableCardMB hoverableCard = _dataMap[_cardHand[i]].HoverableCard;
                    EntityGraphicMB cardFrameImageView = _dataMap[_cardHand[i]].Graphic;
                    Transform cardTransform = currentCard.transform;

                    // Card Depth Tweaking:
                    if (_cardHand.Count > 1)
                    {
                        if (hoverableCard.IsBeingHovered)
                        {
                            cardTransform.SetAsLastSibling();
                        }
                        else
                        {
                            cardTransform.SetAsFirstSibling();
                        }
                    }

                    // Card's Positioning:
                    if (_cardHand.Count > 1)
                    {
                        float yForThisCard = initY + (i * curY);
                        float nudgeThisCard = Mathf.Abs(yForThisCard);
                        nudgeThisCard *= _yFactor + (i == 0 || i == _cardHand.Count - 1 ? _yFactor * 0.5f : 0);

                        cardTransform.localPosition = Vector3.Lerp(
                            cardTransform.localPosition,
                            new Vector3(
                                (curIndPos * (i + 1)) - ((curIndPos / 2) * (_cardHand.Count + 1)),
                                (hoverableCard.IsBeingHovered && !_cardViewer.IsViewing
                                    ? _hoverHeight - nudgeThisCard
                                    : -nudgeThisCard)),
                            _timeService.DeltaTime * _speed);
                    }
                    else
                    {
                        cardTransform.localPosition = Vector3.Lerp(
                            cardTransform.localPosition,
                            new Vector3(0, _yFactor),
                            _timeService.DeltaTime * _speed);
                    }


                    // Card's Rotation:
                    if (_cardHand.Count > 1)
                    {
                        float tiltForThisCard = initTilt + (i * curTilt);
                        cardTransform.localRotation = Quaternion.RotateTowards(
                            cardTransform.localRotation,
                            Quaternion.Euler(new Vector3(0f, 0f, -tiltForThisCard)),
                            _timeService.DeltaTime * (_speed * 5));
                    }
                    else
                    {
                        cardTransform.localRotation = Quaternion.identity;
                    }

                    // Card's Coloring:
                    cardFrameImageView.Color = Color.Lerp(
                        cardFrameImageView.Color,
                        hoverableCard.IsBeingHovered && !_cardViewer.IsViewing ? _selectedColor : _notSelectedColor,
                        Time.deltaTime * _speed);

                    ScaleCard(i);
                }
            }

            if (_match.State != MatchState.NotStarted)
            {
                if (CheckIsLinkedPlayerTurn() || !_player.IsDrawingStartingCards)
                {
                    _transform.position = Vector3.Lerp(
                        _transform.position,
                        _player.IsMakingMove || _cardDragger.IsDragging
                            ? _hiddenPosition
                            : InitialPosition,
                        _timeService.DeltaTime * 10);
                }
                else
                {
                    _transform.position = Vector3.Lerp(
                        _transform.position,
                        _hiddenPosition,
                        _timeService.DeltaTime * 10);
                }
            }
            else
            {
                _transform.position = _hiddenPosition;
            }
        }

        private void OnDestroy()
        {
            _cardHand.Added -= CardHand_OnAdded;
            _cardHand.Removed -= CardHand_OnRemoved;
        }

        private void ScaleCard(int i)
        {
            Transform cardTransform = _dataMap[_cardHand[i]].CardMB.transform;
            HoverableCardMB hoverableCard = _dataMap[_cardHand[i]].HoverableCard;

            cardTransform.localScale = Vector3.Lerp(
                cardTransform.localScale,
                hoverableCard.IsBeingHovered && !_cardViewer.IsViewing
                    ? new Vector3(0.8f, 0.8f, 0.8f)
                    : new Vector3(0.7f, 0.7f, 0.7f), Time.deltaTime * _speed);
        }

        private void CardHand_OnAdded(ICard card)
        {
            CardMB cardMB = (CardMB) card;
            _dataMap.Add(card, new CardHandFanData
            {
                CardMB = cardMB,
                DeployableCard = cardMB.GetComponentInChildren<DeployableCardMB>(),
                DraggableCard = cardMB.GetComponentInChildren<DraggableCardMB>(),
                Graphic = cardMB.GetComponentInChildren<EntityIconImageViewMB>(),
                HoverableCard = cardMB.GetComponentInChildren<HoverableCardMB>()
            });

            cardMB.transform.SetParent(_transform);
            cardMB.gameObject.SetActive(true);
        }

        private void CardHand_OnRemoved(ICard card)
        {
            _dataMap.Remove(card);
        }

        private bool CheckIsLinkedPlayerTurn()
        {
            return (CardPlayerMB) _match.CurrentTurn.Player == _player;
        }
    }
}