using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modsen.BL.Interfaces;
using Modsen.BL.Models;

namespace Modsen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        /// <summary>
        /// Get all existing events
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _eventService.GetAllEventsAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get event by ID
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _eventService.GetEventByIdAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Create new event
        /// </summary>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(EventDto eventDTO)
        {
            try
            {
                return Ok(await _eventService.AddEventAsync(eventDTO));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Update event information
        /// </summary>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(EventDto eventDTO)
        {
            try
            {
                return Ok(await _eventService.UpdateEventAsync(eventDTO));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Delete event
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _eventService.DeleteEventAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
