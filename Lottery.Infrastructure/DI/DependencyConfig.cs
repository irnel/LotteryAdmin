using Lottery.Data.AbstractRepositories;
using Lottery.Infrastructure.AppContext;
using Lottery.Infrastructure.Repositories;
using Lottery.Services.CardService;
using Lottery.Services.LotteryEventService;
using Unity;
using Unity.Lifetime;
using AutoMapper;
using Lottery.Infrastructure.AutoMapper;

namespace Lottery.Infrastructure.DI
{
    public static class DependencyConfig
    {
        public static void Configure(UnityContainer container)
        {
            #region DbContext
            container.RegisterType<IDbContext, SQLDbContext>(new TransientLifetimeManager());
            #endregion

            #region AutoMapper
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });

            container.RegisterInstance(config.CreateMapper());
            #endregion

            #region Repositories
            container.RegisterType<ICardRepository, CardRepository>(new TransientLifetimeManager());
            container.RegisterType<ILotteryEventRepository, LotteryEventRepository>(new TransientLifetimeManager());
            #endregion

            #region Services
            container.RegisterType<ICardService, CardService>(new TransientLifetimeManager());
            container.RegisterType<ILotteryEventService, LotteryEventService>(new TransientLifetimeManager());
            #endregion
  
        }
    }
}
