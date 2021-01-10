using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using Autofac.Integration.WebApi;
using System.Web.Mvc;
using System.Web.Http;
using Review.Web.Tools;
using Review.Infrastructure.Services;
using Review.Infrastructure.Services.Interfaces;
using Review.Infrastructure.Data;
using Review.Infrastructure.Data.Interfaces;

namespace Review.Web.App_Start
{
    public class RegisterConfig
    {
        public static void RegisterDependencies()
        {
            var perRequestBuilder = new ContainerBuilder();

            perRequestBuilder.RegisterModule<AutofacWebTypesModule>();
            perRequestBuilder.RegisterControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
            perRequestBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();

            perRequestBuilder.RegisterType<ReviewContext>().As<IDbContext>().InstancePerRequest();
            perRequestBuilder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerDependency();
            perRequestBuilder.RegisterType<ReviewService>().As<IReviewService>().InstancePerDependency();

            var perRequestContainer = perRequestBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(perRequestContainer));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(perRequestContainer);

            var perLifetimeScopeBuilder = new ContainerBuilder();

            var perLifetimeScopeContainer = perLifetimeScopeBuilder.Build();
            Sigleton<SiteDependencyResolver>.Instance = new SiteDependencyResolver { Container = perLifetimeScopeContainer };
        }
    }
}