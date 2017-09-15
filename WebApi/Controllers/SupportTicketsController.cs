using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class SupportTicketsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/SupportTickets
        public IQueryable<SupportTickets> GetSupportTickets()
        {
            return db.SupportTickets;
        }

        // GET: api/SupportTickets/5
        [ResponseType(typeof(SupportTickets))]
        public IHttpActionResult GetSupportTickets(int id)
        {
            SupportTickets supportTickets = db.SupportTickets.Find(id);
            if (supportTickets == null)
            {
                return NotFound();
            }

            return Ok(supportTickets);
        }

        // PUT: api/SupportTickets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSupportTickets(int id, SupportTickets supportTickets)
        {
            supportTickets.Id = id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supportTickets.Id)
            {
                return BadRequest();
            }

            db.Entry(supportTickets).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportTicketsExists(id))
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

        // POST: api/SupportTickets
        [ResponseType(typeof(SupportTickets))]
        public IHttpActionResult PostSupportTickets(SupportTickets supportTickets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SupportTickets.Add(supportTickets);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = supportTickets.Id }, supportTickets);
        }

        // DELETE: api/SupportTickets/5
        [ResponseType(typeof(SupportTickets))]
        public IHttpActionResult DeleteSupportTickets(int id)
        {
            SupportTickets supportTickets = db.SupportTickets.Find(id);
            if (supportTickets == null)
            {
                return NotFound();
            }

            db.SupportTickets.Remove(supportTickets);
            db.SaveChanges();

            return Ok(supportTickets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupportTicketsExists(int id)
        {
            return db.SupportTickets.Count(e => e.Id == id) > 0;
        }
    }
}