using FluentAssertions;
using NUnit.Framework;
using Zenject;

namespace Bloodeck.Tests.Editor
{
    public class EntityHealthTests : ZenjectUnitTestFixture
    {
        [Inject]
        private IEntityHealth _entityHealth;

        [SetUp]
        public void TestSetup()
        {
            EntityProxy.ResetCreationCounter();
            ZenjectInstall();
        }

        private void ZenjectInstall()
        {
            EntityProxyInstaller.Install(Container);
            FullEntityHealthProxyInstaller.Install(Container);

            Container.Inject(this);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        public void TakeDamage_Current10_Max10_ArgBetween1And10_CurrentShouldBeCurrentMinusArg(
            int damageValue)
        {
            _entityHealth.WithMax(10).WithCurrent(10);
            
            _entityHealth.TakeDamage(damageValue);

            _entityHealth.Current.Should().Be(10 - damageValue);
        }

        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(15)]
        [TestCase(20)]
        [TestCase(100)]
        public void TakeDamage_Current10_Max10_ArgBiggerOrEqualTo10_CurrentShouldBe0(
            int damageValue)
        {
            _entityHealth.WithMax(10).WithCurrent(10);
            
            _entityHealth.TakeDamage(damageValue);

            _entityHealth.Current.Should().Be(0);
        }

        [Test]
        public void TakeDamage_Current10_Max10_Arg0_CurrentShouldBe10()
        {
            _entityHealth.WithMax(10).WithCurrent(10);
            
            _entityHealth.TakeDamage(0);

            _entityHealth.Current.Should().Be(10);
        }
        
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        public void Heal_Current1_Max10_ArgBetween0And9_CurrentShouldBeInitialHealthPlusArg(
            int healValue)
        {
            _entityHealth.WithMax(10).WithCurrent(1);
            
            _entityHealth.Heal(healValue);

            _entityHealth.Current.Should().Be(1 + healValue);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(10)]
        public void Heal_Current10_Max10_ArgBiggerOrEqualTo0_CurrentShouldBe10(
            int healValue)
        {
            _entityHealth.WithMax(10).WithCurrent(10);
            
            _entityHealth.Heal(healValue);

            _entityHealth.Current.Should().Be(10);
        }

        [Test]
        public void Heal_Current5_Max10_Arg0_CurrentShouldBe5()
        {
            
            _entityHealth.WithMax(10).WithCurrent(5);
            
            _entityHealth.Heal(0);

            _entityHealth.Current.Should().Be(5);
        }
    }
}