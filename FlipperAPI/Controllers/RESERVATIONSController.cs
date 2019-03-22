using FlipperAPI.Models;
using FlipperAPI.Repository;
using FlipperDAL;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;

namespace FlipperAPI.Controllers
{
    [Authorize]
    public class RESERVATIONSController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        // POST: api/reservations
        [Route("api/prereservations")]
        public IHttpActionResult PostPrereservations(List<ReservationBindingModel> Reservations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

            if (TheyTookYourPlace(Reservations, Reservations[0].ID_SCREENING))
            {
                return BadRequest("Seats are already reserved, refresh the page and try again");
            }

            return Ok();

        }


        // POST: api/reservations
        [Route("api/reservations")]
        public IHttpActionResult Postreservations(List<ReservationBindingModel> Reservations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string UID = User.Identity.GetUserId();
            for (int i = 0; i < Reservations.Count; i++)
            {
                RESERVATIONS res = new RESERVATIONS
                {
                    ID_SCREENING = Reservations[i].ID_SCREENING,
                    ID_SEAT = Reservations[i].ID_SEAT,
                    RESERVATION_DATE = Reservations[i].RESERVATION_DATE,
                    IS_REDUCED = Reservations[i].IS_REDUCED,
                    ID_USER = UID
                };

                _unitOfWork.ReservationsRepository.Insert(res);
            }

            if (TheyTookYourPlace(Reservations, Reservations[0].ID_SCREENING))
            {
                return BadRequest("Seats are already reserved, refresh the page and try again");
            }

            try
            {
                _unitOfWork.Save();
            }
            catch (DbUpdateException)
            {
                return BadRequest("Cannot reserve the reservation, reserve later");
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return Ok();
        }

        private bool TheyTookYourPlace(List<ReservationBindingModel> Reservations, decimal idScreening)
        {
            IEnumerable<decimal> stolenSeatsRaw = _unitOfWork.ReservationsRepository.Get(x => x.ID_SCREENING == idScreening).Select(x => x.ID_SEAT);
            var alreadyReserved = stolenSeatsRaw.Where(x => Reservations.Any(y => x == y.ID_SEAT));
            return alreadyReserved.Count()>0?true:false;
        }
    }
}
