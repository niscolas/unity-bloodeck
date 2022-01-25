﻿using System;
using Creatable;
using NaughtyAttributes;
using SerializableDictionary;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Bloodeck
{
    [CreateAssetMenu(
        fileName = "Card",
        menuName = Constants.CreateAssetMenuPrefix + "Card",
        order = Constants.CreateAssetMenuOrder)]
    public class CardTemplateSO : ScriptableObject, ICardTemplate
    {
        [Expandable, Creatable, SerializeField]
        private EntityTemplateSO _selfEntityTemplate;

        [Expandable, Creatable, SerializeField]
        private CardRaritySO _rarity;

        [SerializeReference, SubclassSelector]
        private ICardEffectMap _effectMap = new CardEffectMap();

        [SerializeField]
        private TestDict _testDicta = new TestDict();

        [SerializeReference, SubclassSelector]
        private ICardComponentTemplates _componentTemplates;

        [SerializeField]
        private IntReference _cost = new IntReference(1);

        public ICardComponentTemplates ComponentTemplates => _componentTemplates;

        public int Cost => _cost.Value;

        public ICardEffectMap EffectMap => _effectMap;

        public EntityTemplateSO SelfEntityTemplateSO => _selfEntityTemplate;

        public IEntityTemplate SelfEntityTemplate => _selfEntityTemplate;
    }
}