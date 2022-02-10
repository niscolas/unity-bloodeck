using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Bloodeck.View
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Card Viewer")]
    public class CardViewerMB : CachedMB
    {
        [Inject, SerializeField]
        private CardPlayerMB _cardPlayer;

        [SerializeField]
        private CardMB _currentCard;

        [SerializeField]
        private Transform _cardParent;

        [Header("[Settings]")]
        [SerializeField]
        private FloatReference _speed = new FloatReference(2);

        [SerializeField]
        private FloatReference _limit = new FloatReference(20);

        [SerializeField]
        private FloatReference _sizeFactor = new FloatReference(1);

        [SerializeField]
        private Image _dim;

        [Header(HeaderTitles.Debug)]
        [SerializeField]
        private BoolReference _isViewing = new BoolReference();

        public bool IsViewing
        {
            get => _isViewing.Value;
            private set => _isViewing.Value = value;
        }

        [Inject]
        private ISpawnService _spawnService;

        [Inject]
        private IDespawnService _despawnService;

        [Inject]
        private IPointerInputService _pointerInputService;

        private CardMB _currentViewing; // Temporary duplicate of "cardToView" for viewing...
        private float _rotationX = 0;
        private float _rotationY = 0;
        private float _rX = 0;
        private float _rY = 0;

        private void Update()
        {
            _rotationX -= _pointerInputService.PositionX * 4;
            _rotationX = Mathf.Clamp(_rotationX, -_limit, _limit);
            _rX = Mathf.Lerp(_rX, _rotationX, Time.deltaTime * _speed); // Final rotation for y

            _rotationY += _pointerInputService.PositionY * 4;
            _rotationY = Mathf.Clamp(_rotationY, -_limit, _limit);
            _rY = Mathf.Lerp(_rY, _rotationY, Time.deltaTime * _speed); // Final rotation for x

            // Rotate the object based on mouse movement:
            _cardParent.localEulerAngles = new Vector3(_rY, _rX, _cardParent.localEulerAngles.z);

            // Setting States:
            if (_currentCard)
            {
                _cardPlayer.IsMakingMove = false;
                IsViewing = true;
            }
            else
            {
                IsViewing = false;
            }

            // If we have assigned a card to view and an instance of it exists, then view it:
            if (_currentViewing)
            {
                if (_currentCard)
                {
                    _currentViewing.transform.localScale = new Vector3(_sizeFactor, _sizeFactor, _sizeFactor);
                }
                else
                {
                    // If the reference to the card no longer exists then destroy the instance:
                    _despawnService.Despawn(_currentViewing.gameObject);
                }
            }
            else
            {
                if (_currentCard)
                {
                    GameObject c = _spawnService.Spawn(
                        _currentCard.gameObject,
                        _cardParent.position,
                        _cardParent.rotation,
                        _cardParent);
                    _currentViewing = c.GetComponentInChildren<CardMB>();
                }
            }

            _dim.gameObject.SetActive(IsViewing && !_cardPlayer.IsMakingMove);
        }

        public void View(CardMB card)
        {
            _currentCard = card;
        }

        public void RemoveView()
        {
            _currentCard = null;
        }
    }
}