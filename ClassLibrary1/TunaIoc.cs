using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{

    public class TunaIoc : IRegistry, IResolver
    {
        private HashSet<Type> _registeredTypes
            = new HashSet<Type>();

        private Dictionary<Type, object> _singletons = new Dictionary<Type, object>();

        public void Register<T>()
        {
            _registeredTypes.Add(typeof(T));
        }

        public void Register<T>(T instance)
        {
            _singletons[typeof(T)] = instance;
        }

        public T Resolve<T>()
        {
            var type = typeof(T);
            if (_registeredTypes.Contains(type))
            {
                return (T)Activator.CreateInstance(type);
            }
            else
            {
                type = AssignableFrom<T>().Single();
                return (T)Activator.CreateInstance(type);
            }
        }

        public object Resolve(Type t)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Type> AssignableFrom<T>()
        {
            return _registeredTypes
                .Where(t => typeof(T).IsAssignableFrom(t));
        }
    }
}
