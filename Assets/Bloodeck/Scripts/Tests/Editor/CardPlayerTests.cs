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

        [Inject]
        private ICardSlot _cardSlot;

        [SetUp]
        public void TestSetup()
        {
            Container
                .Bind<ICardSlot>()
                .FromSubstitute()
                .AsSingle()
                .OnInstantiated(
                    (InjectContext context, ICardSlot cardSlotSubstitute) =>
                    {
                        cardSlotSubstitute
                            .TrySetCard(default)
                            .ReturnsForAnyArgs(true);
                    });

            Container
                .Bind<ICollection<ICard>>()
                .FromInstance(
                    new List<ICard>
                    {
                        Substitute.For<ICard>(),
                        Substitute.For<ICard>(),
                        Substitute.For<ICard>(),
                        Substitute.For<ICard>(),
                        Substitute.For<ICard>()
                    }
                )
                .AsTransient();

            Container
                .Bind<ICards>()
                .To<Cards>()
                .AsTransient()
                .WhenInjectedInto<ICardPlayerData>();

            Container
                .Bind<ICardPlayerData>()
                .To<CardPlayerData>()
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
            ICard firstCardSubstitute = _cardPlayer.Cards.First();
            firstCardSubstitute.Substitute_WithCost(2);
            _cardPlayer.WithEnergy(1);

            _cardPlayer
                .TryPlaceCard(firstCardSubstitute, _cardSlot)
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
            ICard firstCardSubstitute = _cardPlayer.Cards.First();
            firstCardSubstitute.Substitute_WithCost(energyAndCardCost);
            _cardPlayer.WithMaxEnergy(energyAndCardCost).WithEnergy(energyAndCardCost);

            _cardPlayer
                .TryPlaceCard(firstCardSubstitute, _cardSlot)
                .Should()
                .BeTrue();
        }
        
        [Test]
        public void TryPlaceCard_Energy1_CardCost1_ReturnShouldBeTrue()
        {
            ICard firstCardSubstitute = _cardPlayer.Cards.First();
            firstCardSubstitute.Substitute_WithCost(1);
            _cardPlayer.WithMaxEnergy(1).WithEnergy(1);

            _cardPlayer
                .TryPlaceCard(firstCardSubstitute, _cardSlot)
                .Should()
                .BeTrue();
        }

        [Test]
        public void TryPlaceCard_SimpleArgs_EnergyShouldBeInitialEnergyMinusCardCost()
        {
            ICard firstCardSubstitute = _cardPlayer.Cards.First();
            firstCardSubstitute.Substitute_WithCost(3);
            _cardPlayer.WithMaxEnergy(5).WithEnergy(5);

            _cardPlayer.TryPlaceCard(firstCardSubstitute, _cardSlot);

            _cardPlayer.Energy.Should().Be(2);
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