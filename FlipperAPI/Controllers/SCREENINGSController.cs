using FlipperAPI.Models.DTO;
using FlipperAPI.Repository;
using FlipperDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace FlipperAPI.Controllers
{
    [Authorize]
    public class SCREENINGSController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();


        // GET: api/screenings/?id={id}
        [Route("api/screenings")]
        [ResponseType(typeof(ScreeningsDTO))]
        public IEnumerable<ScreeningsDTO> GetScreeningsByFilmId(decimal id)
        {
            DateTime now = DateTime.Now;
            IEnumerable<SCREENINGS> screeningsRaw = _unitOfWork.ScreeningsRepository.Get(x => x.ID_FILM == id).Where(y => DateTime.Compare(y.SCREENING_DATE, now) > -1);
            List<ScreeningsDTO> screeningDTO = new List<ScreeningsDTO>();
            screeningsRaw.ToList().ForEach(x =>
            {
                screeningDTO.Add(new ScreeningsDTO
                {
                    Id_screening = x.ID_SCREENING,
                    Id_theater = x.ID_THEATER,
                    Price = x.PRICE,
                    Reduced_price = x.REDUCED_PRICE,
                    Screening_date = x.SCREENING_DATE,
                    Theater_Name = x.THEATERS.NAME
                });
            });
            if (screeningDTO == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable));
            }

            return screeningDTO;
        }

        // GET: api/screenings/seats/?id={id}
        [Route("api/screenings/seats")]
        [ResponseType(typeof(ScreeningsDTO))]
        [AllowAnonymous]
        public IEnumerable<SeatsDTO> GetSeatsByScreeningId(decimal id)
        {
            decimal idTheather = _unitOfWork.ScreeningsRepository.GetById(id).ID_THEATER;
            IEnumerable<SEATS> seatsRaw = _unitOfWork.SeatsRepository.Get(x=> x.ID_THEATER == idTheather);
            IEnumerable<decimal> stolenSeatsRaw = _unitOfWork.ReservationsRepository.Get(x => x.ID_SCREENING == id).Select(x => x.ID_SEAT);
            List<SeatsDTO> seatsDTO = new List<SeatsDTO>();
            seatsRaw.ToList().ForEach(x =>
            {
                seatsDTO.Add(new SeatsDTO
                {
                    Id_seats = x.ID_SEAT,
                    Code = x.CODE,
                    Id_theater = x.ID_THEATER,
                    Stolen = stolenSeatsRaw.Contains(x.ID_SEAT)
                });
            });

            if (seatsDTO == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable));
            }

            return seatsDTO;
        }
    }
}
