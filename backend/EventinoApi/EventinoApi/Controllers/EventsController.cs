using Application.Services;
using AutoMapper;
using Domain.Entities;
using EventinoApi.Models;
using EventinoApi.Models;
using EventinoApi.Models.Out;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventinoApi.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsService _eventsService;
        private readonly IMapper _mapper;
        public EventsController(IEventsService eventsService, IMapper mapper)
        {
            _eventsService = eventsService;
            _mapper = mapper;
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OutEvent>> GetEvent([FromRoute] Guid id) =>
            Ok(_mapper.Map<OutEvent>(await _eventsService.GetFullEventAsync(id))
       with
            { FriendsSubscr = await _eventsService.GetCurrentUserFriendsSubscribedToEventAsync(id) });

        [HttpGet("MyHostedEvents")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<OutEvent>>> GetCurrentUserHostedEvents()
        {
            var hostedEvents = _mapper.Map<IReadOnlyCollection<OutEvent>>(await _eventsService.GetEventsHostedByCurrentUserIdAsync());

            var taskOutEventsWiyhFriends = hostedEvents
                .Select(async s => s with { FriendsSubscr = await _eventsService.GetCurrentUserFriendsSubscribedToEventAsync(s.Id) });

            foreach (var task in taskOutEventsWiyhFriends)
            {
                await task;
            }

            return Ok(taskOutEventsWiyhFriends.Select(s => s.Result));
        }

        [HttpGet("MySubscribedEvents")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyCollection<OutEvent>>> GetCurrentUserSubscribedEvents()
        {
            var subscribedEvents = _mapper.Map<IReadOnlyCollection<OutEvent>>(await _eventsService.GetEventsSubscribedByCurrentUserAsync());

            var taskOutEventsWiyhFriends = subscribedEvents
                .Select(async s => s with { FriendsSubscr = await _eventsService.GetCurrentUserFriendsSubscribedToEventAsync(s.Id) });

            foreach (var task in taskOutEventsWiyhFriends)
            {
                await task;
            }

            return Ok(taskOutEventsWiyhFriends.Select(s => s.Result));
        }


        [HttpPost]
        public async Task<ActionResult> CreateEvent(InputEvent eventToCreate)
        {
            var dalEventToCreate = new Event();

            dalEventToCreate.HostId = eventToCreate.HostId;
            dalEventToCreate.Title = eventToCreate.Title;
            dalEventToCreate.Description = eventToCreate.Description;
            dalEventToCreate.PhotoUrl = eventToCreate.PhotoUrl;
            dalEventToCreate.Place = eventToCreate.Place;
            dalEventToCreate.Type = eventToCreate.Type;
            dalEventToCreate.MaxMembers = eventToCreate.MaxMembers;
            dalEventToCreate.Created = DateTime.Now;
            dalEventToCreate.LastUpdated = DateTime.Now;
            dalEventToCreate.StartDate = eventToCreate.StartDate;
            dalEventToCreate.EndDate = eventToCreate.EndDate;

            var eventId = await _eventsService.CreateEventAsync(dalEventToCreate);
            await _eventsService.SetInterestsAsync(eventId, eventToCreate.Interests);
            return Ok();
        }

        [HttpPut("{Guid}")]
        public async Task<ActionResult> UpdateEvent(InputEvent eventToUpdate)
        {
            var eventBefore = await _eventsService.GetFullEventAsync(eventToUpdate.Id);
            if (eventBefore is null)
                return NotFound();

            eventBefore.Title = eventToUpdate.Title;
            eventBefore.Description = eventToUpdate.Description;
            eventBefore.PhotoUrl = eventToUpdate.PhotoUrl;
            eventBefore.Type = eventToUpdate.Type;
            eventBefore.MaxMembers = eventToUpdate.MaxMembers;
            eventBefore.StartDate = eventToUpdate.StartDate;
            eventBefore.EndDate = eventToUpdate.EndDate;
            eventBefore.Place = eventToUpdate.Place;
            eventBefore.LastUpdated = DateTime.Now;

            await _eventsService.SetInterestsAsync(eventToUpdate.Id, eventToUpdate.Interests);
            await _eventsService.UpdateEventAsync(eventBefore);
            return Ok();
        }
    }
}
