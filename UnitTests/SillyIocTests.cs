using ClassLibrary1;
using NUnit.Framework;
using System;

namespace UnitTests
{
    public class SillyIocTests
    {
        private TunaIoc _tuna = new TunaIoc();

        [Test]
        public void CanonicalResolution()
        {
            IRegistry registry = _tuna;
            IResolver resolver = _tuna;

            registry.Register<Sha1>();

            var resolved = resolver.Resolve<Sha1>();
            Assert.IsInstanceOf<Sha1>(resolved);
        }

        [Test]
        public void CanResolveInterface()
        {
            IRegistry registry = _tuna;
            IResolver resolver = _tuna;


            registry.Register<Sha1>();

            var resolved = resolver.Resolve<IChecksum>();
            Assert.IsInstanceOf<Sha1>(resolved);
        }

        [Test]
        public void CantResolveInterfaceWhenMultipleCandidatesExist()
        {
            IRegistry registry = _tuna;
            IResolver resolver = _tuna;

            registry.Register<Sha1>();
            registry.Register<Md5>();

            Assert.Catch<Exception>(() =>
            {
               resolver.Resolve<IChecksum>();
            });
        }
    }
}