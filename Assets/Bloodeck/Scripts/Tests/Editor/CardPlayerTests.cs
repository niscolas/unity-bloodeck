using System.Collections.Generic;
using System.Linq;
using Bloodeck.Tests.Utils;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Zenject;

namespace Bloodeck.Tests.Editor
{
    [TestFixture]
    public class CardPlayerTests : ZenjectUnitTestFixture
    {
        [Inject]
        private ICardPlayer _cardPlayer;

        [SetUp]
        public void TestSetup()
        {
            ICardSlot cardSlotSub = Substitute.For<ICardSlot>();
            cardSlotSub.TrySetCard(default).ReturnsForAnyArgs(true);

            IList<ICardSlot> cardSlotList = new List<ICardSlot> {cardSlotSub};
            ICardSlots cardSlotsSub = Substitute.For<ICardSlots>()
                .WithGetEnumeratorReturning(cardSlotList)
                .WithContainsReturning(cardSlotList);

            ICardPlayerEnvironment cardPlayerEnvironmentSub = Substitute.For<ICardPlayerEnvironment>()
                .Sub_WithSlots(cardSlotsSub);

            IList<ICard> cardList = new List<ICard> {Substitute.For<ICard>()};
            ICards cardsSub = Substitute.For<ICards>()
                .WithGetEnumeratorReturning(cardList)
                .WithContainsReturning(cardList);

            Container
                .Bind<ICardPlayerData>()
                .FromInstance(
                    new CardPlayerData(cardsSub, cardPlayerEnvironmentSub))
                .AsTransient()
                .WhenInjectedInto<CardPlayerController>();

            Container
                .Bind<ICardPlayer>()
                .To<CardPlayerController>()
                .AsSingle();

            Container.Inject(this);
        }

        [Test]
        public void TryPlaceCard_Energy1_CardCost2_ReturnShouldBeFalse()
        {
            ICard firstCardSub = _cardPlayer.Cards.First().Sub_WithCost(2);
            ICardSlot firstCardSlotSub = _cardPlayer.Environment.Slots.ElementAt(0);
            _cardPlayer.WithEnergy(1);

            _cardPlayer
                .TryPlaceCard(firstCardSub, firstCardSlotSub)
                .Should()
                .BeFalse();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        public void TryPlaceCard_EnergyEqualToCardCost_ReturnShouldBeTrue(
            int energyAndCardCost)
        {
            ICard firstCardSub = _cardPlayer.Cards.First().Sub_WithCost(energyAndCardCost);
            ICardSlot firstCardSlotSub = _cardPlayer.Environment.Slots.ElementAt(0);
            _cardPlayer.WithMaxEnergy(energyAndCardCost).WithEnergy(energyAndCardCost);

            _cardPlayer
                .TryPlaceCard(firstCardSub, firstCardSlotSub)
                .Should()
                .BeTrue();
        }

        [Test]
        public void TryPlaceCard_Energy1_CardCost1_ReturnShouldBeTrue()
        {
            ICard firstCardSub = _cardPlayer.Cards.First().Sub_WithCost(1);
            ICardSlot firstCardSlotSub = _cardPlayer.Environment.Slots.ElementAt(0);
            _cardPlayer.WithMaxEnergy(1).WithEnergy(1);

            _cardPlayer
                .TryPlaceCard(firstCardSub, firstCardSlotSub)
                .Should()
                .BeTrue();
        }

        [Test]
        public void TryPlaceCard_SimpleArgs_EnergyShouldBeInitialEnergyMinusCardCost()
        {
            ICard firstCardSub = _cardPlayer.Cards.First().Sub_WithCost(3);
            ICardSlot firstCardSlotSub = _cardPlayer.Environment.Slots.ElementAt(0);
            _cardPlayer.WithMaxEnergy(5).WithEnergy(5);

            _cardPlayer.TryPlaceCard(firstCardSub, firstCardSlotSub);

            _cardPlayer.Energy.Should().Be(2);
        }

        [Test]
        public void TryPlaceCard_DoesntOwnCardButOwnsCardSlot_ReturnShouldBeFalse()
        {
            ICard cardSub = Substitute.For<ICard>();
            ICardSlot cardSlotSub = _cardPlayer.Environment.Slots.First();

            _cardPlayer
                .TryPlaceCard(cardSub, cardSlotSub)
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryPlaceCard_DoesntOwnCardSlotButOwnsCard_ReturnShouldBeFalse()
        {
            ICard cardSub = _cardPlayer.Cards.First();
            ICardSlot cardSlotSub = Substitute.For<ICardSlot>();

            _cardPlayer
                .TryPlaceCard(cardSub, cardSlotSub)
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryPlaceCard_DoesntOwnCardAndDoesntOwnCardSlot_ReturnShouldBeFalse()
        {
            ICard cardSub = Substitute.For<ICard>();

            ICardSlot cardSlotSub = Substitute.For<ICardSlot>();
            cardSlotSub.TrySetCard(default).ReturnsForAnyArgs(true);

            _cardPlayer
                .TryPlaceCard(cardSub, cardSlotSub)
                .Should()
                .BeFalse();
        }

        [Test]
        public void Energy_ArgNegative_EnergyShouldBe0()
        {
            _cardPlayer.WithMaxEnergy(5).WithEnergy(-1);

            _cardPlayer.Energy.Should().Be(0);
        }

        [Test]
        public void Energy_ArgHigherThanMaxEnergy_EnergyShouldBeMaxEnergy()
        {
            _cardPlayer.WithMaxEnergy(5).WithEnergy(7);

            _cardPlayer.Energy.Should().Be(5);
        }
    }
}