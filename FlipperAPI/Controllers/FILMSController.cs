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
using FlipperAPI.Models.DTO;

namespace FlipperAPI.Controllers
{
    public class filmsController : ApiController
    {
        private FlipperDbContext db = new FlipperDbContext();

        // GET: api/FILMS
        [Authorize]
        public IEnumerable<FilmsDTO> Getfilms()
        {
            List<FILMS> listaaa = db.FILMS.ToList();
            List<FilmsDTO> lista = new List<FilmsDTO>();
            Random rand = new Random();
            listaaa.ForEach(x => {
                lista.Add(new FilmsDTO {
                    Title = x.NAME,
                    Duration = x.DURATION,
                    inProiezione = (rand.Next(2) > 0)?true:false,
                    Plot = x.PLOT,
                    PosterUrl = x.POSTER_URL,
                    RelaseDate = x.RELEASE_DATE,
                    ScreeningDate = new DateTime(1492,10,3),
                    Actors = "pippo pluto paperino e archimede",
                    Genres = "Decisamente piu di uno"
                });
            });
            return lista;
        }

        // GET: api/FILMS/5
        [ResponseType(typeof(FILMS))]
        public IHttpActionResult Getfilms(decimal id)
        {
            FILMS fILMS = db.FILMS.Find(id);
            if (fILMS == null)
            {
                return NotFound();
            }

            return Ok(fILMS);
        }

        // PUT: api/FILMS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putfilms(decimal id, FILMS fILMS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fILMS.ID_FILM)
            {
                return BadRequest();
            }

            db.Entry(fILMS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!filmsExists(id))
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

        // POST: api/FILMS
        [ResponseType(typeof(FILMS))]
        public IHttpActionResult Postfilms(FILMS fILMS)
        {
            TimeSpan ciao = new TimeSpan(1, 32, 12);
            
            fILMS.DURATION =(decimal) ciao.TotalSeconds;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FILMS.Add(fILMS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (filmsExists(fILMS.ID_FILM))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = fILMS.ID_FILM }, fILMS);
        }

        // DELETE: api/FILMS/5
        [ResponseType(typeof(FILMS))]
        public IHttpActionResult Deletefilms(decimal id)
        {
            FILMS fILMS = db.FILMS.Find(id);
            if (fILMS == null)
            {
                return NotFound();
            }

            db.FILMS.Remove(fILMS);
            db.SaveChanges();

            return Ok(fILMS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool filmsExists(decimal id)
        {
            return db.FILMS.Count(e => e.ID_FILM == id) > 0;
        }
    }
}