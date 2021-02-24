using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsoleCoreApp1
{
    public class Runner
    {
        Assembly _assembly;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly">The assembly containing tests to be executed</param>
        public Runner(Assembly assembly)
        {
            _assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
        }

        /// <summary>
        /// Run the tests and return a list of test results
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TestResult> Run()
        {
            var testResults = ScanForFixtures().SelectMany(f => RunTests(f));

            foreach (var result in testResults)
            {
                yield return result;
            }
        }

        private IEnumerable<TestResult> RunTests(Type fixtureType)
        {
            //Local method
            bool IsTestMethod(MethodInfo method)
            {
                bool hasParameters = method.GetParameters().Any();
                bool isVoid = method.ReturnType == typeof(void);
                return method.IsPublic && !hasParameters && isVoid;
            }

            if (!TryGetConstructor(fixtureType, out var constructor))
            {
                yield return TestResult.Failure(fixtureType.FullName, "Cannot create fixture, add an empty constructor");
                yield break;
            }

            var tests = fixtureType.GetMethods().Where(IsTestMethod).ToList();
            foreach(var testMethod in tests)
            {
                var failures = new List<string>();
                var testName = testMethod.Name;
                try
                {
                    //create a new instance of the fixture for each test to guarantee isolation
                    var fixture = (TestFixture) constructor.Invoke();
                    fixture.AssertionFailed += failures.Add;
                    testMethod.Invoke(fixture, null);
                }
                catch(TargetInvocationException ex)
                {
                    failures.Add("Failed with an exception: " + ex.InnerException.Message);
                }
                if (failures.Any()) yield return TestResult.Failure(testName, failures.First());
                else yield return TestResult.Ok(testName);
            }
        }

        private bool TryGetConstructor(Type fixtureType, out Func<TestFixture> constructor)
        {
            constructor = null;

            var constructors = fixtureType.GetConstructors();

            if (!constructors.Any())
            {
                //no explicit constructors defined, use activator
                constructor = () => (TestFixture) Activator.CreateInstance(fixtureType);
                return true;
            }

            var constructorInfo = constructors
                .SingleOrDefault(c => c.IsPublic && c.GetParameters().Length == 0);

            if (constructorInfo != null)
            {
                constructor = () => (TestFixture)constructorInfo.Invoke(null);
            }
            
            return constructorInfo != null;
        }

        private IEnumerable<Type> ScanForFixtures()
        {
            var baseClass = typeof(TestFixture);

            //we want subclasses but not the TestFixture type itself
            return _assembly.DefinedTypes
                .Where(t => baseClass.IsAssignableFrom(t) && t != baseClass);
        }
    }
}
