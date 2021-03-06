using FluentAssertions;
using NUnit.Framework;
using Zenject;

namespace Bloodeck.Tests.Editor
{
    [TestFixture]
    public class CardAttackTests : ZenjectUnitTestFixture
    {
        [Inject]
        private IEntityAttackComponent _reusableCardAttack;

        [Inject]
        private IEntityHealthComponent _reusableEntityHealthComponent;

        [SetUp]
        public void TestSetup()
        {
            EntityHealthControllerInstaller.Install(Container);
            CardAttackControllerInstaller.Install(Container);

            Container.Inject(this);
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
            _reusableEntityHealthComponent
                .WhichCanTakeDamage()
                .WithMax(10)
                .WithCurrent(10);
            _reusableCardAttack.WithAttackValue(attackValue);

            _reusableCardAttack.Attack(_reusableEntityHealthComponent);

            _reusableEntityHealthComponent.Current.Should().Be(10 - attackValue);
        }

        [TestCase(11)]
        [TestCase(12)]
        [TestCase(15)]
        [TestCase(20)]
        [TestCase(101)]
        public void Attack_AttackValueBiggerThan10_10CurrentHealth_CurrentHealthShouldBe0(
            int attackValue)
        {
            _reusableEntityHealthComponent
                .WhichCanTakeDamage()
                .WithMax(10)
                .WithCurrent(10);
            _reusableCardAttack.WithAttackValue(11);

            _reusableCardAttack.Attack(_reusableEntityHealthComponent);

            _reusableEntityHealthComponent.Current.Should().Be(0);
        }
    }
}