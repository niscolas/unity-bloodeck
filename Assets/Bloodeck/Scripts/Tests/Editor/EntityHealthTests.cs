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
        public void CommonInstall()
        {
            // Container.BindInstance((IEntityHealth) new EntityHealth(10, 10));
            Container.Inject(this);
        }

        [Test]
        public void TakeDamage_ArgIsBiggerThanCurrent_CurrentIs0()
        {
            _entityHealth.TakeDamage(_entityHealth.Max + 1);

            _entityHealth.Current.Should().Be(0);
        }
    }
}