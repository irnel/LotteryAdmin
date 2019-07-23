using Lottery.Infrastructure.DI;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Lottery.Infrastructure
{
    /// <summary>
    /// Config Unity Container
    /// </summary>
    /// 
    public static class UnityConfig
    {
        /// <summary>
        /// Register all components
        /// </summary>
        /// 
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            DependencyConfig.Configure(container);
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}