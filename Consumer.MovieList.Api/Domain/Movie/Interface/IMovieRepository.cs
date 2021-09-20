using Consumer.MovieList.Api.Domain.Movie.Model;
using System.Collections.Generic;

namespace Consumer.MovieList.Api.Domain.Movie.Interface
{
    public interface IMovieRepository
    {
        IList<MovieModel> GetAll();
        MovieModel GetById(int id);
        MovieModel Save(MovieModel model);
        MovieModel Update(MovieModel model);
        int Delete(int id);
        IList<MovieModel> GetAllWinners();
    }
}
