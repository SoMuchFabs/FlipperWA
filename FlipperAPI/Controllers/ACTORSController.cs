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
using FlipperAPI;

namespace FlipperAPI.Controllers
{
    public class ACTORSController : ApiController
    {
        private FlipperDbContext db = new FlipperDbContext();

        // GET: api/ACTORS
        public IQueryable<ACTORS> GetACTORS()
        {
            return db.ACTORS;
        }

        // GET: api/ACTORS/5
        [ResponseType(typeof(ACTORS))]
        public IHttpActionResult GetACTORS(decimal id)
        {
            ACTORS aCTORS = db.ACTORS.Find(id);
            if (aCTORS == null)
            {
                return NotFound();
            }

            return Ok(aCTORS);
        }

        // PUT: api/ACTORS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutACTORS(decimal id, ACTORS aCTORS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aCTORS.ID_ACTOR)
            {
                return BadRequest();
            }

            db.Entry(aCTORS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ACTORSExists(id))
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

        // POST: api/ACTORS
        [ResponseType(typeof(ACTORS))]
        public IHttpActionResult PostACTORS(ACTORS aCTORS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ACTORS.Add(aCTORS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ACTORSExists(aCTORS.ID_ACTOR))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aCTORS.ID_ACTOR }, aCTORS);
        }

        // DELETE: api/ACTORS/5
        [ResponseType(typeof(ACTORS))]
        public IHttpActionResult DeleteACTORS(decimal id)
        {
            ACTORS aCTORS = db.ACTORS.Find(id);
            if (aCTORS == null)
            {
                return NotFound();
            }

            db.ACTORS.Remove(aCTORS);
            db.SaveChanges();

            return Ok(aCTORS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ACTORSExists(decimal id)
        {
            return db.ACTORS.Count(e => e.ID_ACTOR == id) > 0;
        }
    }
}