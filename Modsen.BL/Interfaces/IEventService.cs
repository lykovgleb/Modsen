using Modsen.BL.Models;

namespace Modsen.BL.Interfaces
{
    public interface IEventService
    {
        Task<EventDto> AddEventAsync(EventDto eventDTO);
        Task DeleteEventAsync(Guid id);
        Task<EventDto> GetEventByIdAsync(Guid id);
        Task<List<EventDto>> GetAllEventsAsync();
        Task<EventDto> UpdateEventAsync(EventDto eventDTO);
    }
}
