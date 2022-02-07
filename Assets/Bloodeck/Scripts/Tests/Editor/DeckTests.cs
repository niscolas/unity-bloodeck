using System.Collections.Generic;
using Bloodeck.Tests.Utils;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Zenject;

namespace Bloodeck.Tests.Editor
{
    [TestFixture]
    public class DeckTests : ZenjectUnitTestFixture
    {
        [Inject]
        private IDeck _deck;

        private IList<ICard> _cardList = new List<ICard>();

        [SetUp]
        public void TestSetup()
        {
            IDeckHumbleObject deckDataSub = Substitute.For<IDeckHumbleObject>();

            deckDataSub.Cards.WithListFeaturesOf(_cardList);

            Container
                .Bind<IDeckHumbleObject>()
                .FromInstance(deckDataSub)
                .AsSingle()
                .WhenInjectedInto(typeof(IDeck));

            Container
                .Bind<IDeck>()
                .To<DeckController>()
                .AsSingle();

            Container.Inject(this);
        }

        [Test]
        public void DrawFromTop_DeckWithSingleCard_ShouldBeEmpty()
        {
            _deck.Cards.Add(Substitute.For<ICard>());

            _deck.DrawFromTop();

            _deck.Cards.Count.Should().Be(0);
        }

        [Test]
        public void DrawFromTop_DeckWithSingleCard_ReturnShouldBeTheCard()
        {
            ICard expected = Substitute.For<ICard>();
            _deck.Cards.Add(expected);

            ICard actual = _deck.DrawFromTop();

            actual.Should().Be(expected);
        }

        [Test]
        public void DrawFromTop_DeckWithThreeCards_ReturnShouldBeTheTopCard()
        {
            ICard topCard = Substitute.For<ICard>();
            ICard middleCard = Substitute.For<ICard>();
            ICard bottomCard = Substitute.For<ICard>();
            _deck.Cards.Add(topCard);
            _deck.Cards.Add(middleCard);
            _deck.Cards.Add(bottomCard);

            ICard actual = _deck.DrawFromTop();

            actual.Should().Be(topCard);
        }
    }
}