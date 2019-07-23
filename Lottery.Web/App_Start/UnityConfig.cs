using Lottery.Infrastructure.DI;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Lottery.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            DependencyConfig.Configure(container);
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}