using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Modsen.BL.Interfaces;
using Modsen.BL.Models;
using Modsen.DL;
using Modsen.DL.Entities;

namespace Modsen.BL.Services
{
    public class EventServiсe : IEventService
    {
        private readonly EventContext _db;
        private readonly IMapper _mapper;

        public EventServiсe(EventContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<EventDto> AddEventAsync(EventDto eventDTO)
        {
            var newEvent = _mapper.Map<Event>(eventDTO);
            await _db.Events.AddAsync(newEvent);
            await _db.SaveChangesAsync();
            return _mapper.Map<EventDto>(newEvent);
        }

        public async Task DeleteEventAsync(Guid id)
        {
            var deletedEvent = await GetEventIfExistAsync(id);
            _db.Events.Remove(deletedEvent);
            await _db.SaveChangesAsync();
        }

        public async Task<EventDto> GetEventByIdAsync(Guid id)
        {
            var requiredEvent = await GetEventIfExistAsync(id);
            return _mapper.Map<EventDto>(requiredEvent);
        }

        public async Task<List<EventDto>> GetAllEventsAsync()
        {
            var events = await _db.Events.ToListAsync();
            return _mapper.Map<List<EventDto>>(events);
        }

        public async Task<EventDto> UpdateEventAsync(EventDto eventDTO)
        {
            var oldEvent = await GetEventIfExistAsync(eventDTO.Id);
            var newEvent = _mapper.Map<Event>(eventDTO);

            UpdateEvent(oldEvent, newEvent);

            await _db.SaveChangesAsync();
            return _mapper.Map<EventDto>(oldEvent);
        }

        private async Task<Event> GetEventIfExistAsync(Guid id)
        {
            var requiredEvent = await _db.Events.FindAsync(id);
            if (requiredEvent == null)
                throw new Exception("The Event has not been found");
            return requiredEvent;
        }

        private void UpdateEvent(Event oldEvent, Event newEvent)
        {
            oldEvent.Name = newEvent.Name;
            oldEvent.Description = newEvent.Description;
            oldEvent.Speaker = newEvent.Speaker;
            oldEvent.Organizer = newEvent.Organizer;
            oldEvent.Place = newEvent.Place;
            oldEvent.Time = newEvent.Time;
        }
    }
}
