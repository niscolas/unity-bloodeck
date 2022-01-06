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
        public void TakeDamage_CurrentIs10_ArgIsBetween1And10_CurrentShouldBeCurrentMinusArg(
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
        public void TakeDamage_CurrentIs10_ArgIsBiggerOrEqualTo10_CurrentShouldBe0(
            int damageValue)
        {
            _entityHealth.WithMax(10).WithCurrent(10);
            
            _entityHealth.TakeDamage(damageValue);

            _entityHealth.Current.Should().Be(0);
        }

        public void TakeDamage_CurrentIs10_ArgIs0_CurrentShouldBe10()
        {
            _entityHealth.WithMax(10).WithCurrent(10);
            
            _entityHealth.TakeDamage(0);

            _entityHealth.Current.Should().Be(10);
        }
    }
}