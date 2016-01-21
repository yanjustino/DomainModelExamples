using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Events;
using CredPlus.Compartilhado.Events;
using CredPlus.Financiamento.Application;
using CredPlus.Handlers;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CredPlus
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new UnityContainer();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureDependencyInjection();
        }

        public void ConfigureDependencyInjection()
        {
            var container = new UnityContainer();
            container.RegisterType<IEventHandler<SolicitacaoCreditoConfirmada>, CreditoHandler>(new HierarchicalLifetimeManager());

            //config.DependencyResolver = new UnityResolverHelper(container);
            DomainEventNotifier.Container = new EventContainer(container);

            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
