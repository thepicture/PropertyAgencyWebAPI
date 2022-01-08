using PropertyAgencyWebAPI.Models.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace PropertyAgencyWebAPI.Controllers
{
    public class EventController : ApiController
    {
        private readonly PropertyAgencyBaseEntities db =
            new PropertyAgencyBaseEntities();

        // GET: api/Events
        public IQueryable<Event> GetEvent()
        {
            return db.Event;
        }

        // GET: api/Events/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult GetEvent(int id)
        {
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/Events/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvent(string id, Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.UUID)
            {
                return BadRequest();
            }

            db.Entry(@event).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST:
        // /event?agent_id=1
        // &datetime=25
        // &type=meeting
        // &duration=60
        // &comment=comment
        [ResponseType(typeof(Event))]
        public IHttpActionResult PostEvent(int agent_id,
                                           long dateTime,
                                           string type,
                                           int? duration = null,
                                           string comment = null)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!db.Agent.Any(a => a.Id == agent_id))
            {
                return Content(HttpStatusCode.BadRequest,
                               new { error = "invalid agent id" });
            }
            if (dateTime <= DateTimeOffset.Now.ToUnixTimeSeconds())
            {
                return Content(HttpStatusCode.BadRequest,
                                new
                                {
                                    error = "invalid datetime, "
                                            + "it must be greater " +
                                            "than the current UNIX time"
                                });
            }

            if (!db.EventType.Any(et => et.EventTypeName == type))
            {
                return Content(HttpStatusCode.BadRequest,
                                new
                                {
                                    error = "empty or invalid event type, " +
                    "allowed types: " +
                    "[\"meeting\",\"presentation\",\"phone_call\"]"
                                });
            }

            if (duration != null && duration < 1)
            {
                return Content(HttpStatusCode.BadRequest,
                                new
                                {
                                    error = "duration in minutes " +
                                    "must be a positive integer"
                                });
            }

            Event @event = new Event
            {
                UUID = Guid.NewGuid().ToString(),
                AgentId = agent_id,
                DateTime = dateTime,
                EventType = db.EventType.First(e => e.EventTypeName == type),
                DurationInSeconds = duration,
                Comment = comment
            };

            db.Event.Add(@event);
            db.SaveChanges();

            return Ok(new
            {
                uuid = @event.UUID,
                agent_id = @event.AgentId,
                datetime = @event.DateTime,
                duration = @event.DurationInSeconds,
                type = @event.EventType.EventTypeName,
                comment = @event.Comment
            });
        }

        // DELETE: event?agent_id=1&event_uuid=64ee002a
        [ResponseType(typeof(Event))]
        public IHttpActionResult DeleteEvent(int agent_id, string event_uuid)
        {
            Event @event = db.Event
                .FirstOrDefault(e => e.UUID == event_uuid
                                     && e.AgentId == agent_id);
            if (@event == null)
            {
                return Content(HttpStatusCode.NotFound,
                             new
                             {
                                 error = "the given "
                                 + "event_uuid and agent_id pair "
                                 + "did not determine "
                                 + "an existing event"
                             });
            }

            _ = db.Event.Remove(@event);
            db.SaveChanges();

            return Ok(new
            {
                uuid = @event.UUID,
                agent_id = @event.AgentId,
                datetime = @event.DateTime,
                duration = @event.DurationInSeconds,
                type = db.EventType
                .First(e => e.EventTypeId == @event.EventTypeId)
                .EventTypeName,
                comment = @event.Comment
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(string id)
        {
            return db.Event.Count(e => e.UUID == id) > 0;
        }
    }
}