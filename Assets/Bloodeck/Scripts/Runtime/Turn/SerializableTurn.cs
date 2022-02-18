using System;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class SerializableTurn : ITurn
    {
        [SerializeField]
        private CardPlayerMB _player;

        public ITeam Team => _player.SelfEntity.Team;
        public ICardPlayer Player => _player;

        public SerializableTurn(CardPlayerMB player)
        {
            _player = player;
        }
    }
}