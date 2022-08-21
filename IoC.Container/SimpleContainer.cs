using System;
using System.Collections.Generic;
using System.Linq;

namespace IoC.Container
{
    public class SimpleContainer : ISimpleContainer
    {
        Dictionary<Type, Func<object>> registrations = new Dictionary<Type, Func<object>>();
        public void Register<TService, TImpl>() where TImpl : TService
        {
            this.registrations.Add(typeof(TService), () => this.GetInstance(typeof(TImpl)));
        }

        public object Resolve<TClient>() where TClient : class
        {
            return this.GetInstance(typeof(TClient));
        }

        private object GetInstance(Type serviceType)
        {
            Func<object> creator;
            if (this.registrations.TryGetValue(serviceType, out creator)) return creator();
            else if (!serviceType.IsAbstract) return this.CreateInstance(serviceType);
            else throw new InvalidOperationException("No registration for " + serviceType);
        }

        private object CreateInstance(Type implementationType)
        {
            var ctor = implementationType.GetConstructors().Single();
            var parameterTypes = ctor.GetParameters().Select(p => p.ParameterType);
            var dependencies = parameterTypes.Select(t => this.GetInstance(t)).ToArray();
            return Activator.CreateInstance(implementationType, dependencies);
        }
    }
}