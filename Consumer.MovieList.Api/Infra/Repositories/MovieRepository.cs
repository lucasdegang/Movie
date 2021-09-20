using Consumer.MovieList.Api.Domain.Movie.Interface;
using Consumer.MovieList.Api.Domain.Movie.Model;
using System.Collections.Generic;
using System.Linq;

namespace Consumer.MovieList.Api.Infra.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public int Delete(int id)
        {
            var movie = _context.Set<MovieModel>().Find(id);
            _context.Remove(movie);
            _context.SaveChanges();

            return movie.Id;
        }

        public IList<MovieModel> GetAll()
        {
            return _context.Set<MovieModel>().ToList();
        }

        public MovieModel GetById(int id)
        {
            return _context.Set<MovieModel>().FirstOrDefault(c => c.Id == id);
        }

        public MovieModel Save(MovieModel model)
        {
            _context.Add(model);
            _context.SaveChanges();

            return model;
        }

        public MovieModel Update(MovieModel model)
        {
            _context.Set<MovieModel>().Update(model);
            _context.SaveChanges();
            return model;
        }

        public IList<MovieModel> GetAllWinners()
        {
           return _context.Set<MovieModel>().Where(x => x.Winner).ToList();
        }
    }
}
