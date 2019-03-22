using FlipperAPI.Models.DTO;
using FlipperAPI.Repository;
using FlipperDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;

namespace FlipperAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class filmsController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        // GET: api/FILMS
        [Route("api/films")]
        // [Authorize]
        public IEnumerable<FilmsDTO> Getfilms()
        {
            List<FILMS> listaFilm = _unitOfWork.FilmsRepository.Get().ToList();
            List<FilmsDTO> lista = new List<FilmsDTO>();
            listaFilm.ForEach(x =>
            {
                lista.Add(new FilmsDTO
                {
                    IdFilm = x.ID_FILM,
                    Title = x.NAME,
                    Duration = x.DURATION,
                    Plot = x.PLOT,
                    PosterUrl = x.POSTER_URL,
                    ReleaseDate = x.RELEASE_DATE,
                    ScreeningDate = x.SCREENINGS.Select(y => y.SCREENING_DATE.ToString() + " " + y.THEATERS.NAME),
                    Actors = string.Join(",", x.FILM_ACTOR.Select(y => y.ID_ACTOR)),
                    Genres = String.Join(",", x.FILM_GENRE.Select(y => y.ID_GENRE))
                });
            });
            return lista;
        }

        // GET: api/FILMS/?id={id}
        [Route("api/films")]
        [ResponseType(typeof(FilmsDTO))]
        [AllowAnonymous]
        public FilmsDTO GetfilmsById(decimal id)
        {
            FILMS Film = _unitOfWork.FilmsRepository.GetById(id);
            if(Film == null)
            {
                return new FilmsDTO();
            }
            FilmsDTO FilmDTO = new FilmsDTO
                {
                    IdFilm = Film.ID_FILM,
                    Title = Film.NAME,
                    Duration = Film.DURATION,
                    Plot = Film.PLOT,
                    PosterUrl = Film.POSTER_URL,
                    ReleaseDate = Film.RELEASE_DATE,
                    ScreeningDate = Film.SCREENINGS.Select(y => y.SCREENING_DATE.ToString() + " " + y.THEATERS.NAME),
                    Actors = string.Join(",", Film.FILM_ACTOR.Select(y => y.ID_ACTOR)),
                    Genres = String.Join(",", Film.FILM_GENRE.Select(y => y.ID_GENRE))
                };
            return FilmDTO;
        }

        // GET: api/Films/?Title={title}
        [AllowAnonymous]
        [ResponseType(typeof(FilmsDTO))]
        [Route("api/films")]
        public IEnumerable<FilmsDTO> GetFilmsByTitle(string title)
        {
            List<FILMS> filmRaw = _unitOfWork.FilmsRepository.Get(x => x.NAME.Contains(title)).ToList();
            List<FilmsDTO> filmDTOs = new List<FilmsDTO>();
            filmRaw.ForEach(x =>
            {
                filmDTOs.Add(new FilmsDTO
                {
                    IdFilm = x.ID_FILM,
                    Title = x.NAME,
                    Duration = x.DURATION,
                    Plot = x.PLOT,
                    PosterUrl = x.POSTER_URL,
                    ReleaseDate = x.RELEASE_DATE,
                    ScreeningDate = x.SCREENINGS.Select(y => y.SCREENING_DATE.ToString() + " " + y.THEATERS.NAME),
                    Actors = string.Join(", ", x.FILM_ACTOR.Select(y => new StringBuilder(y.ACTORS.NAME + " " + y.ACTORS.SURNAME))),
                    Genres = String.Join(", ", x.FILM_GENRE.Select(y => y.GENRES.NAME))
                });
            });
            if (filmDTOs == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return filmDTOs;
        }

        // GET: api/Films/?Genres={genreid}
        [AllowAnonymous]
        [ResponseType(typeof(FilmsDTO))]
        [Route("api/films")]
        public IEnumerable<FilmsDTO> GetFilmsByGenre(decimal genres)
        {
            List<decimal> filmIdRaw = _unitOfWork.FilmGenreRepository.Get(x => x.ID_GENRE == genres).Select(x => x.ID_FILM).ToList();
            List<FILMS> filmRaw = new List<FILMS>();
            filmIdRaw.ForEach(id => filmRaw.Add(_unitOfWork.FilmsRepository.GetById(id)));
            List<FilmsDTO> filmDTOs = new List<FilmsDTO>();
            filmRaw.ForEach(x =>
            {
                filmDTOs.Add(new FilmsDTO
                {
                    IdFilm = x.ID_FILM,
                    Title = x.NAME,
                    Duration = x.DURATION,
                    Plot = x.PLOT,
                    PosterUrl = x.POSTER_URL,
                    ReleaseDate = x.RELEASE_DATE,
                    ScreeningDate = x.SCREENINGS.Select(y => y.SCREENING_DATE.ToString() + " " + y.THEATERS.NAME),
                    Actors = string.Join(", ", x.FILM_ACTOR.Select(y => new StringBuilder(y.ACTORS.NAME + " " + y.ACTORS.SURNAME))),
                    Genres = String.Join(", ", x.FILM_GENRE.Select(y => y.GENRES.NAME))
                });
            });
            if (filmDTOs == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return filmDTOs;
        }

        // GET: api/Films/?Theater={theaterid}
        [AllowAnonymous]
        [ResponseType(typeof(FilmsDTO))]
        [Route("api/films")]
        public IEnumerable<FilmsDTO> GetFilmsByTheater(decimal theater)
        {
            List<decimal> filmIdRaw = _unitOfWork.ScreeningsRepository.Get(x => x.ID_THEATER == theater).Select(x => x.ID_FILM).ToList();
            List<FILMS> filmRaw = new List<FILMS>();
            filmIdRaw.ForEach(id => filmRaw.Add(_unitOfWork.FilmsRepository.GetById(id)));
            List<FilmsDTO> filmDTOs = new List<FilmsDTO>();
            filmRaw.ForEach(x =>
            {
                filmDTOs.Add(new FilmsDTO
                {
                    IdFilm = x.ID_FILM,
                    Title = x.NAME,
                    Duration = x.DURATION,
                    Plot = x.PLOT,
                    PosterUrl = x.POSTER_URL,
                    ReleaseDate = x.RELEASE_DATE,
                    ScreeningDate = x.SCREENINGS.Select(y => y.SCREENING_DATE.ToString() + " " + y.THEATERS.NAME),
                    Actors = string.Join(", ", x.FILM_ACTOR.Select(y => new StringBuilder(y.ACTORS.NAME + " " + y.ACTORS.SURNAME))),
                    Genres = String.Join(", ", x.FILM_GENRE.Select(y => y.GENRES.NAME))
                });
            });
            if (filmDTOs == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return filmDTOs;
        }

        //GET: api/filmsnow
        [Route("api/filmsnow")]
        [AllowAnonymous]
        public IEnumerable<FilmsDTO> GetFilmsNow()
        {
            DateTime now = DateTime.Now;
            List<FILMS> listaFilm = _unitOfWork.FilmsRepository.Get(x => x.SCREENINGS.Count > 0 && x.SCREENINGS.Any(y => DateTime.Compare(y.SCREENING_DATE, now) > -1)).ToList();
            List<FilmsDTO> lista = new List<FilmsDTO>();
            Random rand = new Random();
            listaFilm.ForEach(x =>
            {
                lista.Add(new FilmsDTO
                {
                    IdFilm = x.ID_FILM,
                    Title = x.NAME,
                    Duration = x.DURATION,
                    Plot = x.PLOT,
                    PosterUrl = x.POSTER_URL,
                    ReleaseDate = x.RELEASE_DATE,
                    ScreeningDate = x.SCREENINGS.Where(z=> DateTime.Compare(z.SCREENING_DATE,now)>-1).Select(y=>y.SCREENING_DATE.ToString() + " " + y.THEATERS.NAME),
                    Actors = string.Join(", ", x.FILM_ACTOR.Select(y => new StringBuilder(y.ACTORS.NAME + " " + y.ACTORS.SURNAME))),
                    Genres = String.Join(", ", x.FILM_GENRE.Select(y => y.GENRES.NAME))
                });
            });
            return lista;
        }

        //GET: api/filmsnext
        [Route("api/filmsnext")]
        [AllowAnonymous]
        public IEnumerable<FilmsDTO> GetFilmsnext()
        {
            DateTime now = DateTime.Now;
            List<FILMS> listaFilm = _unitOfWork.FilmsRepository.Get(x => DateTime.Compare(x.RELEASE_DATE, now) > 0).ToList();
            List<FilmsDTO> lista = new List<FilmsDTO>();
            Random rand = new Random();
            listaFilm.ForEach(x =>
            {
                lista.Add(new FilmsDTO
                {
                    IdFilm = x.ID_FILM,
                    Title = x.NAME,
                    Duration = x.DURATION,
                    Plot = x.PLOT,
                    PosterUrl = x.POSTER_URL,
                    ReleaseDate = x.RELEASE_DATE,
                    ScreeningDate = null,
                    Actors = string.Join(", ", x.FILM_ACTOR.Select(y => new StringBuilder(y.ACTORS.NAME + " " + y.ACTORS.SURNAME))),
                    Genres = String.Join(", ", x.FILM_GENRE.Select(y => y.GENRES.NAME))
                });
            });
            return lista;
        }

        //GET: api/posters
        [Route("api/films/posters")]
        [AllowAnonymous]
        public IEnumerable<string> GetPosters()
        {
            DateTime now = DateTime.Now;
            List<string> lista = _unitOfWork.FilmsRepository.Get(x => x.SCREENINGS.Count > 0 && x.SCREENINGS.Any(y => DateTime.Compare(y.SCREENING_DATE, now) > -1)).Select(x => x.LANDSCAPE_POSTER_URL).ToList();
            return lista;
        }

        // PUT: api/FILMS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putfilms(decimal id, FILMS filmToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != filmToUpdate.ID_FILM)
            {
                return BadRequest();
            }

            _unitOfWork.FilmsRepository.Update(filmToUpdate);

            try
            {
                _unitOfWork.Save();
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
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError);
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FILMS
        [AllowAnonymous]
        [Route("api/films")]
        [ResponseType(typeof(FILMS))]
        public IHttpActionResult Postfilms(FILMS film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.FilmsRepository.Insert(film);

            try
            {
                _unitOfWork.Save();
            }
            catch (DbUpdateException)
            {
                if (_unitOfWork.FilmsRepository.Exists(film.ID_FILM))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return Created("/api/films/" + film.ID_FILM, film);
        }

        // DELETE: api/FILMS/5
        [AllowAnonymous]
        [ResponseType(typeof(void))]
        public IHttpActionResult Deletefilms(decimal id)
        {
            _unitOfWork.FilmsRepository.DeleteById(id);

            try
            {
                _unitOfWork.Save();
            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError);
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool filmsExists(decimal id)
        {
            return _unitOfWork.FilmsRepository.Exists(id);
        }
    }
}