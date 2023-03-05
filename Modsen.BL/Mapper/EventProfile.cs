using AutoMapper;
using Modsen.BL.Models;
using Modsen.DL.Entities;

namespace Modsen.BL.Mapper
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<EventDto, Event>();
        }
    }
}
