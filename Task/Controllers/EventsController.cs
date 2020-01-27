using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Task.Data;
using Task.Models;

namespace Task.Controllers
{
    public class EventsController : ApiController
    {
        private TaskContext db = new TaskContext();

        // GET: api/Events
        public IQueryable<EventsDto> GetEvents()
        {
            var events = from b in db.Events
                        select new EventsDto()
                        {
                            Id = b.Id,
                            CustomerId = b.CustomerId,
                            CustomerName = b.Customer.Name,
                            Content = b.Content,
                            EventDateTime = b.EventDateTime,
                            IsOpen = b.IsOpen
                        };

            return events;
        }
                            
        // GET: api/Events/5
        [ResponseType(typeof(EventsDto))]
        public async Task<IHttpActionResult> GetEvents(int id)
        {         
            var events = await db.Events.Include(b => b.Customer).Select(b =>
                new EventsDto()
                    {
                        Id = b.Id,
                        CustomerId = b.CustomerId,
                        CustomerName = b.Customer.Name,
                        Content = b.Content,
                        EventDateTime = b.EventDateTime,
                        IsOpen = b.IsOpen
                }).SingleOrDefaultAsync(b => b.Id == id);
                            
            if (events == null)
            {
                return NotFound();
            }

            return Ok(events);
        }

        // PUT: api/Events/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEvents(int id, Events events)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != events.Id)
            {
                return BadRequest();
            }

            db.Entry(events).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventsExists(id))
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

        // POST: api/Events
        [ResponseType(typeof(Events))]
        public async Task<IHttpActionResult> PostEvents(Events events)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Events.Add(events);
            await db.SaveChangesAsync();

            // Load Customer name
            db.Entry(events).Reference(x => x.Customer).Load();

            var dto = new EventsDto()
            {
                Id = events.Id,
                CustomerId = events.CustomerId,
                CustomerName = events.Customer.Name,
                Content = events.Content,
                EventDateTime = events.EventDateTime,
                IsOpen = events.IsOpen
            };
            return CreatedAtRoute("DefaultApi", new { id = events.Id }, dto);
        }

        // DELETE: api/Events/5
        [ResponseType(typeof(Events))]
        public async Task<IHttpActionResult> DeleteEvents(int id)
        {
            Events events = await db.Events.FindAsync(id);
            if (events == null)
            {
                return NotFound();
            }

            db.Events.Remove(events);
            await db.SaveChangesAsync();

            return Ok(events);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventsExists(int id)
        {
            return db.Events.Count(e => e.Id == id) > 0;
        }
    }
}