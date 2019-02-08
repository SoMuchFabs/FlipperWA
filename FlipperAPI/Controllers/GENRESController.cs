using FlipperAPI.Models.DTO;
using FlipperAPI.Repository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace FlipperAPI.Controllers
{
    public class GENRESController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        public IEnumerable<GenresDTO> getGenres()
        {
            List<GENRES> listaGenresRaw = _unitOfWork.GenresRepository.Get().ToList();
            List<GenresDTO> listaGenresFinal = new List<GenresDTO>();
            listaGenresRaw.ForEach(x =>
            {
                listaGenresFinal.Add(new GenresDTO
                {
                    Id = x.ID_GENRE,
                    Description = x.DESCRIPTION,
                    Name = x.NAME
                });
            });
            return listaGenresFinal;
        }

        [ResponseType(typeof(GenresDTO))]
        public IHttpActionResult GetGenres(decimal id)
        {
            GENRES genre = _unitOfWork.GenresRepository.GetById(id);
            if (genre == null)
            {
                return NotFound();
            }

            return Ok(
                new GenresDTO
                {
                    Id = genre.ID_GENRE,
                    Description = genre.DESCRIPTION,
                    Name = genre.NAME
                });
        }
    }
}
