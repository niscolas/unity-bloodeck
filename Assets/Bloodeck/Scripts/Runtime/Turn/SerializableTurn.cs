using System;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class SerializableTurn : ITurn
    {
        [SerializeField]
        private CardPlayerMB _player;

        public ICardPlayer Player => _player;
    }
}