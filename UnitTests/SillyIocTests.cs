using ClassLibrary1;
using NUnit.Framework;
using System;

namespace UnitTests
{
    public class SillyIocTests
    {
        [Test]
        public void CanonicalResolution()
        {
            IRegistry registry = null;
            IResolver resolver = null;

            registry.Register<Sha1>();

            var resolved = resolver.Resolve<Sha1>();
            Assert.IsInstanceOf<Sha1>(resolved);
        }

        [Test]
        public void CanResolveInterface()
        {
            IRegistry registry = null;
            IResolver resolver = null;

            registry.Register<Sha1>();

            var resolved = resolver.Resolve<IChecksum>();
            Assert.IsInstanceOf<Sha1>(resolved);
        }

        [Test]
        public void CantResolveInterfaceWhenMultipleCandidatesExist()
        {
            IRegistry registry = null;
            IResolver resolver = null;

            registry.Register<Sha1>();
            registry.Register<Md5>();

            Assert.Throws<Exception>(() =>
           {
               resolver.Resolve<IChecksum>();
           });
        }
    }
}