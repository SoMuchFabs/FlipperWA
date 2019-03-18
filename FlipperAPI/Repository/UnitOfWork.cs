
using FlipperDAL;
using System;

namespace FlipperAPI.Repository
{
    public class UnitOfWork : IDisposable
    {
        private FlipperDbContext _context = new FlipperDbContext();
        private GenericRepository<ACTORS> actorsRepository;
        private GenericRepository<FIDELITY_BONUS> fidelityBonusRepository;
        private GenericRepository<FILMS> filmsRepository;
        private GenericRepository<GENRES> genresRepository;
        private GenericRepository<RESERVATIONS> reservationsRepository;
        private GenericRepository<SCREENINGS> screeningsRepository;
        private GenericRepository<SEATS> seatsRepository;
        private GenericRepository<THEATERS> theatersRepository;
        private GenericRepository<FILM_ACTOR> filmActorRepository;
        private GenericRepository<FILM_GENRE> filmGenreRepository;

        public GenericRepository<ACTORS> ActorsRepository
        {
            get
            {
                if(actorsRepository == null)
                {
                    actorsRepository = new GenericRepository<ACTORS>(_context);
                }
                return actorsRepository;
            }
        }

        public GenericRepository<FIDELITY_BONUS> FidelityBonusRepository
        {
            get
            {
                if (fidelityBonusRepository == null)
                {
                    fidelityBonusRepository = new GenericRepository<FIDELITY_BONUS>(_context);
                }
                return fidelityBonusRepository;
            }
        }

        public GenericRepository<FILMS> FilmsRepository
        {
            get
            {
                if (filmsRepository == null)
                {
                    filmsRepository = new GenericRepository<FILMS>(_context);
                }
                return filmsRepository;
            }
        }

        public GenericRepository<GENRES> GenresRepository
        {
            get
            {
                if (genresRepository == null)
                {
                    genresRepository = new GenericRepository<GENRES>(_context);
                }
                return genresRepository;
            }
        }

        public GenericRepository<RESERVATIONS> ReservationsRepository
        {
            get
            {
                if (reservationsRepository == null)
                {
                    reservationsRepository = new GenericRepository<RESERVATIONS>(_context);
                }
                return reservationsRepository;
            }
        }

        public GenericRepository<SCREENINGS> ScreeningsRepository
        {
            get
            {
                if (screeningsRepository == null)
                {
                    screeningsRepository = new GenericRepository<SCREENINGS>(_context);
                }
                return screeningsRepository;
            }
        }

        public GenericRepository<SEATS> SeatsRepository
        {
            get
            {
                if (seatsRepository == null)
                {
                    seatsRepository = new GenericRepository<SEATS>(_context);
                }
                return seatsRepository;
            }
        }

        public GenericRepository<THEATERS> TheatersRepository
        {
            get
            {
                if (theatersRepository == null)
                {
                    theatersRepository = new GenericRepository<THEATERS>(_context);
                }
                return theatersRepository;
            }
        }

        public GenericRepository<FILM_GENRE> FilmGenreRepository
        {
            get
            {
                if (filmGenreRepository == null)
                {
                    filmGenreRepository = new GenericRepository<FILM_GENRE>(_context);
                }
                return filmGenreRepository;
            }
        }

        public GenericRepository<FILM_ACTOR> FilmActorRepository
        {
            get
            {
                if (filmActorRepository == null)
                {
                    filmActorRepository = new GenericRepository<FILM_ACTOR>(_context);
                }
                return filmActorRepository;
            }
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}