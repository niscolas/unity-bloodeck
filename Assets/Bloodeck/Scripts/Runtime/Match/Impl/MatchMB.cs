﻿using System;
using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Bloodeck
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Match")]
    public class MatchMB : CachedMB, IMatch, IMatchHumbleObject
    {
        [SerializeField]
        private MatchState _state;

        [SerializeField]
        private SerializableTurn _currentTurn;

        [Header(HeaderTitles.Output)]
        [SerializeField]
        private IntReference _turnCountOutput = new IntReference(0);

        [Header(HeaderTitles.Injections)]
        [Inject, SerializeField]
        private List<CardPlayerMB> _players;

        public event Action<ITurn> TurnStarted;
        public event Action<ITurn> TurnEnded;

        public MatchState State => _state;

        public IList<ICardPlayer> Players => _players.Cast<ICardPlayer>().ToList();

        public ITurn CurrentTurn => _currentTurn;

        public int TurnCount => _turnCountOutput.Value;

        [Inject]
        private MatchController _controller;

        private void OnEnable()
        {
            _controller.TurnStarted += Controller_OnTurnStarted;
            _controller.TurnEnded += Controller_OnTurnEnded;
        }

        private void OnDisable()
        {
            _controller.TurnStarted -= Controller_OnTurnStarted;
            _controller.TurnEnded -= Controller_OnTurnEnded;
        }

        public ICardPlayer GetOpponent(ICardPlayer cardPlayer)
        {
            return _controller.GetOpponent(cardPlayer);
        }

        public bool CheckAreOppositeTeams(ITeam team, ITeam otherTeam)
        {
            return _controller.CheckAreOppositeTeams(team, otherTeam);
        }

        public void SetTurn(ITeam cardPlayerTeam)
        {
            _controller.SetTurn(cardPlayerTeam);
        }

        public void SetCurrentTurnFromCardPlayer(ICardPlayer cardPlayer)
        {
            _currentTurn = new SerializableTurn((CardPlayerMB) cardPlayer);
        }

        public void SetTurnCount(int value)
        {
            _turnCountOutput.Value = value;
        }

        private void Controller_OnTurnStarted(ITurn turn)
        {
            TurnStarted?.Invoke(turn);
        }

        private void Controller_OnTurnEnded(ITurn turn)
        {
            TurnEnded?.Invoke(turn);
        }
    }
}