using Autofac;
using Autofac.Core.Lifetime;
using Autofac.Integration.Mvc;
using System;
using System.Web;

namespace Review.Web.Tools
{
    public class SiteDependencyResolver
    {
        public IContainer Container { get; set; }

        public T Resolve<T>()
        {
            var scope = GetScope();
            return scope.Resolve<T>();
        }

        public ILifetimeScope GetScope()
        {
            try
            {
                if (HttpContext.Current != null)
                    return AutofacDependencyResolver.Current.RequestLifetimeScope;
                return Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
            }
            catch(Exception)
            {
                return Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
            }
        }
    }
}