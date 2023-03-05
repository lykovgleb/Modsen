using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Modsen.Business.Interfaces;
using Modsen.Business.Models;
using Modsen.Data;
using Modsen.Data.Entities;

namespace Modsen.Business.Services
{
    public class EventServise : IEventService
    {
        private readonly EventContext _db;
        private readonly IMapper _mapper;

        public EventServise(EventContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<EventDTO> AddEventAsync(EventDTO eventDTO)
        {
            var newEvent = _mapper.Map<Event>(eventDTO);
            await _db.Events.AddAsync(newEvent);
            await _db.SaveChangesAsync();
            return _mapper.Map<EventDTO>(newEvent);
        }

        public async Task DeleteEventAsync(Guid id)
        {
            var deletedEvent = await GetEventIfExistAsync(id);
            _db.Events.Remove(deletedEvent);
            await _db.SaveChangesAsync();
        }

        public async Task<EventDTO> GetEventByIdAsync(Guid id)
        {
            var requiredEvent = await GetEventIfExistAsync(id);
            return _mapper.Map<EventDTO>(requiredEvent);
        }

        public async Task<List<EventDTO>> GetAllEventsAsync()
        {
            var events = await _db.Events.ToListAsync();
            return _mapper.Map<List<EventDTO>>(events);
        }

        public async Task<EventDTO> UpdateEventAsync(EventDTO eventDTO)
        {
            var oldEvent = await GetEventIfExistAsync(eventDTO.Id);
            var newEvent = _mapper.Map<Event>(eventDTO);

            if (oldEvent.Name != newEvent.Name) oldEvent.Name = newEvent.Name;
            if (oldEvent.Description != newEvent.Description) oldEvent.Description = newEvent.Description;
            if (oldEvent.Speaker != newEvent.Speaker) oldEvent.Speaker = newEvent.Speaker;
            if (oldEvent.TimeAndPlace != newEvent.TimeAndPlace) oldEvent.TimeAndPlace = newEvent.TimeAndPlace;

            await _db.SaveChangesAsync();
            return _mapper.Map<EventDTO>(oldEvent);
        }

        private async Task<Event> GetEventIfExistAsync(Guid id)
        {
            var requiredEvent = await _db.Events.FindAsync(id);
            if (requiredEvent == null)
                throw new Exception("The Event has not been found");
            return requiredEvent;
        }
    }
}
