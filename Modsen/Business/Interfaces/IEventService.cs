using Modsen.Business.Models;

namespace Modsen.Business.Interfaces
{
    public interface IEventService
    {
        Task<EventDTO> AddEventAsync(EventDTO eventDTO);
        Task DeleteEventAsync(Guid id);
        Task<EventDTO> GetEventByIdAsync(Guid id);
        Task<List<EventDTO>> GetAllEventsAsync();
        Task<EventDTO> UpdateEventAsync(EventDTO eventDTO);
    }
}
