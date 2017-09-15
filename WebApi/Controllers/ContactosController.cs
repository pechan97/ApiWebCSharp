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
    public class ContactosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Contactos
        public IQueryable<Contactos> GetContactos()
        {
            return db.Contactos;
        }

        // GET: api/Contactos/5
        [ResponseType(typeof(Contactos))]
        public IHttpActionResult GetContactos(int id)
        {
            Contactos contactos = db.Contactos.Find(id);
            if (contactos == null)
            {
                return NotFound();
            }

            return Ok(contactos);
        }

        // PUT: api/Contactos/5
        [ResponseType(typeof(void))]
        [AllowAnonymous]
        public IHttpActionResult PutContactos(int id, Contactos contactos)
        {
            contactos.Id = id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactos.Id)
            {
                return BadRequest();
            }

            db.Entry(contactos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactosExists(id))
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

        // POST: api/Contactos
        [ResponseType(typeof(Contactos))]
        public IHttpActionResult PostContactos(Contactos contactos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contactos.Add(contactos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contactos.Id }, contactos);
        }

        // DELETE: api/Contactos/5
        [ResponseType(typeof(Contactos))]
        public IHttpActionResult DeleteContactos(int id)
        {
            Contactos contactos = db.Contactos.Find(id);
            if (contactos == null)
            {
                return NotFound();
            }

            db.Contactos.Remove(contactos);
            db.SaveChanges();

            return Ok(contactos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactosExists(int id)
        {
            return db.Contactos.Count(e => e.Id == id) > 0;
        }
    }
}