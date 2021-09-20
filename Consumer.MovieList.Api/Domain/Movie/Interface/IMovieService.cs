using Consumer.MovieList.Api.Domain.Movie.Model;
using Consumer.MovieList.Api.Dto;
using System.Collections.Generic;

namespace Consumer.MovieList.Api.Domain.Movie.Interface
{
    public interface IMovieService
    {
        IList<MovieModel> GetAll();
        MovieModel GetById(int id);
        MovieModel Save(MovieDto model);
        MovieModel Update(int id, MovieDto model);
        MovieModel PatchUpdate(int id, MovieDto model);
        int Delete(int id);
        MovieOutput GetAwards();
    }
}
