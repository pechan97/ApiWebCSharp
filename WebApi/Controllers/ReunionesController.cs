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
    public class ReunionesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Reuniones
        public IQueryable<Reuniones> GetReuniones()
        {
            return db.Reuniones;
        }

        // GET: api/Reuniones/5
        [ResponseType(typeof(Reuniones))]
        public IHttpActionResult GetReuniones(int id)
        {
            Reuniones reuniones = db.Reuniones.Find(id);
            if (reuniones == null)
            {
                return NotFound();
            }

            return Ok(reuniones);
        }

        // PUT: api/Reuniones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReuniones(int id, Reuniones reuniones)
        {
            reuniones.Id = id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reuniones.Id)
            {
                return BadRequest();
            }

            db.Entry(reuniones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReunionesExists(id))
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

        // POST: api/Reuniones
        [ResponseType(typeof(Reuniones))]
        public IHttpActionResult PostReuniones(Reuniones reuniones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reuniones.Add(reuniones);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reuniones.Id }, reuniones);
        }

        // DELETE: api/Reuniones/5
        [ResponseType(typeof(Reuniones))]
        public IHttpActionResult DeleteReuniones(int id)
        {
            Reuniones reuniones = db.Reuniones.Find(id);
            if (reuniones == null)
            {
                return NotFound();
            }

            db.Reuniones.Remove(reuniones);
            db.SaveChanges();

            return Ok(reuniones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReunionesExists(int id)
        {
            return db.Reuniones.Count(e => e.Id == id) > 0;
        }
    }
}