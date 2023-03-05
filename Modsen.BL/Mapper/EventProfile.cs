using AutoMapper;
using Modsen.Business.Models;
using Modsen.Data.Entities;

namespace Modsen.Business.Mapper
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDTO>();
            CreateMap<EventDTO, Event>();
        }
    }
}
