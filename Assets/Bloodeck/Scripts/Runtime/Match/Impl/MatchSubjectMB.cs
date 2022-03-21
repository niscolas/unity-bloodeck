﻿using System;
using niscolas.UnityUtils.Core;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    public class MatchSubjectMB : CachedMB
    {
        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private EntityMB _selfEntity;

        [Inject, SerializeField]
        private MatchMB _match;

        public event Action<ITurn> TurnStarted;
        public event Action<ITurn> SelfTurnStarted;
        public event Action<ITurn> OpponentTurnStarted;

        private void OnEnable()
        {
            _match.TurnStarted += Match_OnTurnStarted;
        }

        private void OnDisable()
        {
            _match.TurnStarted -= Match_OnTurnStarted;
        }

        private void Match_OnTurnStarted(ITurn turn)
        {
            TurnStarted?.Invoke(turn);

            if (_match.CheckAreOppositeTeams(_selfEntity.Team, turn.Team))
            {
                OpponentTurnStarted?.Invoke(turn);
            }
            else
            {
                SelfTurnStarted?.Invoke(turn);
            }
        }
    }
}