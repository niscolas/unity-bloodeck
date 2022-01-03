using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Zenject;

namespace Qualitas.Tests.Editor
{
    [TestFixture]
    public class AttributesTests : ZenjectUnitTestFixture
    {
        [Inject]
        private IAttributes _attributes;

        private IAttribute _reusableMockAttribute;
        private IAttributeType _reusableMockAttributeType;

        [SetUp]
        public void CommonInstall()
        {
            Container.Bind<IAttributes>().To<SerializableAttributes>().AsSingle();
            Container.Inject(this);
        }

        [SetUp]
        public void LoadReusables()
        {
            _reusableMockAttribute = Substitute.For<IAttribute>();
            _reusableMockAttributeType = Substitute.For<IAttributeType>();
        }

        [Test]
        public void Add_SimpleAttribute_ShouldReturnTrue()
        {
            _attributes.Add(_reusableMockAttributeType, _reusableMockAttribute)
                .Should()
                .BeTrue();
        }

        [Test]
        public void Add_DuplicateAttributes_ShouldReturnFalse()
        {
            IAttribute duplicateAttribute = Substitute.For<IAttribute>();

            _attributes.Add(_reusableMockAttributeType, duplicateAttribute);

            _attributes.Add(_reusableMockAttributeType, duplicateAttribute)
                .Should()
                .BeFalse();
        }

        [Test]
        public void Add_NullParameters_ShouldThrowArgumentNullException()
        {
            _attributes
                .Invoking(a => a.Add(null, null))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Test]
        public void TryGet_SimpleAttributeType_SimpleAttribute_ShouldReturnTrue()
        {
            _attributes.Add(_reusableMockAttributeType, _reusableMockAttribute);

            _attributes
                .TryGet(_reusableMockAttributeType, out IAttribute _)
                .Should()
                .BeTrue();
        }

        [Test]
        public void TryGet_SimpleAttributeType_SimpleAttribute_OutParameterShouldReturnSimpleAttribute()
        {
            _attributes.Add(_reusableMockAttributeType, _reusableMockAttribute);

            _attributes.TryGet(_reusableMockAttributeType, out IAttribute attributeFound);

            attributeFound.Should().Be(_reusableMockAttribute);
        }

        [Test]
        public void TryGet_NoAttributes_ShouldReturnFalse()
        {
            _attributes
                .TryGet(_reusableMockAttributeType, out IAttribute _)
                .Should()
                .BeFalse();
        }

        
        [Test]
        public void TryGet_NullParameters_ShouldThrowArgumentNullException()
        {
            _attributes
                .Invoking(a => a.TryGet(null, out IAttribute _))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}
