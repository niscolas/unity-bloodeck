using System;
using System.Collections.Generic;
using FluentAssertions;
using Healthy;
using NUnit.Framework;
using Zenject;

namespace Bloodeck.Tests.Editor
{
    [TestFixture]
    public class CardAttackTests : ZenjectUnitTestFixture
    {
        [Inject]
        private ICardAttack _reusableCardAttack;

        [Inject]
        private IEntityHealth _reusableEntityHealth;

        [SetUp]
        public void CommonInstall()
        {
            EntityHealthInstall();
            CardAttackInstall();
            Container.Inject(this);
        }

        private void EntityHealthInstall()
        {
            Container
                .Bind<IHealth>()
                .FromMethod(context => new HealthController(context.ObjectInstance as IHealth))
                .AsSingle()
                .WhenInjectedInto(typeof(EntityHealthProxy))
                .NonLazy();

            Container
                .Bind<IDictionary<Type, IEntityComponent>>()
                .FromInstance(new Dictionary<Type, IEntityComponent>())
                .NonLazy();

            Container.Bind<IEntityComponents>().To<EntityComponents>().AsSingle().NonLazy();

            Container.Bind<IEntity>()
                .To<EntityProxy>()
                .WithArguments("Target Entity")
                .WhenInjectedInto(typeof(EntityHealthProxy))
                .NonLazy();

            Container
                .Bind<IEntityHealth>()
                .To<EntityHealthProxy>()
                .AsSingle()
                .OnInstantiated(
                    (InjectContext context, IEntityHealth entityHealth) =>
                    {
                        entityHealth.SelfEntity.Components.Add(entityHealth);
                    })
                .NonLazy();
        }

        private void CardAttackInstall()
        {
            Container
                .Bind<IEntity>()
                .To<EntityProxy>()
                .WithArguments("Card Attack Entity")
                .WhenInjectedInto(typeof(CardProxy))
                .NonLazy();

            Container
                .Bind<IDictionary<Type, ICardComponent>>()
                .FromInstance(new Dictionary<Type, ICardComponent>())
                .AsSingle()
                .NonLazy();

            Container.Bind<ICardComponents>().To<CardComponents>().AsSingle().NonLazy();

            Container.Bind<ICard>().To<CardProxy>().AsSingle().NonLazy();

            Container
                .Bind<ICardAttack>()
                .To<CardAttackProxy>()
                .AsSingle()
                .OnInstantiated(
                    (InjectContext context, ICardAttack cardAttack) =>
                    {
                        cardAttack.SelfCard.Components.Add(cardAttack);
                    })
                .NonLazy();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        public void Attack_AttackValueBetween0And10_10CurrentHealth_CurrentHealthShouldBeInitialHealthMinusAttackValue(
            int attackValue)
        {
            _reusableEntityHealth.WithMax(10).WithCurrent(10);
            _reusableCardAttack.WithAttackValue(attackValue);

            _reusableCardAttack.Attack(_reusableEntityHealth);

            _reusableEntityHealth.Current.Should().Be(10 - attackValue);
        }

        [TestCase(11)]
        [TestCase(12)]
        [TestCase(15)]
        [TestCase(20)]
        [TestCase(101)]
        public void Attack_AttackValueBiggerThan10_10CurrentHealth_CurrentHealthShouldBe0(
            int attackValue)
        {
            _reusableEntityHealth.WithMax(10).WithCurrent(10);
            _reusableCardAttack.WithAttackValue(11);

            _reusableCardAttack.Attack(_reusableEntityHealth);

            _reusableEntityHealth.Current.Should().Be(0);
        }
    }
}