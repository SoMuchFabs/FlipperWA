using FlipperAPI.Models.DTO;
using FlipperAPI.Repository;
using FlipperDAL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace FlipperAPI.Controllers
{
    public class ACTORSController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        // GET: api/ACTORS
        public IEnumerable<ActorsDTO> GetACTORS()
        {
            List<ACTORS> listaAttoriRaw = _unitOfWork.ActorsRepository.Get().ToList();
            List<ActorsDTO> listaAttoriFinal = new List<ActorsDTO>();
            listaAttoriRaw.ForEach(x =>
            {
                listaAttoriFinal.Add(new ActorsDTO
                {
                    Id = x.ID_ACTOR,
                    Name = x.NAME,
                    Surname = x.SURNAME
                });
            });
            return listaAttoriFinal;
        }

        // GET: api/ACTORS/5
        [ResponseType(typeof(ActorsDTO))]
        public IHttpActionResult GetACTORS(decimal id)
        {
            ACTORS actor = _unitOfWork.ActorsRepository.GetById(id);
            if (actor == null)
            {
                return NotFound();
            }

            return Ok(
                new ActorsDTO{
                Id = actor.ID_ACTOR,
                Name = actor.NAME,
                Surname = actor.SURNAME
            });
        }

        //    // PUT: api/ACTORS/5
        //    [ResponseType(typeof(void))]
        //    public IHttpActionResult PutACTORS(decimal id, ACTORS aCTORS)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        if (id != aCTORS.ID_ACTOR)
        //        {
        //            return BadRequest();
        //        }

        //        db.Entry(aCTORS).State = EntityState.Modified;

        //        try
        //        {
        //            db.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ACTORSExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return StatusCode(HttpStatusCode.NoContent);
        //    }

        //    // POST: api/ACTORS
        //    [ResponseType(typeof(ACTORS))]
        //    public IHttpActionResult PostACTORS(ACTORS aCTORS)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        db.ACTORS.Add(aCTORS);

        //        try
        //        {
        //            db.SaveChanges();
        //        }
        //        catch (DbUpdateException)
        //        {
        //            if (ACTORSExists(aCTORS.ID_ACTOR))
        //            {
        //                return Conflict();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return CreatedAtRoute("DefaultApi", new { id = aCTORS.ID_ACTOR }, aCTORS);
        //    }

        //    // DELETE: api/ACTORS/5
        //    [ResponseType(typeof(ACTORS))]
        //    public IHttpActionResult DeleteACTORS(decimal id)
        //    {
        //        ACTORS aCTORS = db.ACTORS.Find(id);
        //        if (aCTORS == null)
        //        {
        //            return NotFound();
        //        }

        //        db.ACTORS.Remove(aCTORS);
        //        db.SaveChanges();

        //        return Ok(aCTORS);
        //    }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}