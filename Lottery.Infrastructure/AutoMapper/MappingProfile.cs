using AutoMapper;
using Lottery.Data.Entities;
using Lottery.Core.ViewModels;
using System.Linq;
using Lottery.Infrastructure.Helpers;
using System.Data.Entity;
using Lottery.Core.ServiceModels;
using Lottery.Core.DTOs;

namespace Lottery.Infrastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Card, CardEntity>();
            CreateMap<CardEntity, Card>();
            
            
            CreateMap<CardViewModel, Card>();
            CreateMap<Card, CardViewModel>();


            CreateMap<LotteryEvent, LotteryEventEntity>()
                .ForMember(dest => dest.WinnerCardId, opt => opt.MapFrom(src => src.WinnerCard.Id));

            CreateMap<LotteryEventEntity, LotteryEvent>()
                .ForMember(dest => dest.TotalCards, opt => opt.MapFrom(src => src.Cards.Count()))
                .ForMember(dest => dest.AvailableCards, opt => opt.MapFrom(src => src.Cards.Where(c => c.IsAvailable).Count()))
                .ForMember(dest => dest.Award, opt => opt.MapFrom(src => src.CardPrice * src.Cards.Count * 10))
                .ForMember(dest => dest.WinnerCard, opt => opt.MapFrom(
                    src => src.WinnerCardId != null ? src.Cards.First(c => c.Id == src.WinnerCardId) : null))
                .ForMember(dest => dest.EventProgress, opt => opt.MapFrom(
                    src => EventHelper.GetProgress(src.StartDate, src.StartTime, src.WinnerCardId)));

            CreateMap<LotteryEvent, LotteryEventDTO>();
            CreateMap<LotteryEvent, LotteryEventViewModel>();
            CreateMap<LotteryEventViewModel, LotteryEvent>();                
        }
    }
}
